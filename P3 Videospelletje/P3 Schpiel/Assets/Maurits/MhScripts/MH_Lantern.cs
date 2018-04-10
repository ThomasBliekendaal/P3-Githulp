using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_Lantern : Item {
    public ParticleSystem particleh;
    public GameObject codeAppear;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void Interact(GameObject target)
    {
        if (particleh.isPlaying)
        {
            particleh.Stop();
            codeAppear.SetActive(true);
        }
        else
        {
            particleh.Play();
            codeAppear.SetActive(false);
        }
        target.GetComponent<Player>().canInteract = true;
    }
}
