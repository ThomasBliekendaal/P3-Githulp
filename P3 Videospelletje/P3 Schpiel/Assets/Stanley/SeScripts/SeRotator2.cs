using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeRotator2 : MonoBehaviour
{
    public Vector3 v2;

    void Update()
    {
        v2.x = -Input.GetAxis("Mouse Y");
        transform.Rotate(v2);
    }
}