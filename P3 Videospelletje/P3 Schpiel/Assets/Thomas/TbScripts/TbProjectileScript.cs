using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TbProjectileScript : TbWeaponScript {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            float eH = collision.gameObject.transform.GetComponent<TbEnemyScript>().enemyHealth;
            eH -= damage;
        }
    }
}
