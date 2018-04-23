using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MrTeleportScript : MonoBehaviour {
    public MrNordicAxeScript script;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (script.win == true)
        {
            meh();
        }
	}

    public void meh ()
    {
        GameObject.FindGameObjectWithTag("StatSaver").GetComponent<StatManager>().AddPendant(4);
        SceneManager.LoadScene("HubWorld");
    }
}
