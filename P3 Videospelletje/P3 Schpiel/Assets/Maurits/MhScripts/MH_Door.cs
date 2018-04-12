﻿using System.Collections;
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
                if (target.GetComponent<MH_Player>().hasKey)
                {
                    target.GetComponent<MH_Player>().hasKey = false;
                    gameObject.GetComponent<Animation>().Play("MH_KeyDoorOpen");
                    opened = true;

                }
            }
            else
            {
                gameObject.GetComponent<Animation>().Play("MH_DoorOpen");
                opened = true;
                StartCoroutine(Timer(target, 4));
            }
        }
        else
        {
            gameObject.GetComponent<Animation>().Play("MH_DoorClose");
            opened = false;
            StartCoroutine(Timer(target, 1.8f));
        }
    }
    public IEnumerator Timer(GameObject target, float time)
    {
        yield return new WaitForSeconds(time);
        target.GetComponent<MH_Player>().canInteract = true;
    }
}
