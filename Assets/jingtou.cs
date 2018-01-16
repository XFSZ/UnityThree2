using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jingtou : MonoBehaviour
{
    public Transform target;//主相机要围绕其旋转的物体  
    public float distance = 7.0f;//主相机与目标物体之间的距离  
    private float eulerAngles_x;
    private float eulerAngles_y;
    //水平滚动相关  

    public int distanceMax = 10;//主相机与目标物体之间的最大距离  

    public int distanceMin = 3;//主相机与目标物体之间的最小距离  

    public float xSpeed = 70.0f;//主相机水平方向旋转速度  

    //垂直滚动相关  

    public int yMaxLimit = 60;//最大y（单位是角度）  

    public int yMinLimit = -10;//最小y（单位是角度）  

    public float ySpeed = 70.0f;//主相机纵向旋转速度  



    //滚轮相关  

    public float MouseScrollWheelSensitivity = 1.0f;//鼠标滚轮灵敏度（备注：鼠标滚轮滚动后将调整相机与目标物体之间的间隔）  

    public LayerMask CollisionLayerMask;

    // Use this for initialization  

    void Start()
    {

        Vector3 eulerAngles = this.transform.eulerAngles;//当前物体的欧拉角  

        this.eulerAngles_x = eulerAngles.y;

        this.eulerAngles_y = eulerAngles.x;

    }


void Update(){
	
if( Input.GetAxis("Mouse ScrollWheel") != 0 )
{
this.gameObject.transform.Translate(new Vector3(0,0,Input.GetAxis("Mouse ScrollWheel")*Time.deltaTime*500));
}
}
    // Update is called once per frame  

    // void LateUpdate()

    // {

    //     if (this.target != null)

    //     {

    //         this.eulerAngles_x += ((Input.GetAxis("Mouse X") * this.xSpeed) * this.distance) * 0.02f;

    //         this.eulerAngles_y -= (Input.GetAxis("Mouse Y") * this.ySpeed) * 0.02f;

    //         this.eulerAngles_y = ClampAngle(this.eulerAngles_y, (float)this.yMinLimit, (float)this.yMaxLimit);

    //         Quaternion quaternion = Quaternion.Euler(this.eulerAngles_y, this.eulerAngles_x, (float)0);

    //         this.distance = Mathf.Clamp(this.distance - (Input.GetAxis("Mouse ScrollWheel") * MouseScrollWheelSensitivity), (float)this.distanceMin, (float)this.distanceMax);



    //         //从目标物体处，到当前脚本所依附的对象（主相机）发射一个射线，如果中间有物体阻隔，则更改this.distance（这样做的目的是为了不被挡住）  

    //         RaycastHit hitInfo = new RaycastHit();

    //         if (Physics.Linecast(this.target.position, this.transform.position, out hitInfo, this.CollisionLayerMask))

    //         {

    //             this.distance = hitInfo.distance - 0.05f;

    //         }

    //         Vector3 vector = ((Vector3)(quaternion * new Vector3((float)0, (float)0, -this.distance))) + this.target.position;



    //         //更改主相机的旋转角度和位置  

    //         this.transform.rotation = quaternion;

    //         this.transform.position = vector;

    //     }



    // }



    // //把角度限制到给定范围内  

    // public float ClampAngle(float angle, float min, float max)

    // {

    //     while (angle < -360)

    //     {

    //         angle += 360;

    //     }



    //     while (angle > 360)

    //     {

    //         angle -= 360;

    //     }



    //     return Mathf.Clamp(angle, min, max);

   // }



    //     // Use this for initialization
    //     [HideInInspector]
    //     public GameObject target; //a target look at  
    //     public float xSpeed; //speed pan x  
    //     public float ySpeed; //speed pan y  
    //     public float yMinLimit; //y min limit  
    //     public float yMaxLimit; //y max limit  

    //     public float scrollSpeed; //scroll speed  
    //     public float zoomMin;  //zoom min  
    //     public float zoomMax; //zoom max  

    //     //Private variable  
    //     private float distance;
    //     private float distanceLerp;
    //     private Vector3 position;
    //     private bool isActivated;
    //     private float x;
    //     private float y;
    //     private bool setupCamera;

    //     // Use this for initialization  

    //     void Start()
    //     {


    //         //Warning when not found target  
    //         if (target == null)
    //         {
    //             target = GameObject.FindGameObjectWithTag("Player");

    //             if (target == null)
    //             {
    //                 Debug.LogWarning("Don't found player tag please change player tag to Player");
    //             }
    //         }


    //         //Setup Pos  
    //         Vector3 angles = transform.eulerAngles;
    //         x = angles.y;
    //         y = angles.x;

    //         CalDistance();
    //     }



    //     void LateUpdate()
    //     {

    //         ScrollMouse();
    //         RotateCamera();

    //     }

    //     //Roate camera method  
    //     void RotateCamera()
    //     {
    //         if (Input.GetMouseButtonDown(1))
    //         {

    //             isActivated = true;

    //         }

    //         // if mouse button is let UP then stop rotating camera   
    //         if (Input.GetMouseButtonUp(1))
    //         {
    //             isActivated = false;
    //         }



    //         if (target && isActivated)
    //         {

    //             y -= Input.GetAxis("Mouse Y") * ySpeed;

    //             x += Input.GetAxis("Mouse X") * xSpeed;



    //             y = ClampAngle(y, yMinLimit, yMaxLimit);


    //             Quaternion rotation = Quaternion.Euler(y, x, 0);

    //             Vector3 calPos = new Vector3(0, 0, -distanceLerp);

    //             position = rotation * calPos + target.transform.position;

    //             transform.rotation = rotation;

    //             transform.position = position;


    //         }
    //         else
    //         {
    //             Quaternion rotation = Quaternion.Euler(y, x, 0);

    //             Vector3 calPos = new Vector3(0, 0, -distanceLerp);

    //             position = rotation * calPos + target.transform.position;

    //             transform.rotation = rotation;

    //             transform.position = position;
    //         }
    //     }

    //     //Calculate Distance Method  
    //     void CalDistance()
    //     {
    //         distance = zoomMax;
    //         distanceLerp = distance;
    //         Quaternion rotation = Quaternion.Euler(y, x, 0);
    //         Vector3 calPos = new Vector3(0, 0, -distanceLerp);
    //         position = rotation * calPos + target.transform.position;
    //         transform.rotation = rotation;
    //         transform.position = position;
    //     }

    //     //Scroll Mouse Method  
    //     void ScrollMouse()
    //     {
    //         distanceLerp = Mathf.Lerp(distanceLerp, distance, Time.deltaTime * 5);
    //         if (Input.GetAxis("Mouse ScrollWheel") != 0 )
    //         {
    //             // get the distance between camera and target  

    //             distance = Vector3.Distance(transform.position, target.transform.position);

    //             distance = ScrollLimit(distance - Input.GetAxis("Mouse ScrollWheel") * scrollSpeed, zoomMin, zoomMax);

    //         }
    //     }

    //     //Scroll Limit Method  
    //     float ScrollLimit(float dist, float min, float max)
    //     {
    //         if (dist < min)

    //             dist = min;

    //         if (dist > max)

    //             dist = max;

    //         return dist;
    //     }


    //     //Clamp Angle Method  
    //     float ClampAngle(float angle, float min, float max)
    //     {
    //         if (angle < -360)
    //             angle += 360;
    //         if (angle > 360)
    //             angle -= 360;
    //         return Mathf.Clamp(angle, min, max);
    //     }
}
