using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.mediation.impl;
public class ScoreView : View {

public Text ScoreText;
	
	// Update is called once per frame
	void Update () {
		
	}
	public void UpdateText(string txt){
		ScoreText.text = txt;
	}
}
