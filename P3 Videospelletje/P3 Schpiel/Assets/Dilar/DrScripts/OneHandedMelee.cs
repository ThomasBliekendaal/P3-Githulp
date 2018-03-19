using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHandedMelee : MonoBehaviour
{
    public Animator animator;

    public int dmg;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("enemy"))
        {
            Debug.Log("Yaf");
            other.gameObject.GetComponent<DrEnemyMaster>().TakeDamage(dmg);
        }
    }
}
