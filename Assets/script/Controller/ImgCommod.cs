using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using strange.extensions.command.impl;


public class ImgCommod :  EventCommand {

	[Inject]
	public IImgModel model {get;set;}
public override void Execute()
{

    Debug.Log("tiaozhuan");
       model.box = GameObject.FindGameObjectsWithTag("img");
  //dispatcher.Dispatch(ScoreViewEvent.SCORE_UPDATE,model.Score);
    dispatcher.Dispatch(ImgViewEvent.IMG_CLICK,model.box);
//	dispatcher.Dispatch(ImgViewEvent.IMG_RANDOM,model.box);
//	dispatcher.Dispatch(ImgViewEvent.IMG_STANDARD,model.box);
//	dispatcher.Dispatch(ImgViewEvent.IMG_CIRCL,model.box);

// if(model.Score>=5)
// {
//        Debug.Log("game over");
// 	//   SceneManager.LoadScene("begin");
// 	dispatcher.Dispatch(ScoreViewEvent.SCORE_OVER);
// }
}



}
