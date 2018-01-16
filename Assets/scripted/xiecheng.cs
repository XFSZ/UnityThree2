using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xiecheng : MonoBehaviour {


	// Use this for initialization
	void Start () {
		 StartCoroutine(xiecng());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

IEnumerator xiecng(){
          int i = 0;  
		   i++;
           Debug.Log("1");
	   while(i <= 10){
            i++;
		    Debug.Log(i);
		//	yield return null;
		yield return xiechng();
		Debug.Log("i:"+i);
	   }

	}
	IEnumerator xiechng(){
	yield return new WaitForSeconds(2);
}
}
