using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using SimpleJSON;
using System;
using LitJson;

public class tupian : MonoBehaviour
{
    string n = "";
    string fie = "";
    string _filepath = "";
  
    int MaxCount=0;

    int I = -12;
    int ce = 0;
    int X = -5;
    int Y = -2;
    int count = 0;
    int jscount = 0;

    // Use this for initialization
    public void Start()
    {
        this.name = "Image";
        OnPhoton();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPhoton()
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jo.Call("queryGalleryn");

    }

    public void AndroidSaveHeadpath(string str)
    {
        _filepath = str;
        StartCoroutine("LoadImagejs", str);

    }
    public IEnumerator LoadImagejs(string imag)
    {
        WWW www = new WWW("file://" + imag);

        string json = null;
        if (www.error != null)
        {
            n = www.error;
        }
        while (!www.isDone) { }
        json = www.text;
        if (json == null)
        {
            fie = "null";
        }
        yield return www.text;
        JsonData jsondataname = JsonMapper.ToObject(json);
        fie = jsondataname.Count.ToString() + "wanle";
        count = jsondataname.Count;
        jscount = jsondataname.Count / 10 / 2;
        Y = -jscount;
            if (count > 80)
            {
                MaxCount = 80;
            }
            else { MaxCount = count; }
    
        for (int i = 0; i < MaxCount; i++)

        {
            string js = Application.persistentDataPath + "/picture/" + jsondataname[i]["display_name"].ToString();
             yield return LoadImagen(js);

        }
        
    }

    public IEnumerator LoadImagen(string imagePath)
    {
        WWW www = new WWW("file://" + imagePath);
        yield return www;

        if (www.error == null)
        {
            n = imagePath;
            Texture2D tup = www.texture;
            tup.Compress(false);
            Sprite sprite = Sprite.Create(tup, new Rect(0, 0, tup.width, tup.height), new Vector2(0.5f, 0.5f));          
          //  tup = null;
            GameObject jiushitu = (GameObject)Resources.Load("timg");
            //    DestroyImmediate(jiushitu.GetComponent<Image>().sprite.texture,false);   
            jiushitu.GetComponent<SpriteRenderer>().sprite = sprite;
            float x =   jiushitu.GetComponent<BoxCollider>().bounds.size.x;
            float y =   jiushitu.GetComponent<BoxCollider>().bounds.size.y;
            jiushitu.gameObject.GetComponent<BoxCollider>().size =  (new Vector3(  6, 12,0.2f));
         //   Bounds bounds1 = new Bounds() 
             tup = null;
            GameObject op = Instantiate(jiushitu, new Vector3(X * 15f, Y * 15f, 0f), Quaternion.identity);
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
        else { n = "wanle"; Debug.LogError("LoadImage>>>www.error:" + www.error); }
    }



}
