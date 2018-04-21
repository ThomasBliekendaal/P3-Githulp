using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBKey : JBInteractable
{

    public JBDoor door;
    public JBThoughts thought;
    public JBThoughtInput handy;

    public void Start()
    {
        thought = GameObject.FindWithTag("Respawn").GetComponent<JBThoughts>();
    }

    public override void Interacted()
    {
        thought.SetNewThought(handy);
        door.locked = false;
        Destroy(gameObject);
    }
}