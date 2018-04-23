using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeWrench : MonoBehaviour
{

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            c.gameObject.GetComponent<SeEnemy>().LoseHP(1);
        }
    }
}