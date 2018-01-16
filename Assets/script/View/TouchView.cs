using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine.UI;

public class TouchView : View
{

    public Texture biao;
    public Texture random;
    public Texture cirlc;
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    // 	    public void init()
    //   {
    //         StartCoroutine(randomMove());    
    //   }
    void OnGUI()
    {
        GUI.backgroundColor = Color.clear;
        GUI.DrawTexture(new Rect(Screen.width * 1 / 10 - 60, Screen.height * 1 / 10 - 55, 200, 160), biao);
        GUI.DrawTexture(new Rect(Screen.width * 2 / 10 - 60, Screen.height * 1 / 10 - 55, 200, 160), random);
        GUI.DrawTexture(new Rect(Screen.width * 3 / 10 - 60, Screen.height * 1 / 10 - 55, 200, 160), cirlc);
        if (GUI.Button(new Rect(Screen.width * 1 / 10, Screen.height * 1 / 10, 80, 80), "")) { dispatcher.Dispatch(TouchMainEvent.TOUCH_STANDARD); }
        if (GUI.Button(new Rect(Screen.width * 2 / 10, Screen.height * 1 / 10, 80, 80), "")) { dispatcher.Dispatch(TouchMainEvent.TOUCH_RANDOM); }
        if (GUI.Button(new Rect(Screen.width * 3 / 10, Screen.height * 1 / 10, 80, 80), "")) { dispatcher.Dispatch(TouchMainEvent.TOUCH_CIRCL); }

    }
}
