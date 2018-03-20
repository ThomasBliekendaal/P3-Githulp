using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHandedMelee : MonoBehaviour
{
    public Animator weaponHolder;

    public bool moonblade;
    public bool attacking;

    public int dmg;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moonblade == true)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                weaponHolder.SetBool("MBAttack", true);
                attacking = true;
            }
            else
            {
                weaponHolder.SetBool("MBAttack", false);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == ("Enemy"))
        {
            if (attacking == true)
            {
                other.GetComponent<DrEnemyMaster>().TakeDamage(dmg);
                attacking = false;
            }
        }
    }
}
