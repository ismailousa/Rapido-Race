using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCarMovemnt : MonoBehaviour {

    float speed = -5;
    float maxSpeed = -8;
    float acceleration = 0.001f;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (speed > maxSpeed)
            speed -= acceleration;
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
	}
}
