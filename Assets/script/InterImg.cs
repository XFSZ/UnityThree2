using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Text;
using SimpleJSON;
using System;
using LitJson;

public class InterImg : View    
{
    private string userName = "";
    string n = "";
     string httpaddress = "";
    string filepath = "";
     string suoluetupath = "";
    int I = -12;
    int ce = 0;
    int X = -5;
    int Y = -2;
    int count = 0;
    int jscount = 0;
    int maxcount = 0;
    string httplist = "";
    string httpimg = "";

    [Inject]
    public IEventDispatcher dispatcher { get; set; }
    //  http://127.0.0.1:8888

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnGUI()
    {
     string s = string.Format("In = {0}\nhttpaddress ={1}", n,httpaddress );
     GUI.TextArea(new Rect(0,Screen.height-200, Screen.width, Screen.height* 2/ 10), s);
     userName = GUI.TextField(new Rect(Screen.width- 200,20,200,20),userName);//15为最大字符串长度
    if(GUI.Button(new Rect(Screen.width- 80,80,50,20),"登录"))
		{
            httpimg = "http://" + userName + ":8888";
            httpaddress = httpimg;
            httplist = httpimg + "/todo/list";
            StartCoroutine("LoadImageFromInter", httplist);

		}

    }
    public IEnumerator LoadImageFromInter(string imag)
    {
        WWW www = new WWW(imag);
         while (!www.isDone) { }
        string json = null;
        if (www.error != null)
        {
             n = www.error;
        }
        json = www.text;
         yield return www.text;
         filepath = Application.persistentDataPath + "/interpicture/";
         suoluetupath = Application.persistentDataPath + "/interSLpicture/";
         DirectoryInfo myDirinfo = new DirectoryInfo(filepath);
         DirectoryInfo myDirinfo2 = new DirectoryInfo(suoluetupath);
         if(!myDirinfo.Exists ||!myDirinfo2.Exists){
            Directory.CreateDirectory(filepath); 
            Directory.CreateDirectory(suoluetupath); 
            
         }else{
             FileInfo [] myDirFile = myDirinfo.GetFiles("*",SearchOption.AllDirectories);
             if(myDirFile.Length<10){
             JsonData jsondataname = JsonMapper.ToObject(json);
                 jsonvalue(jsondataname);
                for (int i = 0; i < maxcount; i++)
            {
                string js = httpimg + jsondataname[i]["name"];
                 yield return (LoadImgFromInter( js, jsondataname[i]["content"].ToString(),jsondataname[i]["jokname"].ToString()));

            }   
                 Debug.Log("inter");
             }else{
                 JsonData jsondataname = JsonMapper.ToObject(json);
                 jsonvalue(jsondataname);    
                   for (int i = 0; i < maxcount; i++)
                   {
                    string js =  jsondataname[i]["content"].ToString();
                    //StartCoroutine(LoadImgFromLocal( js));  
                  yield return LoadImgFromLocal( js);
                  Debug.Log("local");
                   }        
         }       
    }
    }
     void jsonvalue(JsonData jsondataname){      
            count = jsondataname.Count;
            jscount = jsondataname.Count / 10 / 2;
            Y = -jscount;
            if (count > 100)
            {
                maxcount = 100;
            }
            else { maxcount = count; }           
    }


        IEnumerator LoadImgFromLocal(string imagePath)
    {
        WWW www1;
        if(Application.platform == RuntimePlatform.Android){
             www1  = new WWW("file://" + suoluetupath + imagePath );
        }else{
           www1 = new WWW("file:///" + filepath + imagePath );
        }  
        yield return www1;
        if (www1.error == null)
        {
            n = imagePath;
            Texture2D tup = www1.texture;      
            tup.Compress(false);    
            LoadImg(tup);
        }
        else { n = n+ www1.error; Debug.LogError("LoadImage>>>www.error:" + www1.error); }
    }

     IEnumerator LoadImgFromInter(string imagePath,string name,string suoluetu)
    {
        WWW www2 = new WWW(httpimg + suoluetu);
        yield return www2;
        if (www2.error == null)
        {
            n = suoluetu;
            Texture2D tup = www2.texture;   
                    if(Application.platform == RuntimePlatform.Android){
                         StartCoroutine (SaveSLImgFromInter(httpimg + suoluetu, name));
        }else{
          StartCoroutine (SaveImgFromInter(imagePath, name));
        }   
          //  StartCoroutine (SaveImgFromInter(imagePath, name));
         //  StartCoroutine (SaveSLImgFromInter(httpimg + suoluetu, name));
            tup.Compress(false);    
              LoadImg(tup);
        }
        else { n = n+ www2.error;  Debug.LogError("LoadImage>>>www.error:" + www2.error); }
    }
       void LoadImg (Texture2D tup){
            Sprite sprite = Sprite.Create(tup, new Rect(0, 0, tup.width, tup.height), new Vector2(0.5f, 0.5f));
            GameObject jiushitu = (GameObject)Resources.Load("timg");          
            jiushitu.GetComponent<SpriteRenderer>().sprite = sprite;
       //     float x = jiushitu.GetComponent<BoxCollider>().bounds.size.x;
       //     float y = jiushitu.GetComponent<BoxCollider>().bounds.size.y;
            jiushitu.gameObject.GetComponent<BoxCollider>().size = (new Vector3(6, 12, 0.2f));
            tup = null;
            GameObject op = Instantiate(jiushitu, new Vector3(X * 20f, Y * 20f, 0f), Quaternion.identity);
            op.gameObject.name = op.gameObject.name + ce;
            ce++;
            if (X >= 6)
            {
                X = -6;
                Y++;
            }
            X++;
            I++;
       }


 IEnumerator SaveImgFromInter(string imagePath,string name ){

        WWW www3 = new WWW(imagePath);
        yield return www3;
        Texture2D tup = www3.texture;      
        byte[] bytes = tup.EncodeToJPG(); 
        File.WriteAllBytes(filepath + name , bytes);
        
 }
  IEnumerator SaveSLImgFromInter(string imagePath,string name){

        WWW www3 = new WWW(imagePath);
        yield return www3;
        Texture2D tup = www3.texture;      
        byte[] bytes = tup.EncodeToJPG(); 
        File.WriteAllBytes(suoluetupath + name , bytes);
        
 }
}
