using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrMoonBladeMan : MonoBehaviour
{

    public DrWeaponTemplate weapon;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            weapon.animation.SetBool("MBAttack", true);
            weapon.attacking = true;
        }
        else
        {
            weapon.animation.SetBool("MBAttack", false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == ("Enemy"))
        {
            if (weapon.attacking == true)
            {
                other.GetComponent<DrEnemyMaster>().TakeDamage(weapon.DMG);
                weapon.attacking = false;
            }
        }
    }
}
