using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMove : MonoBehaviour {
    public Transform[] target;
    public float speed = 10f;
	// Use this for initialization
	void Start () {
     //   transform.position = new Vector3(Random.Range(-9, 9), 0.75f, Random.Range(-9, 9));
        StartCoroutine(MoveToPath());
		
	}
	

    private IEnumerator MoveToPath()
    {
        while(true)
        {
            for (int i = 0; i < target.Length; i++)
                yield return StartCoroutine(MoveToTarget(target[i].position));
            
        }
    }

    IEnumerator MoveToTarget(Vector3 target)
    {
        while((transform.position-target).magnitude>0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
                 
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
