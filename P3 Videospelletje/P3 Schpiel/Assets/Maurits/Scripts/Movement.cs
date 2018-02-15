using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private Vector3 rotAmt;
    private Vector3 movePos;
    public float speed;
    public float camSensitivity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotAmt.y = Input.GetAxis("Mouse X");
        movePos.x = Input.GetAxis("Horizontal");
        movePos.z = Input.GetAxis("Vertical");
        transform.Translate(movePos * speed * Time.deltaTime);
        transform.Rotate(rotAmt * camSensitivity * Time.deltaTime);
	}
}
