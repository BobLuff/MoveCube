using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotate : MonoBehaviour {
    private Ray ray;
    private RaycastHit hit;
    public LayerMask layerName;
    public GameObject body;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<ReleaseSkill>().pullStar == false)
            body.transform.LookAt(InputMove()); //lookAt 函数是z轴朝向的
		
	}
    private Vector3 InputMove()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, layerName))
            return new Vector3(hit.point.x, body.transform.position.y, hit.point.z);
        else
            return new Vector3(0, body.transform.position.y, 0);
    }
}
