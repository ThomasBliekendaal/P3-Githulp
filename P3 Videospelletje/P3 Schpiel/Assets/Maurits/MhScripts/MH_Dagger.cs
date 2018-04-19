using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_Dagger : MonoBehaviour {
    public bool canSwing;
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
    public IEnumerator Cooldown()
    {
        canSwing = false;
        yield return new WaitForSeconds(1.5f);
        canSwing = true;
    }
}
