using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    private Vector3 rotAmt;
    public float CamSensitivity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotAmt.x = -Input.GetAxis("Mouse Y");
        transform.Rotate(rotAmt * CamSensitivity * Time.deltaTime);
	}
}
