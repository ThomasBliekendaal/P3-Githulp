using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TbWeaponScript : MonoBehaviour {
    public float damage;
    public float manaUsage;
    public float altManaUsage;
    public Transform barrel;
    public float fireRate;
    public GameObject projectile;
    public float aoe;
    public bool aoeToggle;
    public float projectileVel;
    public bool raycast;
    public bool canFire = true;
    public Vector3 spread;
    public Transform pCamera;
    public float rayLength;
    public RaycastHit hit;
    public GameObject deathParticle;
    public GameObject manaSource;
    public float currentMana;


    public void Fire()
    {
        if (Input.GetButton("Fire1"))
        {
            if (currentMana >= 1)
            {
                if (canFire)
                {
                    manaSource.GetComponent<TbMovementScript>().Use(manaUsage);
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
        //Debug.DrawRay(pCamera.position, transform.forward, Color.red, rayLength);
        if(Physics.Raycast(pCamera.position,pCamera.forward,out hit))
        {
            p.transform.LookAt(hit.point);
        }
    }
    public void SpawnParticle()
    {
        GameObject g = Instantiate(deathParticle, hit.point, transform.rotation);
        Destroy(g, 1);
    }


    public IEnumerator Rof()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
