using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TbProjectileScript : TbWeaponScript {
    public GameObject weapon;

	// Use this for initialization
	void Start () {
        weapon = GameObject.FindGameObjectWithTag("Weapon");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * projectileVel;
        hit = weapon.GetComponent<TbWandWep>().hit;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.transform.GetComponent<TbEnemyScript>().TakeDamage(damage);
        }
        if (collision.gameObject)
        {
            SpawnParticle();
            Destroy(gameObject);
        }
    }
}
