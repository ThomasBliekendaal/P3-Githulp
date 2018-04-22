using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject[] pendants;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < GameObject.FindGameObjectWithTag("StatSaver").GetComponent<StatManager>().gotPendantos.gotPendant.Length; i++)
        {
            if (GameObject.FindGameObjectWithTag("StatSaver").GetComponent<StatManager>().gotPendantos.gotPendant[i] == true)
            {
                pendants[i].SetActive(true);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ResetStats()
    {
        for (int i = 0; i < GameObject.FindGameObjectWithTag("StatSaver").GetComponent<StatManager>().gotPendantos.gotPendant.Length; i++)
        {
            GameObject.FindGameObjectWithTag("StatSaver").GetComponent<StatManager>().gotPendantos.gotPendant[i] = false;
        }
        SceneManager.LoadScene("HubWorld");
    }
}
