using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JBEnemy : MonoBehaviour {
    public Transform player;
    public NavMeshAgent agent;

    public void Move()
    {
        agent.SetDestination(player.position);
    }

	public virtual void Attack()
    {

    }

    public IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(1);
    }
}
