using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine.UI;

public class ImgVIew : View
{
    //public Text ImageViewText;
    public int i = 0, j = 0, k = 0;
    public GameObject[] box;
    public bool random1 = false;
    public bool standard = false;
    public bool circl1 = false;
    float size = 45f;
    Vector3[] positi;
    Transform[] kids;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void Update()
    {

    }

    void LateUpdate()
    {



        if (random1 == true) { random(); }
        if (circl1 == true) { CalualteSphere(); }
        if (standard == true) { Standard(); }

    }
    public void suijiweizhi()
    {
        Debug.Log("suijiweizhi");
        if (box != null)
        {
            positi = new Vector3[(int)box.Length];
            for (int i = 0; i < box.Length; i++)
            { positi[i] = new Vector3(Random.Range(-60, 60), Random.Range(-30, 30), Random.Range(0, 90)); }
            for (int i = 0; i < box.Length; i++)
            {
                PlayerPrefs.SetFloat(box[i].transform.name + "1", box[i].transform.position.x);
                PlayerPrefs.SetFloat(box[i].transform.name + "2", box[i].transform.position.y);
            }
        }
    }


    public void random()
    {
        Debug.Log("random");
        if (box != null)
        {
            bool c = false;
            for (j = 0; j < box.Length; j++)
            {
                box[j].transform.position += (positi[j] - box[j].transform.position) * Time.deltaTime * 1.5f;
                box[j].transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, box[j].transform.position.z) - Vector3.back);
                if (Vector3.Distance(box[j].transform.position, positi[j]) < 1) { c = true; }
            }
            if (c) { random1 = false; }
        }

    }
    public void CalualteSphere()
    {
         Debug.Log("circl1");
        if (box != null)
        {
            bool c = false;
            float inc = Mathf.PI * (3.0f - Mathf.Sqrt(5.0f));
            float off = 2.0f / box.Length;//注意保持数值精度  
            kids = new Transform[box.Length];
            for (i = 0; i < box.Length; i++)
            {
                float y = (float)i * off - 1.0f + (off / 2.0f);
                float r = Mathf.Sqrt(1.0f - y * y);
                float phi = i * inc;
                Vector3 pos = new Vector3(Mathf.Cos(phi) * r * size, y * size, Mathf.Sin(phi) * r * size);
                // GameObject tempGo = Instantiate(prefab) as GameObject;  //物体
                GameObject tempGo = box[i].gameObject;
                //  tempGo.transform.parent = parent;  
                // tempGo.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);  
                tempGo.transform.localPosition += (pos - tempGo.transform.localPosition) * Time.deltaTime * 2;
                tempGo.transform.rotation = Quaternion.LookRotation(Vector3.zero - tempGo.transform.position);
                tempGo.SetActive(true);
                kids[i] = tempGo.transform;
                if (Vector3.Distance(tempGo.transform.localPosition, pos) < 0.1f) { c = true; }
            }
            if (c) { circl1 = false; }
        }
    }

    public void Standard()
    {
        Debug.Log("Standard");
        if (box != null)
        {
            bool c = false;
            for (k = 0; k < box.Length; k++)
            {
                Vector3 positio = new Vector3(PlayerPrefs.GetFloat(box[k].transform.name + "1", box[k].transform.position.x),
              PlayerPrefs.GetFloat(box[k].transform.name + "2", box[k].transform.position.y), 0);
                box[k].transform.position += (positio - box[k].transform.position) * Time.deltaTime * 2f;
                box[k].transform.rotation = Quaternion.LookRotation(Vector3.forward - new Vector3(0, 0, box[k].transform.position.z));
                if (Vector3.Distance(box[k].transform.position, positio) < 0.05f) { c = true; }
            }
            if (c) { standard = false; }
        }
    }

    //   public void init()
    //   {
    //         StartCoroutine(randomMove());    
    //   }


    // 	public  void OnMouseDown(){
    // 		dispatcher.Dispatch(CubeViewEvent.CUBE_CLICK);
    // 		StartCoroutine(ChangeColor());
    // 	}
    //    IEnumerator ChangeColor()
    //    {
    // 	   //DoTween
    // 	   Renderer render =  gameObject.GetComponent<Renderer>();
    // 	   Color oldColor = render.material.color;
    // 	   render.material.color = Color.red;
    // 	   	yield	return new WaitForSeconds(1);
    // 		     render.material.color = oldColor;
    // 	  // gameObject.GetComponent<Renderer>().material.color = Color.red;
    //    }
    // 	IEnumerator randomMove()
    // 	{
    // 		while(true){
    // 	yield	return new WaitForSeconds(1);
    // 	transform.position = new Vector3 (Random.Range(-4,4),0,0);
    // 	}
    // 	}



    // 	public void UpdateText(string txt){
    // 		ImageViewText.text = txt;
    // 	}
}
