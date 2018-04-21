using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TbEnemyScript : MonoBehaviour {
    public float enemyHealth;
    public float enemyDamage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }
}
