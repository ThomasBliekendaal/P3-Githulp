using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_CastleBoss : MonoBehaviour {
    public GameObject moltenStuff;
    public GameObject target;
    public Vector3 posit;
    public Vector3 moltenStuffScaler;
    public bool activated;
    public bool canAttack;
    private List<IEnumerator> attacks = new List<IEnumerator>();
	// Use this for initialization
	void Start () {
        attacks.Add(MoltenStuff());
        StartCoroutine(MoltenStuff());
	}
	
	// Update is called once per frame
	void Update () {
        if (activated)
        {
            transform.LookAt(target.transform);
        }
		
	}
    public void OnTriggerEnter(Collider hit)
    {
        if(activated == false)
        {
            activated = true;
            target = hit.gameObject;
        }
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
        Destroy(g);
        canAttack = true;
    }
}
