using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour {
    public GameObject[] point;
    public GameObject panel1, panel2;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(AllStar(point))
        {
            panel1.SetActive(true);
            Time.timeScale = 0;
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            if(!panel2.activeInHierarchy&&!panel1.activeInHierarchy)
            {
                panel2.SetActive(true);
                Time.timeScale = 0;
            }
        }
		
	}

    bool AllStar(GameObject[] point)
    {
        for(int i=0;i<point.Length;i++)
        {
            if (!point[i].GetComponent<StreetLamp>().lightStar)
                return false;
        }
        return true;
    }

    public void Continue()
    {
        panel2.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene("test");
      //  Application.LoadLevel("test");

    }
    public void SignOut()
    {
        Application.Quit();
    }
}
