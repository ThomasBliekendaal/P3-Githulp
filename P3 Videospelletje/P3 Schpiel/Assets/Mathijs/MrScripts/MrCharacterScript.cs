using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrCharacterScript : MonoBehaviour {

    public Rigidbody rigidbody;
    public Vector3 movement;
    public Vector3 jumpVector;
    public Vector3 lookAround;
    public float hor;
    public float ver;
    public float speed;
    public bool run;
    public float walkingSpeed;
    public float runningSpeed;
    public bool mayJump;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        if (Input.GetButtonDown("Sprint"))
        {
            run = true;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            run = false;
        }
        transform.Translate(movement * speed);
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        movement.x = hor;
        movement.z = ver;
        if (run == true)
        {
            speed = runningSpeed;
        }
        if (run == false)
        {
            speed = walkingSpeed;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (mayJump == true)
            {
                rigidbody.velocity = jumpVector;
                mayJump = false;
            }

        }
        lookAround.y -= -Input.GetAxis("Mouse X");
        transform.eulerAngles = (new Vector3(transform.eulerAngles.x, lookAround.y, 0.0f));
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            mayJump = true;
        }
    }
}
