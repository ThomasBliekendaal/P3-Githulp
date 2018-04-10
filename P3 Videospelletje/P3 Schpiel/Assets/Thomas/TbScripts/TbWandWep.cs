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
        Debug.DrawRay(pCamera.position, transform.forward, Color.red, rayLength);
        if (Physics.Raycast(pCamera.position, pCamera.forward, out hit))
        {
            cube.transform.position = hit.point;
            barrel.transform.LookAt(cube.transform.position);
            //cube.transform.position = hit.point;
        }
        Fire();
	}
}
