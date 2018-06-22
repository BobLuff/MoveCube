using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseSkill : MonoBehaviour {
    public GameObject doubleHand;
    public GameObject cubePoint;
    public float pullSpeed = 0;
    public float maxPull = 20;
    Vector3 handPos;
    public bool pullStar = false;  //技能是否正在释放
    bool holdGO = false;  //是否拿着物体
    private RaycastHit hit;
    public LayerMask mask;
    Vector3 hitPos;


    private void HandTrail(float trailTime)
    {
        Transform[] a = doubleHand.GetComponentsInChildren<Transform>();
        
            for (int i = 1; i < a.Length; i++)
            {

                if (a[i].GetComponent<TrailRenderer>() != null)
                    a[i].GetComponent<TrailRenderer>().time = trailTime;
            }
        
   
    }


    void Release() //释放技能
    {
        HandTrail(1);
        handPos = doubleHand.transform.position;
        pullSpeed = 50;
        pullStar = true; //将技能设置为释放转态
        if(Physics.Raycast(handPos,doubleHand.transform.right,out hit,maxPull,mask)) //因为手的移动方向是x轴，所以这里要改成x轴
        {
            Debug.DrawLine(handPos, hit.point, Color.red, 2);
            hitPos = hit.point;
            // Debug.Log(hit.transform.tag);
           
        }
    }

    void Pull()  //拉伸
    {
        if (pullStar == true)
        {
            doubleHand.transform.Translate(Time.deltaTime * pullSpeed, 0, 0);
            if (hit.transform == null && (doubleHand.transform.position - handPos).magnitude > maxPull)
            {
                Debug.Log("No Cube");
                HandTrail(0);
                pullSpeed = -50;
            }

            //如果
            else if (hit.transform != null && (doubleHand.transform.position - hitPos).magnitude < 1f)
            {
                Debug.Log("Cube");
                //   hit.transform.localScale=hit
                hit.transform.parent = cubePoint.transform;
               // hit.transform.parent = doubleHand.transform;  //父子关系错乱，导致物体变形
                holdGO = true;
                HandTrail(0);
                pullSpeed = -50;
            }
            if (pullSpeed < 0 && (doubleHand.transform.position - handPos).magnitude < 0.5f)
            {
                pullSpeed = 0;
                doubleHand.transform.position = handPos;
                pullStar = false;
            }
        }
    }

    void KeepPos(Transform Cube)   //保持位置
    {
        if(Cube!=null&&Cube.parent!=null)
        {
            Cube.position = doubleHand.transform.position;
            Cube.rotation = doubleHand.transform.rotation;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(pullStar==false&&holdGO==false)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Release();
            }
        }
        else if(holdGO==true)
        {
            if(Input.GetMouseButtonDown(1))
            {
                hit.transform.SetParent(null);
                hit.transform.rotation = new Quaternion(0, 0, 0, 0);
                holdGO = false;
            }
        }
        Pull();
        KeepPos(hit.transform);
		
	}
}
