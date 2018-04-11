using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_Door : MH_Item {
    public bool opened;
    public bool keyDoor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    public override void Interact(GameObject target)
    {
        if(opened != true)
        {
            if (keyDoor)
            {
                if (target.GetComponent<Player>().hasKey)
                {
                    gameObject.GetComponent<Animation>().Play("MH_KeyDoorOpen");
                    opened = true;
                }
            }
            else
            {
                gameObject.GetComponent<Animation>().Play("MH_DoorOpen");
                opened = true;
            }
        }
    }
}
