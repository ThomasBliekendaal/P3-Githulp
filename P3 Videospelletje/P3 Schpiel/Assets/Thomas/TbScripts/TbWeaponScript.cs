using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TbWeaponScript : MonoBehaviour {
    public float damage;
    public Transform barrel;
    public float fireRate;
    public GameObject projectile;
    public float aoe;
    public bool aoeToggle;
    public float projectileVel;
    public bool auto;
    public bool raycast;
    public bool canFire = true;

	
    public void Fire()
    {
        if (auto == true)
        {
            if (Input.GetButton("Fire1"))
            {
                if (canFire)
                {
                    ShootBullet();
                    canFire = false;
                    StartCoroutine(Rof());
                }
            }
        }
    }

    void ShootBullet()
    {
        GameObject p = Instantiate(projectile, barrel.position, barrel.rotation);
        p.GetComponent<Rigidbody>().velocity = transform.forward * projectileVel;
    }


    public IEnumerator Rof()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
