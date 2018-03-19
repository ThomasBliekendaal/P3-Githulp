using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TbWandWep : TbWeaponScript {

	// Use this for initialization
	void Start () {
        canFire = true;
	}
	
	// Update is called once per frame
	void Update () {
        Fire();
	}
}
