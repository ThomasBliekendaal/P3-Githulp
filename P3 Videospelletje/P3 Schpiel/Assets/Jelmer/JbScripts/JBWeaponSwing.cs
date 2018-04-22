using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBWeaponSwing : MonoBehaviour {
    public bool startSwing;
    public bool returnSwing;
    public bool active;
    public Vector3 rot;
    public bool enemy;
    public bool start;

    public void Start()
    {
        if (enemy)
        {
            SetRotation();
        }
    }
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
        if (Input.GetButtonDown("Fire1") && !active && ! enemy)
        {
            active = true;
            StartCoroutine(StartSwing());
        }
        else if (enemy && start)
        {
            start = false;
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

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("swing1");
        if (active)
        {
            Debug.Log("swing2");
            if (enemy && other.gameObject.tag == "Player")
            {
                other.transform.parent.GetComponent<JBCharacterMovement>().hp -= Random.Range(5, 15);
            }
            else if( other.gameObject.tag == "Enemy")
            {
                Debug.Log("enemy found");
                other.gameObject.GetComponent<JBEnemy>().Damage(Random.Range(5, 15));
            }
        }
    }
}
