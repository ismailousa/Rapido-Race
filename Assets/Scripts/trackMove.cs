using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackMove : MonoBehaviour {

    float maxSpeed = 2.3f;
    float acceleration = 0.0005f;
    float speed = 0.6f;
    Vector2 offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (speed < maxSpeed)
            speed += acceleration;
        offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
