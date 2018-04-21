using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
    public string sceneName;
	// Use this for initialization
	void Start () {
        SceneManager.LoadScene(sceneName);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("StatSaver"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
