using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class TouchMediator : EventMediator
{
    [Inject]
    public TouchView view { get; set; }

   
    public override void OnRegister()
    {
        // view.init();

        view.dispatcher.AddListener(TouchMainEvent.TOUCH_CIRCL, onTouchCircl);
        view.dispatcher.AddListener(TouchMainEvent.TOUCH_RANDOM, onTouchRandom);
        view.dispatcher.AddListener(TouchMainEvent.TOUCH_CLICK, onTouchClick);
        view.dispatcher.AddListener(TouchMainEvent.TOUCH_STANDARD, onTouchStandard);



    }


    public override void OnRemove()
    {
        view.dispatcher.RemoveListener(TouchMainEvent.TOUCH_CIRCL, onTouchCircl);
        view.dispatcher.RemoveListener(TouchMainEvent.TOUCH_RANDOM, onTouchRandom);
        view.dispatcher.RemoveListener(TouchMainEvent.TOUCH_CLICK, onTouchClick);
        view.dispatcher.RemoveListener(TouchMainEvent.TOUCH_STANDARD, onTouchStandard);


    }
    public void onTouchClick()
    {
        	Debug.Log("cube click - mediator");
         
        dispatcher.Dispatch(TouchMainEvent.TOUCH_CLICK);
      
    }
    public void onTouchCircl()
    {
        //		Debug.Log("cube click - mediator");
        dispatcher.Dispatch(TouchMainEvent.TOUCH_CIRCL);
    }
    public void onTouchRandom()
    {
        //		Debug.Log("cube click - mediator");
        dispatcher.Dispatch(TouchMainEvent.TOUCH_RANDOM);
    }
    public void onTouchStandard()
    {
        //	Debug.Log("cube click - mediator");
        dispatcher.Dispatch(TouchMainEvent.TOUCH_STANDARD);
    }
}
