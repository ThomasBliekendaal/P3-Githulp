using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MhCamera : MonoBehaviour {
    private Vector3 rotAmt;
    public float camSensitivity;
    public GameObject slider;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        rotAmt.x = -Input.GetAxis("Mouse Y");
        transform.Rotate(rotAmt * camSensitivity * Time.deltaTime);
	}
    public void ChangeSensitivity()
    {
        camSensitivity = slider.GetComponent<Slider>().value;
    }
}
