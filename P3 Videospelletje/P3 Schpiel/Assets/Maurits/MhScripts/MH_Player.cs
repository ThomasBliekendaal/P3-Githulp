using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float enRegenDelay;
    public int health;
    public int maxHealth;
    public int energy;
    public int maxEnergy;
    public int armor;
    public bool canMove = true;
    public bool canSprint;
    public bool canInteract = true;
    public bool hasKey;
    public bool removeEnergy = true;
    public bool canRegenEn;
    public bool canRegenHp;
    public bool sprints;
    public RaycastHit hit;
    // Use this for initialization
    void Start()
    {
        UIManager.GetComponent<MH_UIManager>().UpdateEnergy(energy, maxEnergy);
        UIManager.GetComponent<MH_UIManager>().UpdateHealth(health, maxHealth);
        UIManager.GetComponent<MH_UIManager>().UpdateArmor(armor);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        CamRot();
        Sprinting();
        if(health < maxHealth && canRegenHp)
        {
            StartCoroutine(RegainHealth());
            canRegenHp = false;
        }
        if (Input.GetButtonDown("Interact"))
        {
            Interact();
        }
    }
    public void Movement()
    {
        if (canMove)
        {
            movePos.x = Input.GetAxis("Horizontal");
            movePos.z = Input.GetAxis("Vertical");
            transform.Translate(movePos * moveSpeed * Time.deltaTime);
        }
    }
    public void Sprinting()
    {
        if(canSprint == false)
        {
            if(energy >= 25)
            {
                canSprint = true;
            }
        }
        if (canRegenEn && sprints == false && energy < maxEnergy)
        {
            StartCoroutine(RegainEnergy());
        }
        if (Input.GetButton("Sprint"))
        {
            if (energy >= 1 && canMove && canSprint)
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
                canSprint = false;
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
        SceneManager.LoadScene("MH_Game");
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
        yield return new WaitForSeconds(0);
        energy -= 1;
        UIManager.GetComponent<MH_UIManager>().UpdateEnergy(energy, maxEnergy);
        removeEnergy = true;
    }
    public IEnumerator RegainEnergy()
    {
        canRegenEn = false;
        yield return new WaitForSeconds(enRegenDelay);
        energy += 1;
        UIManager.GetComponent<MH_UIManager>().UpdateEnergy(energy, maxEnergy);
        canRegenEn = true;
    }
    public IEnumerator RegainHealth()
    {
        yield return new WaitForSeconds(1);
        health += 1;
        UIManager.GetComponent<MH_UIManager>().UpdateHealth(health, maxHealth);
        canRegenHp = true;
    }
}

