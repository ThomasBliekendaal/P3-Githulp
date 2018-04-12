using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_Player : MonoBehaviour
{
    public GameObject cam;
    public Vector3 movePos;
    public Vector3 rotAmt;
    public float moveSpeed;
    public float rotSpeed;
    public int health;
    public int armor;
    public bool canInteract = true;
    public bool hasKey;
    public RaycastHit hit;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CamRot();
        if (Input.GetButtonDown("Interact"))
        {
            Interact();
        }
    }
    public void Movement()
    {
        movePos.x = Input.GetAxis("Horizontal");
        movePos.z = Input.GetAxis("Vertical");
        transform.Translate(movePos * moveSpeed * Time.deltaTime);
    }
    public void CamRot()
    {
        rotAmt.y = Input.GetAxis("Mouse X");
        transform.Rotate(rotAmt * rotSpeed * Time.deltaTime);
    }
    public void Death()
    {

    }
    public void Interact()
    {
        if (canInteract)
        {
            Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 5000);
            if (hit.transform != null)
            {
                if (hit.transform.gameObject.tag == "Interactable")
                {
                    canInteract = false;
                    hit.transform.gameObject.GetComponent<MH_Item>().Interact(gameObject);
                }
            }
        }
    }
}

