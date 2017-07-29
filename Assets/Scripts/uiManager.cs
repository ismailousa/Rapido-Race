using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pause()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
