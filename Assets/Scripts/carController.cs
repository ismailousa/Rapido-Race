using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {

    float carSpeed = 0.3f;
    float maxPos = 2.3f;
    Vector3 position;	// Use this for initialization
    public uiManager ui;
    bool currentPlatformAndroid;

    void Awake()
    {
    #if UNITY_ANDROID
            currentPlatformAndroid = true;
    #else
            currentPlatfromAndroid = false;
    #endif
        ui.am.carSound.Play();
    }

	void Start () {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            if (currentPlatformAndroid)
                position.x += Input.touches[0].deltaPosition.x * carSpeed * Time.deltaTime;
            else
                position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

            position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
            transform.position = position;
        }
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
