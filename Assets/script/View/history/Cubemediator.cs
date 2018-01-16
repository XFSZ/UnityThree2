using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class Cubemediator : EventMediator {
	[Inject]
	public CubeView view{get; set;}
    public  override void OnRegister(){
       view.init();
       view.dispatcher.AddListener(CubeViewEvent.CUBE_CLICK,onCubeClick);
          
    }

	public void onCubeClick(){
		Debug.Log("cube click - mediator");
		dispatcher.Dispatch(CubeMainEvent.SCORE_CHANGING);
	}
   public override void OnRemove(){
	   view.dispatcher.RemoveListener(CubeViewEvent.CUBE_CLICK,onCubeClick);

   }
}
