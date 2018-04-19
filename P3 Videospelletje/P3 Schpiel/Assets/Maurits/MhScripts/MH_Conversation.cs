using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_Conversation : MH_Item
{// inherits the reactions from afterInteract
    public string[] npcResponse;
    public string[] playerAnswersYes;
    public string[] playerAnswersNo;
    public string npcName;
    public bool isOpen;
    public bool canReset;
    public int responseVal = 1;
    public float delay;
    public GameObject convUI;
    public GameObject dialogName;
    public GameObject dialogText;
    public GameObject[] answerOpt;
    public GameObject plaayer;
    // Use this for initialization

    public override void Interact(GameObject interactor) // What happens when you interact
    {
        if (isOpen == false)// checks if it is the first interact after talking.
        {
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(Typewriter());
            plaayer = GameObject.FindGameObjectWithTag("Player");
            dialogName.GetComponent<Text>().text = npcName;
            convUI.SetActive(true);
            isOpen = true;
        }
    }
    public IEnumerator Typewriter()
    {
        dialogText.GetComponent<Text>().text = null; // makes text empty
        for (int i = 0; i < npcResponse[responseVal].Length; i++) // loops for every index of a string
        {
            dialogText.GetComponent<Text>().text += npcResponse[responseVal][i]; // adds the current index of the string to the text
            yield return new WaitForSeconds(delay); // time you have to wait before it loops again
        }
        answerOpt[0].GetComponentInChildren<Text>().text = playerAnswersYes[responseVal]; // Sets the response for yes
        answerOpt[1].GetComponentInChildren<Text>().text = playerAnswersNo[responseVal]; // Sets the response for no
        for (int i = 0; i < answerOpt.Length; i++) // Sets the options active
        {
            answerOpt[i].SetActive(true);
        }
    }
    public void Answer(bool answer)
    {
        for (int i = 0; i < answerOpt.Length; i++) // Sets the options off
        {
            answerOpt[i].SetActive(false);
        }
        if (responseVal < npcResponse.Length / 2) // Checks if it isn't from the last answer row
        {
            if (answer)
            {
                responseVal *= 2;
            }
            else
            {
                responseVal = (responseVal * 2) + 1;
            }
            Next(); // Interats again
        }
        else // if it is from the last answer row
        {
            if (answer)
            {
                responseVal *= 2;
            }
            else
            {
                responseVal = (responseVal * 2) + 1;
            }
            UseEffect();
            responseVal = 1; // resets the response for playback
            convUI.SetActive(false);// sets off the UI
            if (canReset)
            {
                isOpen = false; // makes the UI able to turn back on again
            }
            plaayer.GetComponent<MH_Player>().canInteract = true; // player can interact again
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public virtual void UseEffect()
    {

    }
    public void Next()
    {
        StartCoroutine(Typewriter());
    }
}
