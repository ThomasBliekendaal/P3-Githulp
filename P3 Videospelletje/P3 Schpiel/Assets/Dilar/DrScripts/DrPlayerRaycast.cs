﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrPlayerRaycast : MonoBehaviour
{

    public RaycastHit hit;
    public Transform camPos;

    public int dmg = 10;
    public int range = 25;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        if (Physics.Raycast(camPos.transform.position, camPos.transform.forward, out hit, range))
        {
            DrEnemyMaster mark = hit.transform.GetComponent<DrEnemyMaster>();
            if (mark != null)
            {
                mark.TakeDamage(dmg);
            }
            Debug.Log(hit.transform.name);
        }
    }
}
