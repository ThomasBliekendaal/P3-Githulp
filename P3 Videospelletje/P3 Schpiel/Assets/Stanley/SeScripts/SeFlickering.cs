﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeFlickering : MonoBehaviour
{
    public GameObject[] lights;

    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("Light");
        StartCoroutine(Boio());
    }

    public IEnumerator Boio()
    {
        for(int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }
        yield return new WaitForSeconds(Random.Range(0, 3));
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].SetActive(true);
        }
        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(Boio());
    }
}