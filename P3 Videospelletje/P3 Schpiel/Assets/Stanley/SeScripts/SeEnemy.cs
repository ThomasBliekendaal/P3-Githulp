using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeEnemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform barrel;
    public Transform player;
    public bool fire;
    public List<Rigidbody> idk;

	void Start ()
    {
        gameObject.GetComponent<SeEnemy>().enabled = false;
        fire = true;
	}
	
	void Update ()
    {
        transform.LookAt(player);
        if (fire == true)
        {
            GameObject G = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
            Destroy(G, 5);
            fire = false;
            StartCoroutine(Transo());
        }
    }

    IEnumerator Transo()
    {
        yield return new WaitForSeconds(0.3f);
        fire = true;
    }

    public void Mhhhhhmmmmm()
    {
        Collider[] tea = Physics.OverlapSphere(transform.position, 3);
        foreach (Collider NearbyObject in tea)
        {
            if (NearbyObject.GetComponent<Rigidbody>())
            {
                Rigidbody rb = NearbyObject.GetComponent<Rigidbody>();
                rb.AddExplosionForce(1000, transform.position, 1000);
            }
        }
    }
}