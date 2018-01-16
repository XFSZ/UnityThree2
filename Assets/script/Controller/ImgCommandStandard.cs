using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using strange.extensions.command.impl;

public class ImgCommandStandard : EventCommand {

	[Inject]
	public IImgModel model {get;set;}
public override void Execute()
{
     model.box = GameObject.FindGameObjectsWithTag("img");

	dispatcher.Dispatch(ImgViewEvent.IMG_STANDARD,model.box);



}
}
