using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
//分享文字        
public class jingse :  MonoBehaviour{   
	#if UNITY_ANDROID
//定义AndroidJavaClass变量
 AndroidJavaClass UnityPlayer;
AndroidJavaClass Intent;
AndroidJavaClass Uri;
AndroidJavaClass Environment;
   string n = "";
#endif
   public  void Start () {
	     this.name = "Image";
     #if UNITY_ANDROID
//实例化AndroidJavaClass变量
UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
Intent = new AndroidJavaClass ("android.content.Intent");
Uri = new AndroidJavaClass ("android.net.Uri");
Environment = new AndroidJavaClass ("android.os.Environment");
#endif     

    }
      
private void shareText(string text){
        Debug.Log ("share text");
        #if UNITY_ANDROID
 
        AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
 
        AndroidJavaObject jstr_type=new AndroidJavaObject("java.lang.String","text/plain");
        AndroidJavaObject jstr_content=new AndroidJavaObject("java.lang.String",text.ToString());
 
 
        AndroidJavaObject intent = new AndroidJavaObject ("android.content.Intent",Intent.GetStatic<AndroidJavaObject>("ACTION_SEND"));
        intent.Call<AndroidJavaObject> ("setType",jstr_type);
        intent.Call<AndroidJavaObject> ("putExtra",Intent.GetStatic<AndroidJavaObject>("EXTRA_TEXT"),jstr_content); 
 
        currentActivity.Call ("startActivity",intent);
        #endif
}
 
//分享图片，picName包含.jpg或者.png
private void sharePicture(string picName){
        Debug.Log ("share picture");
        #if UNITY_ANDROID
 
        AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
 
        AndroidJavaObject jstr_type=new AndroidJavaObject("java.lang.String","image/*");
        AndroidJavaObject jstr_content=new AndroidJavaObject("java.lang.String",picName.ToString());
 
 
        AndroidJavaObject sdPath=new AndroidJavaObject("java.lang.String",Environment.CallStatic<AndroidJavaObject>("getExternalStorageDirectory").Call<AndroidJavaObject>("getAbsolutePath"));
        AndroidJavaObject img_path=new AndroidJavaObject("java.lang.String","/Android/data/"+Application.bundleIdentifier+"/files/"+picName);//将路径转化为java String
 
 
        img_path=sdPath.Call<AndroidJavaObject>("concat",img_path);
//                Log.CallStatic<int>("v", jstr_content,img_path);
 
        AndroidJavaObject img_file=new AndroidJavaObject("java.io.File",img_path);//等效于File img_file=new File（img_path）；
        if(img_file.Call<bool>("exists")){
                AndroidJavaObject intent = new AndroidJavaObject ("android.content.Intent",Intent.GetStatic<AndroidJavaObject>("ACTION_SEND"));
                intent.Call<AndroidJavaObject> ("setType",jstr_type);
                intent.Call<AndroidJavaObject> ("putExtra",Intent.GetStatic<AndroidJavaObject>("EXTRA_TEXT"),jstr_content); 
                intent.Call<AndroidJavaObject> ("putExtra",Intent.GetStatic<AndroidJavaObject>("EXTRA_STREAM"),Uri.CallStatic<AndroidJavaObject>("fromFile",img_file));
         
                currentActivity.Call ("startActivity",intent);
        }else{
              //  Debug.Log("picName.ToString()+" Not Exists");
        }
        #endif
}
    public void OpenPhoto()
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jo.Call("OpenGallery");
        
    }
	  public void GetImagePath(string imagePath)
    {
//          n = "succeed123";
        if (imagePath == null) {  }
		sharePicture( imagePath);
      //  StartCoroutine("LoadImage", imagePath);
    }
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)){SceneManager.LoadScene("yu"); }
	}
//  void OnGUI()
//     {
//         string s = string.Format("In = {0}", n);
//         GUI.TextArea(new Rect(0, 0, Screen.width *2/ 10, Screen.height* 2/ 10), s);
//         if (GUI.Button(new Rect(200, 200, 100, 100), "按钮")) { OpenPhoto(); }

       
//     }
}