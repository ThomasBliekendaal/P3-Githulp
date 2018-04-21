using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DrEnemyMaster : MonoBehaviour
{

    private NavMeshAgent agent;

    public Transform player;
    private Transform navTarget;
    private Vector3 v = new Vector3(0, 0, 1);
    public GameObject cloud;
    public GameObject healthUI;
    public GameObject healthBar;
    public GameObject enemyManager;


    public float moveSpeed;
    public float maxHP;
    public float health;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        navTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        agent.SetDestination(navTarget.position);
        transform.Translate(v * moveSpeed * Time.deltaTime);

        healthUI.transform.LookAt(player);

        healthBar.GetComponent<Image>().fillAmount = 1 / maxHP * health;
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
        enemyManager.GetComponent<DrEnemySpawner>().enemyKilled = true;
        Destroy(gameObject);
        GameObject g = Instantiate(cloud, transform.position, transform.rotation);
        Destroy(g, 10);
    }
}
