using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using SimpleJSON;
using System;
using LitJson;

public class tupian : MonoBehaviour {
    string n = "";
    string fie = "";
    Texture image;
  //  Image uiimage;
  //  GameObject jk;
    int I=-2;
    byte[] fileData;
 private  JSONNode JSData;
    // Use this for initialization
  public  void Start () {
       this.name = "Image";
    //   jk =   GameObject.Find("timg");

    }
    
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)){ Application.Quit(); }
	}
    public void OpenPhoto()
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jo.Call("OpenGallery");
        
    }
    public void OnSelectPhoto()
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jo.Call("SelectPhoto");

    }
        public void OnPhoto()
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jo.Call("queryGallery");

    }
            public void OnPhoton()
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jo.Call("queryGalleryn");

    }
    public void GetImagePath(string imagePath)
    {
        n = imagePath;

        StartCoroutine("LoadImage", imagePath);
    }

  public IEnumerator LoadImage(string imagePath)
    {

        WWW www = new WWW("file://" + imagePath);
        yield return www;

        if (www.error == null)
        {
          
            n = "file://" + imagePath;
     //     jk =   GameObject.Find("timg");
          Texture tu =  www.texture;
          Texture2D tup =  www.texture;
        //  tup.width = tup.width / 5;
         // tup.height = tup.height / 5;
          tup.Compress(false);
          Sprite sprite = Sprite.Create(tup,new Rect(0,0,tup.width,tup.height),new Vector2(0.5f,0.5f));
       //   Sprite sprite = Sprite.Create(tup, new Rect(0,0,tup.width,tup.height),new Vector2(0.5f,0.5f));
       //    jk.GetComponent<SpriteRenderer>().sprite =  sprite;
      //    GameObject.Find("Quad").GetComponent<Renderer>().material.mainTexture =  tup;
          image = tu;
            GameObject jiushitu = ( GameObject)Resources.Load("timg");
           GameObject op =   Instantiate(jiushitu,new Vector3(0,0,50),Quaternion.identity);
    //  op.transform.localScale = new Vector3();
          jiushitu.GetComponent<SpriteRenderer>().sprite =  sprite;
         
          I++;
        }
        else { n = "wanle"; Debug.LogError("LoadImage>>>www.error:" + www.error); }
    }
    public void AndroidSaveHeadImageOver(string str)
    {
        n = "succeed123";
        StartCoroutine(LoadTexture(str));
    }
        public void AndroidSaveHead(string str)
    {
        n = "sb"+str;

    }
            public void AndroidSaveHeadpath(string str)
    {
          StartCoroutine("LoadImagejs",str);
   //    n = str;
     }
     public IEnumerator LoadImagejs(string imag){
        WWW www = new WWW("file://" + imag);
    //   WWW www = new WWW("file://" + Application.persistentDataPath+"/json/JsonPath.json");
        
        fie = "file://" + Application.persistentDataPath+"/json/JsonPath.json";
        string json = null;   
        if(www.error != null){
            n = www.error;
        }  
        while(!www.isDone){}
            json = www.text;
            n = json + "youle";
            fie = json + "youle1";
            if (json == null){
            fie = "null"; 
         //   return;
        }
        JsonData jsondataname = JsonMapper.ToObject(json);
    //    JSONArray jsondataname = JSON.Parse(json);

            JSData = JSON.Parse(json);
            if(JSData ==null){
                n  = JSData +"wanle";
            }
            n = JSData +"wanle";
           fie = jsondataname.Count.ToString() +"wanle";
           /*
        for(int i = 0;i<JSData.Count;i++){
            string js = JSData[i]["name"].Value; 
           //  StartCoroutine("LoadImagen",js);
        } */
       int gh =   jsondataname.Count / 5;
       int y = 0;
       while(y!=0&&y%5==0){
           StartCoroutine(waitload());
       }
       
          for(int i = 0;i<20;i++){
            string js = jsondataname[i]["name"].ToString(); 
            fie = js;
             StartCoroutine("LoadImagen",js);
        }
         yield  return www.text;
        }
       
   IEnumerator waitload(){
       
      yield return new  WaitForSeconds(2f);
  }
    
    public IEnumerator LoadImagen(string imagePath)
    {

        WWW www = new WWW("file://" + imagePath);
        yield return www;

        if (www.error == null)
        {
          n+= imagePath;
    //        n = "succeed"; 
          Texture tu =  www.texture;
          Texture2D tup =  www.texture; 
          tup.Compress(false);       
          Sprite sprite = Sprite.Create(tup,new Rect(0,0,tup.width,tup.height),new Vector2(0.5f,0.5f));     
          image = tu;
          GameObject jiushitu = ( GameObject)Resources.Load("timg");
          GameObject op =   Instantiate(jiushitu,new Vector3(I*15f,I*15f,50),Quaternion.identity);
          jiushitu.GetComponent<SpriteRenderer>().sprite =  sprite;  
          I++;
        }
        else { n = "wanle"; Debug.LogError("LoadImage>>>www.error:" + www.error); }
    }
    public IEnumerator LoadTexture(string name)
    {
        string path = "file://" + Application.persistentDataPath + "/" + name;
        WWW www = new WWW(path);
        while (!www.isDone) { }
        yield return www;
        n = path;
          Texture tu =  www.texture;
          Texture2D tup =  www.texture;
          Sprite sprite = Sprite.Create(tup,new Rect(0,0,tup.width,tup.height),new Vector2(0.5f,0.5f));
          GameObject.Find("timg").GetComponent<SpriteRenderer>().sprite =  sprite;
          GameObject.Find("Quad").GetComponent<Renderer>().material.mainTexture =  tup;
          image = tu;
   //       GameObject jiushitu = (GameObject)Resources.Load("timg");

    }
    public void AndroidSave(string str)
    {
        n = "1";
    }

    void OnGUI()
    {
        string s = string.Format("In = {0}\nfie = {1}", n ,fie);
        GUI.TextArea(new Rect(0, 0, Screen.width, Screen.height* 2/ 10), s);
        if (GUI.Button(new Rect(200, 200, 100, 100), "按钮")) { OpenPhoto(); }
        if (GUI.Button(new Rect(200, 400, 100, 100), "按钮")) { OnSelectPhoto(); }
      //   if (GUI.Button(new Rect(200, 800, 100, 100), "按钮")) { OnPhoto(); }
          if (GUI.Button(new Rect(400, 600, 100, 100), "按钮")) { OnPhoton(); }
         GUI.DrawTexture(new Rect(200, 600, 100, 100), image);  
       
    }
}
