using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_Key : MH_Item {
    public string[] texts;
    public string namee;
    public int current;
    public float delay;
    public bool textDone;
    public bool disabled;
    public GameObject conUI;
    public GameObject convText;
    public GameObject convName;
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
            if(disabled == false)
            {
                if (textDone)
                {
                    if (current >= texts.Length)
                    {
                        conUI.SetActive(false);
                        disabled = true;
                        interactor.GetComponent<MH_Player>().canInteract = true;
                    }
                    else
                    {
                        StartCoroutine(Dialog());
                        textDone = false;
                    }
                }
            }
        }
	}
    public IEnumerator Dialog()
    {
        convText.GetComponent<Text>().text = null;
        for(int i = 0; i < texts[current].Length; i++)
        {
            convText.GetComponent<Text>().text += texts[current][i];
            yield return new WaitForSeconds(delay);
        }
        textDone = true;
        current++;
    }
    public override void Interact(GameObject target)
    {
        if(disabled == false)
        {
            interactor = target;
            target.GetComponent<MH_Player>().hasKey = true;
            conUI.SetActive(true);
            convName.GetComponent<Text>().text = namee;
            StartCoroutine(Dialog());
        }
        else
        {
            target.GetComponent<MH_Player>().canInteract = true;
        }
    }
}
