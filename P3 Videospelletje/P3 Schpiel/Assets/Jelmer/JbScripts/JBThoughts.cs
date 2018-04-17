using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JBThoughts : MonoBehaviour {
    public Text textPanel;

    public IEnumerator StartInput(string inputText)
    {
        textPanel.text = " ";
        foreach(char letter in inputText.ToCharArray())
        {
            textPanel.text += letter;
            yield return null;
        }
    }
}
