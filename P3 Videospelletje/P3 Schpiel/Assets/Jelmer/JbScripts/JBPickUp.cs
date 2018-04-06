using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBPickUp : JBInteractable
{
    public GameObject pickUp;
    public JBCharacterMovement player;
    public Transform hand;

    public void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<JBCharacterMovement>();
        hand = GameObject.FindWithTag("GameController").transform;
    }

    public override void Interacted()
    {
        if (player.currentItem.Length == 1)
        {
            GameObject activeItem = player.currentItem[0];
            activeItem.GetComponent<JBPickUp>().enabled = true;
            activeItem.GetComponent<Rigidbody>().isKinematic = false;
            activeItem.transform.parent = null;
            activeItem.GetComponent<Collider>().isTrigger = false;

            player.currentItem[0] = gameObject;
            gameObject.GetComponent<JBPickUp>().enabled = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.parent = hand;
            gameObject.GetComponent<Collider>().isTrigger = true;
            gameObject.transform.position = hand.position;
            gameObject.transform.rotation = hand.rotation;
        }
    }
}
