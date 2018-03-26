using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public GameObject[] meleeWeapons;
    public GameObject[] rangedWeapons;
    public int current;

	// Use this for initialization
	void Start ()
    {
        meleeWeapons = new GameObject[5];
        meleeWeapons = new GameObject[4];
    }
	
	public void WeaponSwitch()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Debug.Log("YESS");
            meleeWeapons[current].SetActive(false);
            meleeWeapons[current++].SetActive(true);
            current++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Debug.Log("REEEE");
            meleeWeapons[current].SetActive(false);
            meleeWeapons[current--].SetActive(true);
            current--;
        }
    }
}
