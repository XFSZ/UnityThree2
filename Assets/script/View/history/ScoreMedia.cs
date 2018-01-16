using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
public class ScoreMedia : EventMediator {
	[Inject]
	public ScoreView view {get;set;}
    public  override void OnRegister(){
     //  view.init();
       dispatcher.AddListener(ScoreViewEvent.SCORE_UPDATE,onScoreUpdate);
	   dispatcher.AddListener(ScoreViewEvent.SCORE_OVER,OnGameOver);

    }
	public override void OnRemove(){
  dispatcher.RemoveListener(ScoreViewEvent.SCORE_UPDATE,onScoreUpdate);
  dispatcher.RemoveListener(ScoreViewEvent.SCORE_OVER,OnGameOver);
	}
void onScoreUpdate(IEvent evt){
	    view.UpdateText(evt.data.ToString());
	}
	void OnGameOver(){
SceneManager.LoadScene("begin");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
