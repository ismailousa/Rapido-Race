using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCarMovemnt : MonoBehaviour {

    static float speed = -5;
    static float previousSpeed = 0;
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

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                previousSpeed = speed;
                speed = -10f;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                speed = previousSpeed;
        }
    }
}
