using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrFlintlock : MonoBehaviour
{

    public RaycastHit hit;
    public Transform camPos;
    public Animator weaponPositionL;

    public GameObject blood;

    public int dmg = 10;
    public int range = 25;

    public bool mayFire = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (mayFire == true)
            {
                weaponPositionL.SetBool("FlintlockShot", true);
                Shoot();
                mayFire = false;
            }
        }
        else
        {
            weaponPositionL.SetBool("FlintlockShot", false);
        }
    }

    private void Shoot()
    {
        StartCoroutine(FireRate());

        if (Physics.Raycast(camPos.transform.position, camPos.transform.forward, out hit, range))
        {
            DrEnemyMaster mark = hit.transform.GetComponent<DrEnemyMaster>();
            if (mark != null)
            {
                mark.TakeDamage(dmg);
                GameObject g = Instantiate(blood, hit.point, Quaternion.identity, hit.transform);
                Destroy(g, 2);
            }
        }
    }

    public IEnumerator FireRate()
    {
        yield return new WaitForSeconds(0.7f);
        mayFire = true;
    }
}
