using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class countvalue : MonoBehaviour {
      GameObject cube;
	  GameObject text;
	  GameObject canve;
	public  float cpz = -40;

//	  GameObject test;
//	float heigh = Screen.height/10;
	GameObject copycube;
	GameObject copytext;
 //int beishu = 30;
	// Use this for initialization
	void Awake(){
   //  canve = GameObject.Find("Canvas");
	}
	void Start () {
		 canve = GameObject.Find("Canvas");
		    //cpz = canve.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

public 	void copyinit(float scaley ,float positionx,string gameObjectname){
	//	copycube =Instantiate(cube);
	cube =(GameObject)(Resources.Load("Cube"));
	text =(GameObject)(Resources.Load("3dtext"));
	//test =(GameObject)(Resources.Load("Text"));
	
	copycube = Instantiate(cube);
	copytext = Instantiate(text);
	copycube.AddComponent<donghua>().zhi = scaley;
	copycube.GetComponent<donghua>().xposition = positionx;
	//copycube.transform.SetParent(GameObject.Find("Canvas").transform, false);
	copytext.GetComponent<TextMesh>().text = gameObjectname;
	copytext.transform.position = new Vector3(positionx-1,-1 ,cpz);
    copycube.transform.position = new Vector3(positionx,0 ,cpz);
	copycube.gameObject.name = gameObjectname;
//	 copycube.transform.localScale += (new Vector3(1,(float)scaley,1) -copycube.transform.localScale)*Time.deltaTime ;
  //  StartCoroutine(caton(copycube,scaley));
     

	}
	IEnumerator caton(GameObject copycube,float scaley){
    copycube.transform.localScale += (new Vector3(1,(float)scaley,1) -copycube.transform.localScale)*Time.deltaTime ;
		yield return null;

	}

}
