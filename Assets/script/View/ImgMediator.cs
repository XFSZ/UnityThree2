using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

public class ImgMediator : EventMediator
{
    [Inject]
    public ImgVIew view1 { get; set; }

    public override void OnRegister()
    {
        //  view.init();

          dispatcher.AddListener(ImgViewEvent.IMG_CLICK,OnImgClick);
        dispatcher.AddListener(ImgViewEvent.IMG_RANDOM, OnImgRandom);
        dispatcher.AddListener(ImgViewEvent.IMG_STANDARD, OnImgStandard);
        dispatcher.AddListener(ImgViewEvent.IMG_CIRCL, OnImgCircl);


    }
    public override void OnRemove()
    {

        	dispatcher.RemoveListener(ImgViewEvent.IMG_CLICK,OnImgClick);
        dispatcher.RemoveListener(ImgViewEvent.IMG_RANDOM, OnImgRandom);
        dispatcher.RemoveListener(ImgViewEvent.IMG_STANDARD, OnImgStandard);
        dispatcher.RemoveListener(ImgViewEvent.IMG_CIRCL, OnImgCircl);


    }

    public void OnImgClick(IEvent evt){
        Debug.Log("Click");
        
        GameObject[] box = evt.data as GameObject[];
        dispatcher.Dispatch(TouchMainEvent.TOUCH_CLICK,box);
     //   view1.box = box;
     //   view1.
    }

    public void OnImgRandom(IEvent evt)
    {
        Debug.Log("Random");
        GameObject[] box = evt.data as GameObject[];
        view1.box = box;
        view1.random1 = true;
        view1.suijiweizhi();
        view1.standard = false;
        view1.circl1 = false;
        view1.j = 0;
    }
    public void OnImgStandard(IEvent evt)
    {
        Debug.Log("Standard");
        GameObject[] box = evt.data as GameObject[];
        view1.box = box;
        view1.standard = true;
        view1.circl1 = false;
        view1.random1 = false;
        view1.k = 0;
    }
    public void OnImgCircl(IEvent evt)
    {
        Debug.Log("Circl");
        GameObject[] box = evt.data as GameObject[];

        view1.box = box;
        view1.circl1 = true;
        view1.standard = false;
        view1.random1 = false;
        view1.i = 0;
    }

}
