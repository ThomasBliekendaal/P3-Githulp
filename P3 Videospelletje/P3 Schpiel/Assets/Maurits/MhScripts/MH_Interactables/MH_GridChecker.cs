using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_GridChecker : MonoBehaviour {
    public List<GameObject> grid = new List<GameObject>();
    private bool canOpen;
    private bool opened;
    public GameObject door;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CheckGrid()
    {
        if(opened == false)
        {
            canOpen = true;
            for (int i = 0; i < grid.Count; i++)
            {
                if (grid[i].GetComponent<MH_GridPuzzle>().enabledd == false)
                {
                    canOpen = false;
                }
            }
            if (canOpen)
            {
                for (int i = 0; i < grid.Count; i++)
                {
                    grid[i].GetComponentInChildren<ParticleSystem>().Play();
                }
                Open();
            }
        }
    }
    public void Open()
    {
        opened = true;
        door.GetComponent<Animation>().Play("MH_OpenGridDoor");
    }
}
