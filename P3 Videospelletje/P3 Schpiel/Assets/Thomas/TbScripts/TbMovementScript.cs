using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TbMovementScript : MonoBehaviour {
    public GameObject pCamera;
    public float walkSpeed;
    public int jumps;
    public float sensitivity;
    public Vector3 jumpVel;
    public Vector3 rotateVel;
    public Vector3 camRotateVel;
    public int totalJumps;
    public float sprintSpeed;
    public float walkSpeed2;
    public float mana;
    public float health;
    public float manaTimer;
    public bool canRegenMana;
    public bool readyToRegen;
    public bool regening;
    public Slider manaBar;
    public Slider healthBar;
    public float maxHealth = 100;
    public float maxMana = 100;
    public int upgradeBits;
    public float rayLength;
    public Transform pLook;
    public RaycastHit hit;
    public GameObject interactInfo;
    public bool interactable;
    public float regenSpeed = 30;


	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        totalJumps = jumps;
        walkSpeed2 = walkSpeed;
        health = maxHealth;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float translation = Input.GetAxis("Vertical") * walkSpeed;
        float strafe = Input.GetAxis("Horizontal") * walkSpeed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;
        transform.Translate(strafe, 0, translation);

        if (Input.GetButtonDown("Jump"))
        {
            if (jumps > 0)
            {
                GetComponent<Rigidbody>().velocity += jumpVel;
                jumps -= 1;
            }
        }
        if (Input.GetButton("Sprint"))
        {
            walkSpeed = sprintSpeed;
        }
        else
        {
            walkSpeed = walkSpeed2;
        }

        rotateVel.y = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        transform.Rotate(rotateVel);

        camRotateVel.x = -Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        pCamera.transform.Rotate(camRotateVel);
    }
    void Update()
    {
        if (canRegenMana == true)
        {
            mana += Time.deltaTime * regenSpeed;
            if (mana >= maxMana)
            {
                canRegenMana = false;
                mana = maxMana;
            }
        }
        if (mana <= 0)
        {
            mana = 0;
        }
        if (readyToRegen == true && regening == false)
        {
            StartCoroutine(ManaTimer());
        }
        if (!Input.GetButton("Fire1") && regening == false)
        {
            readyToRegen = true;
        }
        if (!readyToRegen)
        {
            StopCoroutine(ManaTimer());
            regening = false;
        }
        manaBar.value = mana;
        healthBar.value = health;
        healthBar.maxValue = maxHealth;
        manaBar.maxValue = maxMana;

        if (Physics.Raycast(pLook.position, pLook.forward, out hit, rayLength))
        {
            if (hit.transform.tag == "Interactable")
            {
                interactInfo.SetActive(true);
                interactable = true;
            }
        }
        else
        {
            interactInfo.SetActive(false);
            interactable = false;
        }
        if (interactable == true)
        {
            if (Input.GetButtonDown("Use"))
            {
                hit.transform.gameObject.GetComponent<TbInteractables>().Interaction();
            }
        }
    }
    public void Use(float manaUsage)
    {
        canRegenMana = false;
        mana -= manaUsage;
        readyToRegen = false;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            jumps = totalJumps;
        }
    }
    public IEnumerator ManaTimer()
    {
        if (readyToRegen)
        {
            regening = true;
            yield return new WaitForSeconds(manaTimer);
            if (readyToRegen)
            {
                canRegenMana = true;
                regening = false;
            }
        }
    }
    public void PlayerTakeDamage(float enemyDamage)
    {
        health -= enemyDamage;
    }
}
