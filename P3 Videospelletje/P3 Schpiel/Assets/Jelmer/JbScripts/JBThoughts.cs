using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JBThoughts : MonoBehaviour {
    public Text textPanel;
    public GameObject panel;
    public JBThoughtInput thought;
    public GameObject info;

    public int current;

    public bool active;
    public bool on;


    public void Update()
    {
        if (on)
        {
            if(current == 0 && !active)
            {
                StartCoroutine(StartInput(thought.text[current]));
                active = true;
            }
            if (Input.GetButtonDown("Jump") && current < thought.text.Length)
            {
                if (!active)
                {
                    StartCoroutine(StartInput(thought.text[current]));
                    active = true;
                }
            }
            else if (Input.GetButtonDown("Jump"))
            {
                panel.SetActive(false);
                on = false;
            }
        }
    }

    public IEnumerator StartInput(string inputText)
    {
        info.SetActive(false);
        textPanel.text = " ";
        foreach (char letter in inputText.ToCharArray())
        {
            textPanel.text += letter;
            yield return null;
        }
        current++;
        active = false;
        info.SetActive(true);
    }

    public void SetNewThought(JBThoughtInput inputThought)
    {
        current = 0;
        thought = inputThought;
        panel.SetActive(true);
        on = true;
    }
}
