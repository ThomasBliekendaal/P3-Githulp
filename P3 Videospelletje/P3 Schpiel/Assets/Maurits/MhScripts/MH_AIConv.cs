using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_AIConv : MH_Conversation
{
    public GameObject endBossDoor;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))// This is for speeding up the text if you hold your left mousebutton
        {
            delay = 0; // makes text fast
        }
        else
        {
            delay = 0.1f; // makes text normal again
        }
    }
    public override void UseEffect()
    {
        Effect(responseVal); //plays the effect from AfterInteract
    }
    public void Effect(int val)
    {
        switch (val)
        {
            case 16:
                print("Hi");
                break;
            case 17:
                print("Hi");
                break;
            case 18:
                print("Hi");
                break;
            case 19:
                print("Hi");
                break;
            case 20:
                print("Hi");
                break;
            case 21:
                print("Hi");
                break;
            case 22:
                print("Hi");
                break;
            case 23:
                print("Hi");
                break;
            case 24:
                print("Hi");
                break;
            case 25:
                print("Hi");
                break;
            case 26:
                print("Hi");
                break;
            case 27:
                print("Hi");
                break;
            case 28:
                print("Hi");
                break;
            case 29:
                print("Hi");
                break;
            case 30:
                print("Hi");
                break;
            case 31:
                print("Hi");
                break;
        }
    }
}
