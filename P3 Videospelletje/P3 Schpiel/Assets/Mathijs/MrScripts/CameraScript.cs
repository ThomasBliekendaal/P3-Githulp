using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Vector3 camerarondkijken;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        camerarondkijken.x += -Input.GetAxis("Mouse Y");
        camerarondkijken.x = Mathf.Clamp(camerarondkijken.x, -50.0f, 50.0f);
        transform.eulerAngles = (new Vector3(camerarondkijken.x, transform.eulerAngles.y, 0.0f));
    }
}
