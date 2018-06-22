using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLamp : MonoBehaviour {
    public bool lightStar = false; //灯光状态
    public Material defaultMater;
    public Material selfMater;
    public GameObject selfLight;

     void OnTriggerEnter(Collider other)
    {
      //  Debug.Log("?");
        if(other.gameObject.tag==gameObject.tag)
        {
            selfLight.GetComponent<MeshRenderer>().material = selfMater;
           // Debug.Log("Enter");
            lightStar = true;
        }
        

    }
     void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag==gameObject.tag)
        {
            selfLight.GetComponent<MeshRenderer>().material = defaultMater;
            lightStar = false;
        }
    }

    // Use this for initialization
    void Start () {
        //  defaultMater = GetComponent<MeshRenderer>().material;
       /// selfLight.GetComponent<MeshRenderer>().material = selfMater;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
