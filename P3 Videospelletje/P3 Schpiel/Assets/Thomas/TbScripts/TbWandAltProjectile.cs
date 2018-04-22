using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TbWandAltProjectile : TbWandWep {
    public Transform bottomBarrel;
    public bool floorcheck = false;
   
    // Use this for initialization
    void Start () {
        pCamera = GameObject.FindGameObjectWithTag("Pcamera").transform;        
        manaSource = GameObject.FindGameObjectWithTag("Player");
        
    }
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, Time.deltaTime, 0, Space.World);
        barrel.LookAt(hit.point);
        currentMana = manaSource.GetComponent<TbMovementScript>().mana;
        Fire();

        Debug.DrawRay(bottomBarrel.position, Vector3.down, Color.red, 1);
        Ray floorFinder = new Ray(bottomBarrel.position, Vector3.down);
        if (!floorcheck)
        {
            gameObject.transform.Translate(Vector3.down * 0.1f);
            if (Physics.Raycast(floorFinder, out hit, 1) && hit.collider.tag == "Floor")
            {
                floorcheck = true;
            }
        }
    }
}
