using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TbWandWep : TbWeaponScript {
    public GameObject altProjectile;

	// Use this for initialization
	void Start () {
        canFire = true;
	}
	
	// Update is called once per frame
	void Update () {
        Fire();
        AltFire();
        currentMana = manaSource.GetComponent<TbMovementScript>().mana;
    }
    public void AltFire()
    {
        if (currentMana >= 1)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                GameObject ap = Instantiate(altProjectile, barrel.position, altProjectile.transform.rotation);
                Destroy(ap, 5f);
                manaSource.GetComponent<TbMovementScript>().Use(altManaUsage);
            }

        }
    }
}       