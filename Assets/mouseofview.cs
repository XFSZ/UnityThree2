using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseofview : MonoBehaviour {


  //  public GameObject center;
   public Vector3 center;
    void Start()
    {
      center =  Vector3.zero;
    }// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            
            transform.RotateAround(center, new Vector3(0, 1, 0), Input.GetAxis("Mouse X") * 5);
            transform.RotateAround(center, new Vector3(1, 0, 0), Input.GetAxis("Mouse Y") * 5);

           // this.transform.LookAt(center.transform.position);
		   this.transform.LookAt(Vector3.zero);
		 //  this.transform.
        }
        if (Input.GetAxis("Mouse ScrollWheel")<0)
        {
            Camera.main.fieldOfView += 2;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.fieldOfView -= 2;
        }

    }
}


