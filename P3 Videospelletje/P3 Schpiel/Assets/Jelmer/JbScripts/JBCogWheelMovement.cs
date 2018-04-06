using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBCogWheelMovement : MonoBehaviour {
    public Vector3 r;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(r * Time.deltaTime);
	}
}
