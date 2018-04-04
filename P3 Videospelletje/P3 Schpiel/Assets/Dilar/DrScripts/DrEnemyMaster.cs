using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrEnemyMaster : MonoBehaviour
{

    private NavMeshAgent agent;

    public Transform player;
    private Transform navTarget;
    private Vector3 v = new Vector3(0, 0, 1);
    public GameObject cloud;
    public GameObject healthbar;


    public float moveSpeed;
    public int health = 100;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        navTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        agent.SetDestination(navTarget.position);
        transform.Translate(v * moveSpeed * Time.deltaTime);

        healthbar.transform.LookAt(player);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject g = Instantiate(cloud, transform.position, transform.rotation);
        Destroy(g, 10);
    }
}
