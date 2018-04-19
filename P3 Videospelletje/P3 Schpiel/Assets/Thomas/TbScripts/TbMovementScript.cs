using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        totalJumps = jumps;
        walkSpeed2 = walkSpeed;
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
            mana += Time.deltaTime * 30;
            if (mana >= 100)
            {
                canRegenMana = false;
                mana = 100;
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
}
