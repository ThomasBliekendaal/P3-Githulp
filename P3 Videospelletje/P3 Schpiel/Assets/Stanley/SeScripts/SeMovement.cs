using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeMovement : MonoBehaviour
{
    public Vector3 movement;
    public float speed;
    public float h;
    public float v;

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        movement.x = h;
        movement.z = v;
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
