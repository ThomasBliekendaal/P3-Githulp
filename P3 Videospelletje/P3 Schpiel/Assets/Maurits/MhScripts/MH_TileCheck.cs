using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_TileCheck : MonoBehaviour {
    public List<GameObject> tiles = new List<GameObject>();
    public Vector3 resetPos;
    public GameObject door;
    public bool opened;
    public bool disabled;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ResetTiles()
    {
        if(disabled == false)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = resetPos;
            if (opened)
            {
                door.GetComponent<Animation>().Play("MH_CloseDoorTile");
            }
            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].GetComponent<MH_PuzzleTile>().pressed = false;
            }
        }
    }
    public void OpenGate()
    {
        door.GetComponent<Animation>().Play("MH_OpenDoorTile");
        opened = true;
    }
    public void CheckTiles()
    {
        if(opened == false)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                if (tiles[i].GetComponent<MH_PuzzleTile>().pressed != true)
                {
                    return;
                }
            }
            OpenGate();
        }
    }
}
