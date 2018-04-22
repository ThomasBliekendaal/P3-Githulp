using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrEnemy : MonoBehaviour {
    public int moveSpeed = 4;
    public bool start;
    public Transform player;

    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {

        if (start == true)
        {
            transform.LookAt(player);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            start = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            start = false;
        }
    }
}
