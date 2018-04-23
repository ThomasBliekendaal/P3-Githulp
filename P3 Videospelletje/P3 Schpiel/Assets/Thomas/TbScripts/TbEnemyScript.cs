using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TbEnemyScript : MonoBehaviour {
    public float enemyHealth;
    public float enemyDamage;
    public Transform target;
    public Transform barrel;
    public GameObject spell;
    public float spellVel;
    public GameObject portalBoy;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if(enemyHealth <= 0)
        {
            portalBoy.SetActive(true);
            Destroy(gameObject);
        }
        //GameObject s = Instantiate(spell, barrel.position, barrel.rotation);
        //barrel.transform.LookAt(target);
        //s.GetComponent<Rigidbody>().velocity = transform.forward * spellVel;
    }
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //collision.gameObject.transform.GetComponent<TbMovementScript>().PlayerTakeDamage(enemyDamage);
        }
    }
}
