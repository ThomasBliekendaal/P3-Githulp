using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeAudioChange2 : MonoBehaviour
{

    void Update()
    {
        if (GameObject.FindWithTag("AudioChange2").GetComponent<BoxCollider>().enabled == true)
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
        }
        if (GameObject.FindWithTag("AudioChange2").GetComponent<BoxCollider>().enabled == false)
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            GameObject.FindWithTag("AudioChange2").GetComponent<BoxCollider>().enabled = true;
        }
    }
}