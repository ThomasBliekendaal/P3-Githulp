using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JBThoughts : MonoBehaviour {
    public Text textPanel;
    public GameObject panel;

    public bool active;
    public bool nextThing;


    public void Update()
    {
        if (active && Input.GetButtonDown("Jump") && !nextThing)
        {
            panel.SetActive(false);
        }
    }

    public IEnumerator StartInput(string inputText)
    {
        textPanel.text = " ";
        foreach(char letter in inputText.ToCharArray())
        {
            textPanel.text += letter;
            yield return null;
        }
    }

    public void StartIt(string inputText)
    {
        StartCoroutine(StartInput(inputText));
    }
}
