using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_BossDamage : MH_BossAbility {
    public bool canDmg = true;
    public GameObject target;
    public float slowAmt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerStay(Collision hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            if (canDmg)
            {
                StartCoroutine(Dmg(10, hit.gameObject));
            }
        }
    }
    public void OnTriggerEnter(Collider hit)
    {
        target = hit.gameObject;
        target.GetComponent<MH_Player>().moveSpeed -= slowAmt;
    }
    public void OnTriggerExit(Collider hit)
    {
        target = null;
        hit.gameObject.GetComponent<MH_Player>().moveSpeed += slowAmt;
    }
    public IEnumerator Dmg(int dmgAmt, GameObject player)
    {
        canDmg = false;
        DealDmg(dmgAmt, player);
        yield return new WaitForSeconds(1);
        canDmg = true;
    }
}
