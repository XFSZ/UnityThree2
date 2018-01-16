using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using strange.extensions.command.impl;

public class ImgCommandCircl : EventCommand
{

    [Inject]
    public IImgModel model1 { get; set; }
    public override void Execute()
    {
      
        model1.box = GameObject.FindGameObjectsWithTag("img");
     
        dispatcher.Dispatch(ImgViewEvent.IMG_CIRCL, model1.box);



    }
}
