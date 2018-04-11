using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_HallStand : MonoBehaviour {
    public bool canSpawnNewText;
    private bool firstTime = true;
    public bool enabledd;
    public string[] dialog;
    public string nameOf;
    public GameObject dialogText;
    public GameObject dialogMenu;
    public GameObject dialogName;
    public int current;
    public float delay;
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
                    GameObject.FindWithTag("Player").GetComponent<Player>().moveSpeed = 50;
                    enabledd = false;
                    current = 0;
                    firstTime = true;
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
            GameObject.FindWithTag("Player").GetComponent<Player>().moveSpeed = 0;
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
