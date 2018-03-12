using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrMovement : MonoBehaviour
{
    public Transform playerCamera;
    public Vector3 move;
    public Vector3 rotateValue;
    public Vector3 rotateValueCamera;
    public int sensitivity;
    public int walkSpeed;
    public int sprintSpeed;
    public int walkReset;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotator();
    }

    public void FixedUpdate()
    {
        move.z = Input.GetAxis("Vertical") * walkSpeed;
        move.x = Input.GetAxis("Horizontal") * walkSpeed;
        move *= Time.deltaTime;
        transform.Translate(move);

        if (Input.GetButton("Sprint"))
        {
            walkSpeed = (walkSpeed = sprintSpeed);
        }
        else
        {
            walkSpeed = walkReset;
        }
    }

    private void CameraRotator()
    {
        rotateValue.x = -Input.GetAxis("Mouse Y");
        rotateValueCamera.y = Input.GetAxis("Mouse X");
        transform.Rotate(rotateValueCamera);
        playerCamera.transform.Rotate(rotateValue);
    }
}
