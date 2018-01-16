using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		  if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
	}
}
