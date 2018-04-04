using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_CodeLock : MonoBehaviour {
    public GameObject code;
    public GameObject enteredCode;
    public GameObject codeUI;
    public int solution;
    public string convSol;
    private bool canInteract = true;
	// Use this for initialization
	void Start () {
        solution = Random.Range(1000, 99999);
        convSol = solution.ToString();
        code.GetComponent<Text>().text = solution.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Interact()
    {
        codeUI.SetActive(true);
    }
    public void CheckCode()
    {
        if (canInteract)
        {
            if (convSol == enteredCode.GetComponent<Text>().text)
            {
                Open();
            }
            else
            {
                enteredCode.GetComponent<Text>().text = "WRONG";
                canInteract = false;
                StartCoroutine(Wait());
            }
        }
    }
    public void Open()
    {
        enteredCode.GetComponent<Text>().text = "unlocked";
        canInteract = false;
        StartCoroutine(Unlock());
    }
    public void CloseUI()
    {
        codeUI.SetActive(false);
        RemoveNum();
    }
    public void EnterNum(string number)
    {
        if(enteredCode.GetComponent<Text>().text.Length < 7)
        {
            enteredCode.GetComponent<Text>().text += number;
        }
    }
    public void RemoveNum()
    {
        if (canInteract)
        {
            enteredCode.GetComponent<Text>().text = null;
        }
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        canInteract = true;
        RemoveNum();
    }
    public IEnumerator Unlock()
    {
        yield return new WaitForSeconds(1);
        RemoveNum();
        codeUI.SetActive(false);
        print("Hi");
    }
}
