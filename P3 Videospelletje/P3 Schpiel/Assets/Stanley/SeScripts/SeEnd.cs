using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeEnd : MonoBehaviour
{
    public GameObject endScreen;

	void Start ()
    {
        endScreen.SetActive(false);
    }

    void OnCollisionEnter(Collision c)
    {
        endScreen.SetActive(true);
        GameObject.FindGameObjectWithTag("StatSaver").GetComponent<StatManager>().AddPendant(1);
    }
}