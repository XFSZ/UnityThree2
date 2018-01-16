using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class StartCommand : EventCommand {
           public override void Execute()
		   {
			   
			   Debug.Log("Start Command");
		   }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
