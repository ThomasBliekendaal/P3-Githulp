using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_BossDoor : MH_Item {
    public bool unlocked;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            if (unlocked)
            {
                gameObject.GetComponent<Animation>().Play("MH_BossWallOpen");
            }
            else
            {
                print("Locked");
            }
        }
    }
    public void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            if (unlocked)
            {
                gameObject.GetComponent<Animation>().Play("MH_BossWallClose");
            }
        }
    }
}
