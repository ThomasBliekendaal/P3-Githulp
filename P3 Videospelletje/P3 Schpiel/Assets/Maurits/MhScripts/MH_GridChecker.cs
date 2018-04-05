using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_GridChecker : MonoBehaviour {
    public List<GameObject> grid = new List<GameObject>();
    public bool canOpen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CheckGrid()
    {
        canOpen = true;
        for(int i = 0; i < grid.Count; i++)
        {
            if(grid[i].GetComponent<MH_GridPuzzle>().enabledd == false)
            {
                canOpen = false;
            }
        }
        if (canOpen)
        {
            for(int i = 0; i < grid.Count; i++)
            {
                grid[i].GetComponentInChildren<ParticleSystem>().Play();
            }
            Open();
        }
    }
    public void Open()
    {
        print("Hi");
    }
}
