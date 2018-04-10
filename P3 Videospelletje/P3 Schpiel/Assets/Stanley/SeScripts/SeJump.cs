using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeJump : MonoBehaviour
{
    public Rigidbody r;
    public Vector3 v;
    public int mayJump;

    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (mayJump >= 1)
        {

            if (Input.GetButtonDown("Jump"))
            {
                r.velocity = v;
                mayJump = mayJump - 1;
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (gameObject)
        {
            mayJump = 1;
        }
    }
}