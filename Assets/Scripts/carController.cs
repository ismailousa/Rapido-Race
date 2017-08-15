using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

    float carSpeed = 6f;
    float maxPos = 2.3f;
    Vector3 position;	// Use this for initialization
    public uiManager ui;
    bool currentPlatformAndroid;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    #if UNITY_ANDROID
            currentPlatformAndroid = true;
    #else
            currentPlatfromAndroid = false;
    #endif
        ui.am.carSound.Play();
    }

	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
            if (currentPlatformAndroid)
            //position.x += Input.touches[0].deltaPosition.x * carSpeed * Time.deltaTime;
            {
                float x = Input.acceleration.x;
                Debug.Log("X:" + x);
            if (x < -0.1f)
                rb.velocity = new Vector3(-carSpeed, 0, 0);
            else if (x > 0.1f)
                rb.velocity = new Vector3(carSpeed, 0, 0);
            else
                rb.velocity = Vector2.zero;
           // position.x += Input.acceleration.x * carSpeed * Time.deltaTime;
        }
            else
                position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        position = transform.position;
        position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Car")
        {
            Destroy(gameObject);
            ui.setGameOVer();
            ui.am.carSound.Stop();
        }
    }
}
