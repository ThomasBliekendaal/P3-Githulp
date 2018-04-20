using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_BossKey : MH_Item {
    public bool canCollect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider hit)
    {
        canCollect = true;
        if(hit.gameObject.tag == "Player" && canCollect)
        {
            GameObject.FindGameObjectWithTag("Gate").GetComponent<MH_Portal>().GotKey();
            Destroy(gameObject);
        }
    }
    public override void Interact(GameObject target)
    {
        if(target.tag == "Player" && canCollect)
        {
            GameObject.FindGameObjectWithTag("Gate").GetComponent<MH_Portal>().GotKey();
            Destroy(gameObject);
        }
    }
}
