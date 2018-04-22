using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeAudioChange : MonoBehaviour
{

    void Update()
    {
        if (GameObject.FindWithTag("AudioChange").GetComponent<BoxCollider>().enabled == true)
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
        }
        if (GameObject.FindWithTag("AudioChange").GetComponent<BoxCollider>().enabled == false)
        {
            gameObject.GetComponent<AudioSource>().enabled = false;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        gameObject.GetComponent<AudioSource>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        GameObject.FindWithTag("AudioChange").GetComponent<BoxCollider>().enabled = true;
    }
}