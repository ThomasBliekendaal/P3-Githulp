﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Vector3 movePos;
    public Vector3 rotAmt;
    public float moveSpeed;
    public float rotSpeed;
    public int health;
    public int armor;
    public RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        CamRot();
        if (Input.GetButtonDown("Interact"))
        {
            Interact();
        }
	}
    public void Movement()
    {
        movePos.x = Input.GetAxis("Horizontal");
        movePos.z = Input.GetAxis("Vertical");
        transform.Translate(movePos * moveSpeed * Time.deltaTime);
    }
    public void CamRot()
    {
        rotAmt.y = Input.GetAxis("Mouse X");
        transform.Rotate(rotAmt * rotSpeed * Time.deltaTime);
    }
    public void Death()
    {
        
    }
    public void Interact()
    {
        Physics.Raycast(transform.position, transform.forward, out hit, 50);
        if(hit.transform.gameObject.tag == "Interactable")
        {
            hit.transform.gameObject.GetComponent<Item>().Interact(gameObject);
        }
    }
}