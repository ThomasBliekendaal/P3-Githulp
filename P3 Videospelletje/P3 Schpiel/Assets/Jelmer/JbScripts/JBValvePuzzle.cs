using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBValvePuzzle : JBInteractable {
    public bool turn;
    public bool on;
    public bool allOn;
    public bool canEffect;

    public Transform cogwheel;
    public Transform rotationPoint;

    public Renderer rend;

    public JBValvePuzzle[] otherValves;
    public JBValvePuzzle[] turns;

    public Material notOff;
    public Material off;


    public void Start()
    {
        if (on)
        {
            rend.material = notOff;
        }
        else
        {
            rend.material = off;
        }
    }

    public override void Interacted()
    {
        Toggle();
        StartCoroutine(Timer());
        for (int i = 0; i+1 <= turns.Length; i++)
        {
            turns[i].Toggle();
        }
        Check();
    }

    public void Update()
    {
        if(turn == true)
        {
            transform.parent.Rotate(new Vector3(0, 0, -Random.Range(1,2)));
        }
    }

    public void Toggle()
    {
        if (on)
        {
            on = false;
            rend.material = off;
        }
        else
        {
            on = true;
            rend.material = notOff;
        }
    }

    public IEnumerator Timer()
    {
        turn = true;
        yield return new WaitForSeconds(1);
        turn = false;
    }

    public void Check()
    {
        canEffect = true;
        for(int i = 0; i+1 <= otherValves.Length; i++)
        {
            if(otherValves[i].on != true)
            {
                canEffect = false;
            }
        }
        if (canEffect)
        {
            cogwheel.rotation = rotationPoint.rotation;
            cogwheel.position = rotationPoint.position;
        }
    }
}
