using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_CannonBall : MH_BossAbility {
    public GameObject explosionParticle;
    public GameObject target;
    public Vector3 movePos;
    public float moveSpeed;
	// Use this for initialization
	void Start () {
        transform.LookAt(target.transform);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(movePos * moveSpeed * Time.deltaTime);
	}
    public void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            DealDmg(Random.Range(20, 51), hit.gameObject);
            GameObject explosion = Instantiate(explosionParticle, hit.gameObject.transform.position, Quaternion.identity);
            Destroy(explosion, 3);
            Destroy(gameObject);
        }
    }
}
