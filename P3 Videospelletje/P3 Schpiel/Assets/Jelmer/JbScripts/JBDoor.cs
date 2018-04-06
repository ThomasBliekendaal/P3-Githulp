﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBDoor : JBInteractable {
    public float speed;
    public bool open;
    public float current;

    public void Start()
    {
        current = transform.rotation.y;
    }

    public void Update()
    {
        if (open && transform.rotation.y <= current + 0.7f)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        else if(!open && transform.rotation.y >= current)
        {
            transform.Rotate(0, -speed * Time.deltaTime, 0);
        }
    }

    public override void Interacted()
    {
        if (open)
        {
            open = false;
        }
        else
        {
            open = true;
        }
    }
}
