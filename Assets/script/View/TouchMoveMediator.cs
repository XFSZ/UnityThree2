using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class TouchMoveMediator : EventMediator {
 [Inject]
    public TouchMoveView view { get; set; }
 
    public override void OnRegister()
    {

        view.dispatcher.AddListener(TouchMainEvent.TOUCH_CLICK, onTouchClick);
 
    }


    public override void OnRemove()
    {

        view.dispatcher.RemoveListener(TouchMainEvent.TOUCH_CLICK, onTouchClick);



    }
    public void onTouchClick()
    {
        	Debug.Log("cube click - mediator");
		//	 GameObject[] box = evt.data as GameObject[];
		//	 view.box = box;
            view.time = 0;
            view.touchhit = false;
            view.two = false;
       dispatcher.Dispatch(TouchMainEvent.TOUCH_CLICK);
      
    }
}
