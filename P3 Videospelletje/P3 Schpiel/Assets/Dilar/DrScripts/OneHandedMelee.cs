using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHandedMelee : MonoBehaviour
{

    public Animator animation;

    public int DMG;

    public bool attacking;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            animation.SetBool("OneH-Attack", true);
            attacking = true;
        }
        else
        {
            animation.SetBool("OneH-Attack", false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == ("Enemy"))
        {
            if (attacking == true)
            {
                other.GetComponent<DrEnemyMaster>().TakeDamage(DMG);
                attacking = false;
            }
        }
    }
}
