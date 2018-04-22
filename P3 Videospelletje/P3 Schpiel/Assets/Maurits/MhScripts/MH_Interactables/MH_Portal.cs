using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MH_Portal : MonoBehaviour {
    public bool unlocked;
    public string loadSceneName;
    public GameObject particles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player" && unlocked)
        {
            GameObject.FindGameObjectWithTag("StatSaver").GetComponent<StatManager>().AddPendant(5);
            SceneManager.LoadScene("loadSceneName");
        }
    }
    public void GotKey()
    {
        unlocked = true;
        if(particles != null)
        {
            particles.GetComponent<ParticleSystem>().Play();
        }
    }
}
