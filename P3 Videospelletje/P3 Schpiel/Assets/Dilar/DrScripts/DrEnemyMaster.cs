using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrEnemyMaster : MonoBehaviour
{
    public int health;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    public void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
