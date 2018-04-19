﻿using System.Collections;
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
        if (Input.GetButton("FastForward")) // This is for speeding up the text if you hold your left mousebutton
        {
            delay = 0;
        }
        else
        {
            delay = 0.1f;
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
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 17:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 18:
                print("Pacifist");
                break;
            case 19:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 20:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 21:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 22:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 23:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 24:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 25:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 26:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 27:
                print("Pacifist");
                break;
            case 28:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 29:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 30:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
            case 31:
                endBossDoor.GetComponent<MH_BossDoor>().unlocked = true;
                break;
        }
    }
}
