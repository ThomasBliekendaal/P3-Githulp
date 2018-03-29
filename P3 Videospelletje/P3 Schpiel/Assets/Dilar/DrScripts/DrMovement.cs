using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrMovement : MonoBehaviour
{
    public Animator weaponPosition;

    public Transform playerCamera;

    public Vector3 move;
    public Vector3 rotateValue;
    public Vector3 rotateValueCamera;

    public int sensitivity;
    public int walkSpeed;
    public int sprintSpeed;
    public int walkReset;

    public bool walking = false;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        walkReset = walkSpeed;
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

        if (move.z > 0 ||  move.z < 0 || move.x > 0 || move.x < 0)
        {
            weaponPosition.SetBool("Walking", true);
        }
        else
        {
            weaponPosition.SetBool("Walking", false);
        }


        if (Input.GetButton("Sprint"))
        {
            walkSpeed = sprintSpeed;
            weaponPosition.SetBool("Running", true);
            weaponPosition.SetBool("Walking", false);
        }
        else
        {
            walkSpeed = walkReset;
            weaponPosition.SetBool("Running", false);
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
