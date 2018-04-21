using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_CastleBoss : MonoBehaviour {
    public GameObject moltenStuff;
    public GameObject cannonBall;
    public GameObject target;
    public GameObject bossDoor;
    public GameObject bossKey;
    public Vector3 posit;
    public Vector3 moltenStuffScaler;
    public bool activated;
    public bool canAttack;
    public int health;
    private List<IEnumerator> attacks = new List<IEnumerator>();
	// Use this for initialization
	void Start () {
        attacks.Add(MoltenStuff());
        attacks.Add(CannonBalls());
	}
	
	// Update is called once per frame
	void Update () {
        if (activated)
        {
            transform.LookAt(target.transform);
            if (canAttack)
            {
                print("Attacked");
                canAttack = false;
                StartCoroutine(attacks[Random.Range(0, attacks.Count)]);
            }
        }
		
	}
    public void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == ("Player") && activated == false)
        {
            bossDoor.GetComponent<MH_BossDoor>().unlocked = false;
            bossDoor.GetComponent<Animation>().Play("MH_BossWallClose");
            activated = true;
            target = hit.gameObject;
            Destroy(gameObject.GetComponent<SphereCollider>());
        }
    }
    public void Death()
    {
        posit = target.transform.position;
        posit.y -= 2.5f;
        Instantiate(bossKey, posit, Quaternion.identity);
        bossDoor.GetComponent<MH_BossDoor>().unlocked = true;
        Destroy(gameObject);
    }
    public IEnumerator MoltenStuff()
    {
        posit = gameObject.transform.position;
        posit.y = 0.4f;
        GameObject g = Instantiate(moltenStuff, posit, Quaternion.identity);
        for(int i = 0; i < Random.Range(30, 51); i++)
        {
            yield return new WaitForSeconds(0.03f);
            g.transform.localScale += moltenStuffScaler;
        }
        yield return new WaitForSeconds(2);
        for (int i = 0; i < Random.Range(30, 51); i++)
        {
            yield return new WaitForSeconds(0.03f);
            g.transform.localScale -= moltenStuffScaler;
        }
        StartCoroutine(Cooldown());
        Destroy(g);
    }
    public IEnumerator CannonBalls()
    {
        posit = gameObject.transform.position;
        posit.z += 3;
        for(int i = 0; i < Random.Range(3,6); i++)
        {
            GameObject g = Instantiate(cannonBall, posit, Quaternion.identity);
            g.GetComponent<MH_CannonBall>().target = target;
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(Cooldown());
    }
    public IEnumerator Cooldown()
    {
        print("CD");
        if(Random.Range(1, 7) == 3)
        {
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            yield return new WaitForSeconds(3);
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
        CanAttack();
    }
    public void CanAttack()
    {
        canAttack = true;
    }
}
