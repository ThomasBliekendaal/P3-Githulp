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
    public void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject == hit)
        {
            if (canDmg)
            {
                StartCoroutine(Dmg(Random.Range(5,11), hit.gameObject));
            }
        }
    }
    public void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            target = hit.gameObject;
            target.GetComponent<MH_Player>().moveSpeed -= slowAmt;
        }
    }
    public void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject == target)
        {
            target = null;
            hit.gameObject.GetComponent<MH_Player>().moveSpeed += slowAmt;
        }
    }
    public IEnumerator Dmg(int dmgAmt, GameObject player)
    {
        canDmg = false;
        DealDmg(dmgAmt, player);
        yield return new WaitForSeconds(1);
        canDmg = true;
    }
}
