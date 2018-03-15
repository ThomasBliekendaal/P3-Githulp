using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JBStandardTextPanel : MonoBehaviour {
    public Text talkerName;
    public Text textPanel;
    public string inputName;
    public string[] inputText;
    public bool start;
    public bool active;
    public int current;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(start == true)
        {
            start = false;
            if (active == false)
            {
                if(current <= inputText.Length - 1)
                {
                    StopCoroutine(StartInuput());
                    StartCoroutine(StartInuput());
                    active = true;
                }
                else
                {
                    current = 0;
                    StopCoroutine(StartInuput());
                    StartCoroutine(StartInuput());
                    active = true;
                }
            }
        }
	}

    public IEnumerator StartInuput()
    {
        textPanel.text = "";
        talkerName.text = inputName;
        foreach (char letter in inputText[current].ToCharArray())
        {
            textPanel.text += letter;
            yield return null;
        }
        current += 1;
        active = false;
    }
}
