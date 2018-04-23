using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SePlayer : MonoBehaviour
{
    public int hp;

    public void LoseHP(int dmg)
    {
        hp -= dmg;
        if (hp == 0)
        {
            gameObject.transform.position = GameObject.Find("Spawn").transform.position;
            hp = 3;
        }
    }
}