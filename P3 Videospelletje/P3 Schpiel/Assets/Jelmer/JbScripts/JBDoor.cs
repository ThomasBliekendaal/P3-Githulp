using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JBDoor : JBInteractable {
    public float speed;
    public bool open;
    public float current;
    public bool locked;
    public JBThoughts thought;
    public JBThoughtInput lockedThought;


    public void Start()
    {
        current = transform.rotation.y;
        thought = GameObject.FindWithTag("Respawn").GetComponent<JBThoughts>();
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
        if(!locked)
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
        else
        {
            thought.SetNewThought(lockedThought);
        }
    }

    public void Unlock()
    {
        locked = false;
    }
}
