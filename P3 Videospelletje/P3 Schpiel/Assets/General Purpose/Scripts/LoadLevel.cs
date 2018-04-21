using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
    public string sceneName;
    public bool firstLevel;
	// Use this for initialization
	void Start () {
        if (firstLevel)
        {
            SceneManager.LoadScene(sceneName);
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("StatSaver"));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
