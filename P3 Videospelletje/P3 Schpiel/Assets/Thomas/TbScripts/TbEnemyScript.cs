using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TbEnemyScript : MonoBehaviour {
    public float enemyHealth;
    public float enemyDamage;
    public NavMeshAgent agent;
    public Transform target;

	// Use this for initialization
	void Start () {
        agent = this.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(target.position);

    }
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }
}
