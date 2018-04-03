using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public virtual void Effect()
    {

    }
    public override void Interact(GameObject target)
    {
        Effect();
        interactor = target;
    }
}
