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
            Disable();
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
        active = true;
        StartCoroutine(StartInput(inputText));
    }

    public void Disable()
    {
        panel.SetActive(false);
        active = false;
    }
}
