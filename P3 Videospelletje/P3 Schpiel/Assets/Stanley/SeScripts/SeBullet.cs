using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeBullet : MonoBehaviour
{
    public Vector3 m;
    public Collider boi;

    void Start()
    {
        boi = GetComponent<Collider>();
        StartCoroutine(Girlo());
    }

    void Update()
    {
        transform.Translate(m * Time.deltaTime);
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            c.gameObject.GetComponent<SePlayer>().LoseHP(1);
        }
        Destroy(gameObject);
    }

    IEnumerator Girlo()
    {
        boi.isTrigger = true;
        yield return new WaitForSeconds(0.3f);
        boi.isTrigger = false;
    }
}