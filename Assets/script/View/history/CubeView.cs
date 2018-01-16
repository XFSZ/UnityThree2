using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
public class CubeView : View {
	[Inject]
	  public IEventDispatcher dispatcher{get;set;}

  public void init()
  {
        StartCoroutine(randomMove());    
  }


	public  void OnMouseDown(){
		dispatcher.Dispatch(CubeViewEvent.CUBE_CLICK);
		StartCoroutine(ChangeColor());
	}
   IEnumerator ChangeColor()
   {
	   //DoTween
	   Renderer render =  gameObject.GetComponent<Renderer>();
	   Color oldColor = render.material.color;
	   render.material.color = Color.red;
	   	yield	return new WaitForSeconds(1);
		     render.material.color = oldColor;
	  // gameObject.GetComponent<Renderer>().material.color = Color.red;
   }
	IEnumerator randomMove()
	{
		while(true){
	yield	return new WaitForSeconds(1);
	transform.position = new Vector3 (Random.Range(-4,4),0,0);
	}
	}

}
