using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_CodeLock : MonoBehaviour {
    public GameObject code;
    public GameObject codeUI;
    public int solution;
    public string convSol;
	// Use this for initialization
	void Start () {
        solution = Random.Range(1000, 99999);
        convSol = solution.ToString();
        code.GetComponent<TextMesh>().text = solution.ToString();
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
        solution.ToString();
        if (convSol == codeUI.GetComponentInChildren<Text>().text)
        {
            Open();
        }
    }
    public void Open()
    {
        print("Hi");
    }
    public void CloseUI()
    {

    }
}
