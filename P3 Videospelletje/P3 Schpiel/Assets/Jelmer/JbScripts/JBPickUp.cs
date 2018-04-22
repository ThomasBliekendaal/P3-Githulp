using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBPickUp : JBInteractable
{
    public GameObject pickUp;
    public JBCharacterMovement player;
    public Vector3 pickupRotation;
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
            activeItem.GetComponent<JBThrowItem>().enabled = false;
            if (activeItem.GetComponent<JBWeaponSwing>())
            {
                activeItem.GetComponent<JBWeaponSwing>().enabled = false;
            }

            player.currentItem[0] = gameObject;
            gameObject.GetComponent<JBPickUp>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.parent = hand;
            gameObject.GetComponent<Collider>().isTrigger = true;
            gameObject.transform.position = hand.position;
            gameObject.transform.rotation = hand.rotation;
            gameObject.GetComponent<JBThrowItem>().enabled = true;
            if (gameObject.GetComponent<JBWeaponSwing>())
            {
                gameObject.GetComponent<JBWeaponSwing>().enabled = true;
                gameObject.GetComponent<JBWeaponSwing>().SetRotation();
            }
            player.currentItem[0] = gameObject;
        }
        else
        {
            gameObject.GetComponent<JBPickUp>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.parent = hand;
            gameObject.GetComponent<Collider>().isTrigger = true;
            gameObject.transform.position = hand.position;
            if (gameObject.GetComponent<JBWeaponSwing>())
            {
                gameObject.GetComponent<JBWeaponSwing>().enabled = true;
                gameObject.GetComponent<JBWeaponSwing>().SetRotation();
            }
            transform.localRotation = Quaternion.Euler(new Vector3(pickupRotation.x,pickupRotation.y,pickupRotation.z));
            gameObject.GetComponent<JBThrowItem>().enabled = true;
            player.currentItem = new GameObject[1] {gameObject};
        }
    }
}
