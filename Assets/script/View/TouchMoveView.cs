using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine.UI;

public class TouchMoveView : View
{

    [Inject]
    public IEventDispatcher dispatcher { get; set; }
    private float lastDis = 0;
    private float cameraDis = -200f;
    public float ScaleDump = 0.1f;
    // public float speed = 0.1F;
    public GameObject[] box;
    Vector3 StartPosition;
    Vector3 previousPosition;
    Vector3 offset;
    Vector3 finalOffset;
    public float time = 0;
    bool isSlide;
    public bool touchhit = false;
    GameObject touchh;
    float angle;
    public bool two = false;
    Vector3 cameraM;
    Vector3 positiontemp;
    bool tempposi = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            // dispatcher.Dispatch(TouchMainEvent.TOUCH_CLICK);
            box = GameObject.FindGameObjectsWithTag("img");
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    StartPosition = Input.mousePosition;
                    previousPosition = Input.mousePosition;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    offset = Input.mousePosition - previousPosition;
                    previousPosition = Input.mousePosition;
                    Vector3 Xoffset = new Vector3(offset.x, 0, 0);
                    Vector3 Yoffset = new Vector3(0, offset.y, 0);
                    for (int i = 0; i < box.Length; i++)
                    {
                        if (Mathf.Abs(offset.x) > Mathf.Abs(offset.y))
                            box[i].transform.RotateAround(Vector3.up, Vector3.Cross(Xoffset, Vector3.forward).normalized, offset.magnitude / 10);
                        else
                            box[i].transform.RotateAround(Vector3.left, Vector3.Cross(Yoffset, Vector3.forward).normalized, offset.magnitude / 20);
                        // if (box[i].transform.eulerAngles.y<=90) {

                        //   box[i].transform.RotateAround(Vector3.up, Vector3.Cross(Xoffset, Vector3.forward).normalized, offset.magnitude / 10);

                        //   }                   
                        //  box[i].transform.RotateAround(Vector3.left, Vector3.Cross(Yoffset, Vector3.forward).normalized, offset.magnitude / 20);
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {

                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.tag == "img" && touchhit == false)
                        {
                            touchhit = true;
                            tempposi = !tempposi;
                            cameraM = new Vector3(0, 0, -195);
                        }
                        touchh = GameObject.Find(hit.transform.name);
                        if (touchh.gameObject.transform.position.z >= -0.1f)
                        {
                            positiontemp = touchh.gameObject.transform.position;
                        }
                    }

                }
                finalOffset = Input.mousePosition - StartPosition;
                isSlide = true;
                angle = finalOffset.magnitude;
                if (two == true)
                {
                    isSlide = false;
                    // angle = 0;
                    // finalOffset = Vector3.zero;
                    two = false;
                }
            }
            else if (Input.touchCount > 1)
            {
                two = true;
                Touch t1 = Input.GetTouch(0);
                Touch t2 = Input.GetTouch(1);
                if (t2.phase == TouchPhase.Began)
                {
                    lastDis = Vector2.Distance(t1.position, t2.position);
                }
                if (t1.phase == TouchPhase.Moved && t2.phase == TouchPhase.Moved)
                {
                    float dis = Vector2.Distance(t1.position, t2.position);
                    if (Mathf.Abs(dis - lastDis) > 1)
                    {
                        cameraDis += (dis - lastDis) * ScaleDump;
                        cameraDis = Mathf.Clamp(cameraDis, -200f, -10f);
                        lastDis = dis;
                    }
                }

            }
        }


        if (isSlide)

        {
            Vector3 XfinalOffset = new Vector3(finalOffset.x, 0, 0);
            Vector3 YfinalOffset = new Vector3(0, finalOffset.y, 0);
            for (int i = 0; i < box.Length; i++)
            {
                if (Mathf.Abs(finalOffset.y) > Mathf.Abs(finalOffset.x))
                    box[i].transform.RotateAround(Vector3.right, Vector3.Cross(YfinalOffset, Vector3.forward).normalized, angle / 8 * Time.deltaTime);
                else
                    box[i].transform.RotateAround(Vector3.up, Vector3.Cross(XfinalOffset, Vector3.forward).normalized, angle / 8 * Time.deltaTime);
            }

            if (angle > 20)
            {
                angle -= angle / 20;
            }
            else
            {
                angle = 0;
                isSlide = false;
            }
        }
        if (touchhit == true)
        {
            time += Time.deltaTime;
              StartCoroutine(move());
            if (time <= 0.5f)
            {
                // hu.Update();
                touchh.transform.Rotate(-1 * Vector3.up, 360 / 0.5f * Time.deltaTime);
            }
            else { touchhit = false; time = 0; }

        }

    }
    IEnumerator move()
    {
        if (tempposi == true)
        {
            touchh.transform.position += (cameraM - touchh.transform.position) * Time.deltaTime * 6f;
        }
        else
        {
            touchh.transform.position += (positiontemp - touchh.transform.position) * Time.deltaTime * 6f;
        }

        yield return null;
    }
    void LateUpdate()
    {
        if (time >= 0.5f)
        {
            touchhit = false; time = 0;
        }
        this.transform.position = new Vector3(0, 0, cameraDis);
    }
}
