using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class JBEnemy : MonoBehaviour {
    public Transform player;
    public NavMeshAgent agent;
    public float health;
    public float maxHealth;
    public Transform can;
    public Image healthBar;
    public JBEnemyManager manager;
    
    public void SetPlayer()
    {
        player = GameObject.FindWithTag("Player").transform;
        manager = GameObject.FindWithTag("Gate").GetComponent<JBEnemyManager>();
    }

    public void Move()
    {
        agent.SetDestination(player.position);
    }

	public virtual void Attack()
    {

    }

    public IEnumerator AttackTimer()
    {
        Attack();
        yield return new WaitForSeconds(1);
        StartCoroutine(AttackTimer());
    }
    
    public void Damage(float dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Destroy(gameObject);
            AddKill();
            manager.SpawnEnemy();
        }
    }
    public void Health()
    {
        can.transform.LookAt(player);
        healthBar.fillAmount = (1/maxHealth) * health;
    }

    public void AddKill()
    {
        manager.kills++;
        manager.Check();
    }
}
