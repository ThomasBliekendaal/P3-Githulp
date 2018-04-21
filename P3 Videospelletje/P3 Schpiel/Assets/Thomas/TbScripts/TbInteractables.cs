using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TbInteractables : MonoBehaviour {
    public bool interacted;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Interaction()
    {
        interacted = true;
    }
}
