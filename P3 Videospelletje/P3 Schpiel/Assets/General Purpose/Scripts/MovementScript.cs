using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {
    public GameObject pCamera;
    public float walkSpeed;
    public int jumps;
    public float sensitivity;
    public Vector3 jumpVel;
    public Vector3 rotateVel;
    public Vector3 camRotateVel;
    public int totalJumps;
    public float sprintSpeed;
    public float walkSpeed2;


	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        totalJumps = jumps;
        walkSpeed2 = walkSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * walkSpeed;
        float strafe = Input.GetAxis("Horizontal") * walkSpeed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
        transform.Translate(strafe, 0, translation);

        if (Input.GetButtonDown("Jump"))
        {
            if (jumps > 0)
            {
                GetComponent<Rigidbody>().velocity += jumpVel;
                jumps -= 1;
            }
        }
        if (Input.GetButton("Sprint"))
        {
            walkSpeed = (walkSpeed = sprintSpeed);
        }
        else
        {
            walkSpeed = walkSpeed2;
        }

        rotateVel.y = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        transform.Rotate(rotateVel);

        camRotateVel.x = -Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        pCamera.transform.Rotate(camRotateVel);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            jumps = totalJumps;
        }
    }
}
