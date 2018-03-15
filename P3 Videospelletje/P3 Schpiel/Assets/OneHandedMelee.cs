using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHandedMelee : MonoBehaviour
{
    public Animator animator;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("ItWorks");
            animator.SetBool("MBAttack", true);
            animator.SetBool("MBAttack", false);
        }
    }
}
