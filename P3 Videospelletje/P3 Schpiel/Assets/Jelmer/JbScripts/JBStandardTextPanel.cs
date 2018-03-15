using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JBStandardTextPanel : MonoBehaviour {
    public Text talkerName;
    public Text textPanel;
    public string inputText;
    public string inputName;
    public bool start;
    public bool active;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(start == true)
        {
            if(active == false)
            {
                start = false;
                StopCoroutine(StartInuput());
                StartCoroutine(StartInuput());
                active = true;
            }
        }
	}
    public IEnumerator StartInuput()
    {
        textPanel.text = "";
        talkerName.text = inputName;
        foreach (char letter in inputText.ToCharArray())
        {
            textPanel.text += letter;
            yield return null;
        }
        active = false;
    }
}
