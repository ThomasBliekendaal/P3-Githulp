using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_TileCheck : MonoBehaviour {
    public List<GameObject> tiles = new List<GameObject>();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ResetTiles()
    {

    }
    public void OpenGate()
    {

    }
    public void CheckTiles()
    {
        for(int i = 0; i < tiles.Count; i++)
        {
            if(tiles[i].GetComponent<MH_PuzzleTile>().pressed != true)
            {
                return;
            }
            OpenGate();
        }
    }
}
