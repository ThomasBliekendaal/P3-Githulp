using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public GameObject[] Weapons;

    public int cur;

    public void Start()
    {

    }

    public void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            cur += 1;
            SwitchWeapons();
        }
    }

    public void SwitchWeapons()
    {
        foreach (GameObject weapon in Weapons)
        {
            weapon.SetActive(false);
            if (weapon == Weapons[cur])
            {
                weapon.SetActive(true);
            }

            if (cur > 2)
            {
                cur = 0;
            }
        }
    }
}
