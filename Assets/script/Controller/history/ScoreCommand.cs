using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using strange.extensions.command.impl;

public class ScoreCommand : EventCommand {
		[Inject]
	public IScoreModel model{get;set;}
public override void Execute()
{
   model.Score++;
  dispatcher.Dispatch(ScoreViewEvent.SCORE_UPDATE,model.Score);
if(model.Score>=5)
{
       Debug.Log("game over");
	//   SceneManager.LoadScene("begin");
	dispatcher.Dispatch(ScoreViewEvent.SCORE_OVER);
}
}

}
