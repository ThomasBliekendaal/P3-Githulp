using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBWeaponSwing : MonoBehaviour {
    public bool startSwing;
    public bool returnSwing;
    public bool active;
    public Vector3 rot;

    public void Update()
    {
        if (startSwing)
        {
            transform.Rotate(new Vector3(0, -170, -100) * Time.deltaTime * 2);
        }
        else if(returnSwing)
        {
            transform.Rotate(new Vector3(0, 170, 100) * Time.deltaTime * 2);
        }
        if (Input.GetButtonDown("Fire1") && !active)
        {
            active = true;
            StartCoroutine(StartSwing());
        }
    }

    public IEnumerator StartSwing()
    {
        startSwing = true;
        yield return new WaitForSeconds(0.35f);
        startSwing = false;
        StartCoroutine(ReturnSwing());
    }

    public IEnumerator ReturnSwing()
    {
        returnSwing = true;
        yield return new WaitForSeconds(0.35f);
        returnSwing = false;
        active = false;
        SetRotation();
    }

    public void SetRotation()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(270, 0, 90));
    }
}
