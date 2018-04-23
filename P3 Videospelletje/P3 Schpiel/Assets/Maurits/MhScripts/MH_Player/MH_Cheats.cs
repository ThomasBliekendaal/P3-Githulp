using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_Cheats : MonoBehaviour {
    public Vector3 tpPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cheat"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = tpPos;
        }
        if (Input.GetButtonDown("Cheat1"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<MH_Player>().maxHealth = 1000000;
            GameObject.FindGameObjectWithTag("Player").GetComponent<MH_Player>().health = 1000000;
        }
	}
}
