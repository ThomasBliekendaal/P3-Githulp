using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_Dagger : MonoBehaviour {
    public GameObject damageShow;
    public Vector3 damagePos;
    public bool canSwing;
    public bool damaged;
    public int damage;
    public int critChance;
    public int critDmgMultiplier;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canSwing)
            {
                StartCoroutine(Cooldown());
                gameObject.GetComponent<Animation>().Play("MH_SwingSword");
            }
        }
	}
    public void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject.tag == "Enemy" && canSwing == false && damaged == false && hit.gameObject.GetComponent<MH_CastleBoss>().activated)
        {
            hit.gameObject.GetComponent<MH_CastleBoss>().health -= CalculateDmg(Random.Range(10, 21));
            StartCoroutine(ShowDmg(hit.gameObject));
            damaged = true;
            if(hit.gameObject.GetComponent<MH_CastleBoss>().health <= 0)
            {
                hit.gameObject.GetComponent<MH_CastleBoss>().Death();
            }
        }
    }
    public IEnumerator Cooldown()
    {
        canSwing = false;
        yield return new WaitForSeconds(gameObject.GetComponent<Animation>().GetClip("MH_SwingSword").length);
        canSwing = true;
        if (damaged)
        {
            damaged = false;
        }
    }
    public IEnumerator ShowDmg(GameObject damagedObject)
    {
        damagePos = damagedObject.transform.position;
        damagePos.y += 2;
        damageShow.transform.position = damagePos;
        damageShow.SetActive(true);
        damageShow.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        yield return new WaitForSeconds(1);
        damageShow.SetActive(false);
    }
    public int CalculateDmg(int dmgAmt)
    {
        damage = dmgAmt;
        if(Random.Range(1, 101) <= critChance)
        {
            damage *= critDmgMultiplier;
            damageShow.GetComponent<Text>().color = Color.red;
        }
        else
        {
            damageShow.GetComponent<Text>().color = Color.white;
        }
        damageShow.GetComponent<Text>().text = damage.ToString();
        return damage;
    }
}
