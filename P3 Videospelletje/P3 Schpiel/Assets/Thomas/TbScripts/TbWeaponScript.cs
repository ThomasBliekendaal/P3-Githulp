using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TbWeaponScript : MonoBehaviour {
    public float damage;
    public float manaUsage;
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
    public GameObject cube;


	
    public void Fire()
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

    void ShootBullet()
    {
        GameObject p = Instantiate(projectile, barrel.position, barrel.rotation);
        p.GetComponent<Rigidbody>().velocity = transform.forward * projectileVel;
        Debug.DrawRay(pCamera.position, transform.forward, Color.red, rayLength);
        if(Physics.Raycast(pCamera.position,pCamera.forward,out hit))
        {
            p.transform.LookAt(hit.point);
        }
    }


    public IEnumerator Rof()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
