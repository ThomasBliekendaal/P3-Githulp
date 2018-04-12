using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_CodeLock : MH_Item {
    public GameObject cursor;
    public GameObject code;
    public GameObject enteredCode;
    public GameObject codeUI;
    public int solution;
    public string convSol;
    private bool canType = true;
    private bool locked = true;
	// Use this for initialization
	void Start () {
        solution = Random.Range(1000, 99999);
        convSol = solution.ToString();
        code.GetComponent<Text>().text = solution.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void Interact(GameObject target)
    {
        if(locked)
        {
            interactor = target;
            cursor.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            codeUI.SetActive(true);
        }
    }
    public void CheckCode()
    {
        if (canType)
        {
            if (convSol == enteredCode.GetComponent<Text>().text)
            {
                Open();
            }
            else
            {
                enteredCode.GetComponent<Text>().text = "WRONG";
                canType = false;
                StartCoroutine(Wait());
            }
        }
    }
    public void Open()
    {
        enteredCode.GetComponent<Text>().text = "unlocked";
        canType = false;
        StartCoroutine(Unlock());
    }
    public void CloseUI()
    {
        codeUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        cursor.SetActive(true);
        interactor.GetComponent<MH_Player>().canInteract = true;
        RemoveNum();
    }
    public void EnterNum(string number)
    {
        if(enteredCode.GetComponent<Text>().text.Length < 7 && canType)
        {
            enteredCode.GetComponent<Text>().text += number;
        }
    }
    public void RemoveNum()
    {
        if (canType)
        {
            enteredCode.GetComponent<Text>().text = null;
        }
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        canType = true;
        RemoveNum();
    }
    public IEnumerator Unlock()
    {
        yield return new WaitForSeconds(1);
        RemoveNum();
        Cursor.lockState = CursorLockMode.Locked;
        cursor.SetActive(true);
        codeUI.SetActive(false);
        locked = false;
        gameObject.GetComponentInChildren<Animation>().Play("MH_PuzzleDoorOpen");
        interactor.GetComponent<MH_Player>().canInteract = true;
    }
}
