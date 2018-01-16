using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donghua : MonoBehaviour {
 public float zhi = -1;
    GameObject text;
	GameObject copytext;
 public float xposition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(zhi != -1){
			donghuachuanzhi();
		}
	}
public	void donghuachuanzhi(){
	//	text =(GameObject)(Resources.Load("3dtext"));
	//	copytext = Instantiate(text);
     StartCoroutine(caton(zhi));
	}
		IEnumerator caton(float scaley){
		//	copytext.transform.position = transform.position;
    transform.localScale += (new Vector3(1,1,(float)scaley) -transform.localScale)*Time.deltaTime*0.5f ;
//	transform.position += new Vector3(0,(scaley -transform.localScale.y)/2-8 ,0)*Time.deltaTime*0.5f;
//	if((transform.localScale.y- scaley<0.1f)){
//		zhi = -1;
//	}
		yield return null;

	}

}
