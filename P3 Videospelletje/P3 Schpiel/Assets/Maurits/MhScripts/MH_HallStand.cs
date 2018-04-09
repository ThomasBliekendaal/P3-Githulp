using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_HallStand : MonoBehaviour {
    public bool canSpawnNewText;
    public GameObject textBox;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerStay(Collider hit)
    {
        if (canSpawnNewText)
        {
            Delay(1);
        }
    }
    public IEnumerator Delay(float wait)
    {
        yield return new WaitForSeconds(wait);
    }
}
