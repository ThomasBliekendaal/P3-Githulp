using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_BossDamage : MonoBehaviour {
    public bool canDmg = true;
    public GameObject target;
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
    }
    public IEnumerator Dmg(int dmgAmt, GameObject target)
    {
        canDmg = false;
        if(target.GetComponent<MH_Player>().armor < dmgAmt)
        {
            target.GetComponent<MH_Player>().health -= dmgAmt - target.GetComponent<MH_Player>().armor;
            target.GetComponent<MH_Player>().armor = 0;
        }
        else
        {
            target.GetComponent<MH_Player>().armor -= dmgAmt;
        }
        yield return new WaitForSeconds(1);
    }
}
