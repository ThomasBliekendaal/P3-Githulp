using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBThrowItem : MonoBehaviour {

    public float maxForce;
    public JBCharacterMovement player;
    public Transform hand;
    private float power;
    public float chargespeed;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<JBCharacterMovement>();
        hand = GameObject.FindWithTag("GameController").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire2") && power <= maxForce)
        {
            
            power += Time.deltaTime * chargespeed;
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            ThrowItem(power);
            power = 0;
        }
	}

    public void ThrowItem(float force)
    {
        player.currentItem = new GameObject[0];
        gameObject.GetComponent<Collider>().isTrigger = false;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(hand.forward * power);
        gameObject.GetComponent<JBThrowItem>().enabled = false;
        gameObject.GetComponent<JBPickUp>().enabled = true;
        transform.parent = null;
    }
}
