using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_Player : MonoBehaviour
{
    public GameObject UIManager;
    public GameObject cam;
    public Vector3 movePos;
    public Vector3 rotAmt;
    public float moveSpeed;
    public float startSpeed;
    public float sprintSpeed;
    public float rotSpeed;
    public int health;
    public int energy;
    public int maxEnergy;
    public int armor;
    public bool canMove = true;
    public bool canInteract = true;
    public bool hasKey;
    public bool removeEnergy = true;
    public bool canRegenEn;
    public bool sprints;
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
        Sprinting();
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
    public void Sprinting()
    {
        if (canRegenEn && sprints == false && energy < maxEnergy)
        {
            StartCoroutine(RegainEnergy());
        }
        if (Input.GetButton("Sprint"))
        {
            if (energy >= 1 && canMove)
            {
                if (removeEnergy)
                {
                    moveSpeed = sprintSpeed;
                    sprints = true;
                    StartCoroutine(RemoveEngergy());
                }
            }
            else
            {
                if (canMove)
                {
                    sprints = false;
                    moveSpeed = startSpeed;
                }
            }
        }
        if (Input.GetButtonUp("Sprint"))
        {
            if (canMove)
            {
                sprints = false;
                moveSpeed = startSpeed;
            }
        }
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
    public IEnumerator RemoveEngergy()
    {
        removeEnergy = false;
        yield return new WaitForSeconds(1);
        energy -= 1;
        UIManager.GetComponent<MH_UIManager>().UpdateEnergy(energy, maxEnergy);
        removeEnergy = true;
    }
    public IEnumerator RegainEnergy()
    {
        canRegenEn = false;
        yield return new WaitForSeconds(1);
        energy += 1;
        UIManager.GetComponent<MH_UIManager>().UpdateEnergy(energy, maxEnergy);
        canRegenEn = true;
    }
}

