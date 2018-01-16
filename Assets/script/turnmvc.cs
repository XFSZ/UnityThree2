using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine.UI;

public class turnmvc : View
{

    [Inject]
    public IEventDispatcher dispatcher { get; set; }
    public void OnClickLocal()
    {
       // dispatcher.Dispatch(TouchMainEvent.TOUCH_CLICK);
        SceneManager.LoadScene("yu");

    }
    public void OnClickInter()
    {
        SceneManager.LoadScene("Inter");
        // dispatcher.Dispatch(TouchMainEvent.TOUCH_RANDOM);
    }
    public void OnClickElse()
    {
        SceneManager.LoadScene("test1");
        // dispatcher.Dispatch(TouchMainEvent.TOUCH_RANDOM);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
