using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour {

    public GameObject car;
    public float maxPos = 2.3f;
    public float delayTimer = 0.5f;
    float timer;
	// Use this for initialization
	void Start () {
        timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Vector3 carPos = new Vector3(Random.Range(-maxPos, maxPos), transform.position.y, transform.position.z);
            Instantiate(car, carPos, transform.rotation);
            timer = delayTimer;
        }        
    }
}
