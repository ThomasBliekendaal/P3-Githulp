using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_GridPuzzle : Item {
    public RaycastHit hit;
    public bool enabledd;
	// Use this for initialization
	void Start () {
        gameObject.GetComponentInParent<MH_GridChecker>().grid.Add(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact(GameObject target)
    {
        if (enabledd)
        {
            enabledd = false;
            gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        }
        else
        {
            enabledd = true;
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
        gameObject.GetComponentInParent<MH_GridChecker>().CheckGrid();
        Physics.Raycast(transform.position, -transform.right, out hit, 10);
        if (hit.transform != null)
        {
            if (hit.transform.gameObject.tag == "Interactable")
            {
                if (hit.transform.gameObject.GetComponent<MH_GridPuzzle>().enabledd)
                {
                    enabledd = false;
                    hit.transform.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
                }
                else
                {
                    enabledd = true;
                    hit.transform.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
            }
        }
        Physics.Raycast(transform.position, transform.up, out hit, 10);
        if (hit.transform != null)
        {
            if (hit.transform.gameObject.tag == "Interactable")
            {
                if (hit.transform.gameObject.GetComponent<MH_GridPuzzle>().enabledd)
                {
                    enabledd = false;
                    hit.transform.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
                }
                else
                {
                    enabledd = true;
                    hit.transform.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
            }
        }
        Physics.Raycast(transform.position, -transform.up, out hit, 10);
        if (hit.transform != null)
        {
            if (hit.transform.gameObject.tag == "Interactable")
            {
                if (hit.transform.gameObject.GetComponent<MH_GridPuzzle>().enabledd)
                {
                    enabledd = false;
                    hit.transform.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
                }
                else
                {
                    enabledd = true;
                    hit.transform.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
            }
        }
        Physics.Raycast(transform.position, transform.right, out hit, 10);
        if (hit.transform != null)
        {
            if (hit.transform.gameObject.tag == "Interactable")
            {
                if (hit.transform.gameObject.GetComponent<MH_GridPuzzle>().enabledd)
                {
                    enabledd = false;
                    hit.transform.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
                }
                else
                {
                    enabledd = true;
                    hit.transform.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
            }
        }
    }
}
