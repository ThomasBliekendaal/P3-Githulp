using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_PuzzleTile : MonoBehaviour {
    public bool pressed;
	// Use this for initialization
	void Start () {
        gameObject.GetComponentInParent<MH_TileCheck>().tiles.Add(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            if (pressed)
            {
                gameObject.GetComponentInParent<MH_TileCheck>().ResetTiles();
            }
            else
            {
                pressed = true;
                gameObject.GetComponentInParent<MH_TileCheck>().CheckTiles();
            }
        }
    }
}
