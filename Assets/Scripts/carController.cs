using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

    public float carSpeed;
    public float maxPos = 2.3f;
    Vector3 position;	// Use this for initialization
	void Start () {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
        transform.position = position;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Car")
            Destroy(gameObject);
    }
}
