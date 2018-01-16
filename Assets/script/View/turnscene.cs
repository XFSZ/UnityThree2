using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class turnscene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TurnMain();
	}
	  void exitgame (){
		     if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
	  }
	  void TurnMain(){
 if (Input.GetKeyDown(KeyCode.Escape))
       Application.Quit(); 
	  }
}
