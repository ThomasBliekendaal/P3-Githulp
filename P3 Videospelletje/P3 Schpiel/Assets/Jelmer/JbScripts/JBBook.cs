using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBBook : JBInteractable {

    public JBThoughts thought;
    public JBThoughtInput input;

    public void Start()
    {
        thought = GameObject.FindWithTag("Respawn").GetComponent<JBThoughts>();
    }

    public override void Interacted()
    {
        thought.SetNewThought(input);
    }
}
