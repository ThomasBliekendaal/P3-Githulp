using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JBMelleEnemy : JBEnemy {

    public bool start;
    public JBWeaponSwing weapon;
    public bool bleh;

    void Start()
    {
        SetPlayer();
    }

    public void Update()
    {
        Health();
        if (start)
        {
            Move();
        }
        if (!bleh && start)
        {
            StartCoroutine(AttackTimer());
            bleh = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            start = true;

        }
    }

    public override void Attack()
    {
        weapon.start = true;
    }
}
