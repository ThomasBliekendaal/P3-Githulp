using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_HallStand : MonoBehaviour {
    public bool canSpawnNewText = true;
    private bool firstTime = true;
    public bool enabledd = true;
    public bool openDoor;
    public string[] dialog;
    public string nameOf;
    public GameObject doorDoor;
    public GameObject dialogText;
    public GameObject dialogMenu;
    public GameObject dialogName;
    public int current;
    public float delay = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Interact"))
        {
            delay = 0;
        }
        else
        {
            delay = 0.1f;
        }
        if (Input.GetButtonDown("Interact"))
        {
            if (canSpawnNewText && firstTime == false)
            {
                if (current >= dialog.Length)
                {
                    dialogMenu.SetActive(false);
                    GameObject.FindWithTag("Player").GetComponent<MH_Player>().canMove = true;
                    enabledd = false;
                    current = 0;
                    firstTime = true;
                    if (openDoor)
                    {
                        doorDoor.GetComponent<Animation>().Play("MH_LastPuzzleDoorOpen");
                    }
                }
                if (enabledd)
                {
                    StartCoroutine(Typewriter());
                    canSpawnNewText = false;
                }
            }
        }
	}
    public void OnTriggerEnter(Collider hit)
    {
        if (canSpawnNewText && enabledd && firstTime)
        {
            GameObject.FindWithTag("Player").GetComponent<MH_Player>().canMove = false;
            firstTime = false;
            dialogMenu.SetActive(true);
            dialogName.GetComponent<Text>().text = nameOf;
            StartCoroutine(Typewriter());
            canSpawnNewText = false;
        }
    }
    public IEnumerator Typewriter()
    {
        dialogText.GetComponent<Text>().text = null;
        for(int i = 0; i < dialog[current].Length; i++)
        {
            dialogText.GetComponent<Text>().text += dialog[current][i];
            yield return new WaitForSeconds(delay);
        }
        current++;
        canSpawnNewText = true;
    }
}
