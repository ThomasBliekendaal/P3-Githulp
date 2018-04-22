using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TempLoadMan : MonoBehaviour {
    public GameObject[] buttons;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Medieval()
    {
        SceneManager.LoadScene(4);
    }
    public void Dungeon()
    {
        SceneManager.LoadScene(3);
    }
    public void Steampunk()
    {
        SceneManager.LoadScene(2);
    }
    public void Nordic()
    {
        SceneManager.LoadScene(5);
    }
    public void Gothic()
    {
        SceneManager.LoadScene(6);
    }
    public void Space()
    {
        SceneManager.LoadScene(7);
    }

}
