using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TbProjectileScript : TbWeaponScript {
    public GameObject deathParticle;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * projectileVel);
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.transform.GetComponent<TbEnemyScript>().TakeDamage(damage);
        }
        if (collision.gameObject)
        {
            GameObject g = Instantiate(deathParticle,transform.position,transform.rotation);
            Destroy(gameObject);
            Destroy(g, 1);
        }
    }
}
