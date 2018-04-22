using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrHeroGrave : MonoBehaviour
{

    public Vector3 offset;

    public GameObject pendant;
    public GameObject manager;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(manager.GetComponent<DrEnemySpawner>().kills > 10)
        {
            if (other.transform.tag == ("Player"))
            {
                Instantiate(pendant, transform.position -= offset, Quaternion.identity);
            }
        }
    }
}
