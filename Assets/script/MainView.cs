using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;
public class MainView : ContextView
{

  
    void Awake()
    {
        context = new MainContext(this);
    }
    // Use this for initialization
    void Start()
    {
     // DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
