using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.context.api;
public class MainContext : MVCSContext
{
    public MainContext(MonoBehaviour view) : base(view)
    {

    }
    protected override void mapBindings()
    {
        
        //injectionBinder
        //   injectionBinder.Bind<IScoreModel>().To<ScoreModel>().ToSingleton();

        injectionBinder.Bind<IImgModel>().To<ImgModel>().ToSingleton();

        //commandBinder
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
        //	commandBinder.Bind(CubeMainEvent.SCORE_CHANGING).To<ScoreCommand>();

        //	commandBinder.Bind(TouchMainEvent.TOUCH_CHANGING).To<ImgCommod>();
        //	commandBinder.Bind(TouchMainEvent.TOUCH_CLICK).To<ImgCommod>();
        commandBinder.Bind(TouchMainEvent.TOUCH_CIRCL).To<ImgCommandCircl>();
        commandBinder.Bind(TouchMainEvent.TOUCH_RANDOM).To<ImgCommandRandom>();
        commandBinder.Bind(TouchMainEvent.TOUCH_STANDARD).To<ImgCommandStandard>();
       // commandBinder.Bind(TouchMainEvent.TOUCH_CLICK).To<ImgCommod>();
      //  commandBinder.Bind(ImgViewEvent.IMG_CLICK).To<TouchMoveCommand>();

        //mediationBinder
        // mediationBinder.Bind<CubeView>().To<Cubemediator>();
        // mediationBinder.Bind<ScoreView>().To<ScoreMedia>();

        mediationBinder.Bind<ImgVIew>().To<ImgMediator>();
        mediationBinder.Bind<TouchView>().To<TouchMediator>();
        mediationBinder.Bind<TouchMoveView>().To<TouchMoveMediator>();
    }


}
