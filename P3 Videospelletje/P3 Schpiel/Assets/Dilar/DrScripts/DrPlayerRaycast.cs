using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrPlayerRaycast : MonoBehaviour
{

    public RaycastHit hit;
    public RaycastHit interactable;
    public Transform camPos;

    public int dmg = 10;
    public int range = 25;
    public int iRange = 2;

    public GameObject interactPrompt;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        if (Physics.Raycast(camPos.transform.position, camPos.transform.forward, out hit, range))
        {
            DrEnemyMaster mark = hit.transform.GetComponent<DrEnemyMaster>();
            if (mark != null)
            {
                mark.TakeDamage(dmg);
            }
            Debug.Log(hit.transform.name);
        }
    }

    public void Interact()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, out interactable, iRange))
        {

        }
    }
}
