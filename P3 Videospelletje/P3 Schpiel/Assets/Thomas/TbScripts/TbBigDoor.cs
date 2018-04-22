using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TbBigDoor : TbInteractables {
    public GameObject doorLeft;
    public GameObject doorRight;
    public bool doorOpen;

	// Use this for initialization
	void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        if (interacted == true)
        {
            if (doorOpen == false)
            {
                doorLeft.transform.Rotate(0, -90, 0, Space.World);
                doorRight.transform.Rotate(0, 90, 0, Space.World);
                doorLeft.GetComponent<TbBigDoor>().doorOpen = true;
                doorRight.GetComponent<TbBigDoor>().doorOpen = true;
                doorLeft.GetComponent<TbBigDoor>().interacted = true;
                doorRight.GetComponent<TbBigDoor>().interacted = true;
            }
            else
            {

            }
        }
        else
        {
            doorLeft.transform.Rotate(0, 0, 0, Space.World);
            doorRight.transform.Rotate(0, 180, 0, Space.World);
        }
	}
}
