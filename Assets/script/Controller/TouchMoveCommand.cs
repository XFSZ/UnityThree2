using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using strange.extensions.command.impl;
public class TouchMoveCommand :  EventCommand {
 
	// Use this for initialization
public override void Execute()
{

	  dispatcher.Dispatch(TouchMainEvent.TOUCH_CLICK);
}
}
