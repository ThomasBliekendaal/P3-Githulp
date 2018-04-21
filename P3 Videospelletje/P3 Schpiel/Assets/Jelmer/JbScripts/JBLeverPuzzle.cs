using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBLeverPuzzle : JBInteractable {

    public JBLeverPuzzle needToBeOn;
    public JBLeverPuzzle[] allLevers;
    public bool on;
    public bool turn;
    public bool turnOff;

    public Renderer rend;

    public Material notoff;
    public Material off;

    public JBDoor door;

    public override void Interacted()
    {
        if (on)
        {
            Toggle();
        }
        else
        {
            if(needToBeOn == true)
            {
                if(needToBeOn.on == true)
                {
                    Toggle();
                    Check();
                }
                else
                {
                    for (int i = 0; i < allLevers.Length; i++)
                    {
                        if (allLevers[i].on)
                        {

                            allLevers[i].Toggle();
                        }
                    }
                }
            }
            else
            {
                Toggle();
            }
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
            rend.material = notoff;
        }
    }

    public void Check()
    {
        bool b = true;
        for (int i = 0; i < allLevers.Length; i++)
        {
            if(allLevers[i].on == false)
            {
                b = false;
            }
        }
        if (b)
        {
            door.locked = false;
            door.Interacted();
        }
    }
}
