using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBCharacterMovement : MonoBehaviour {
    public float walkSpeed;
    public float runSpeed;
    public float sneakSpeed;

    private float currentSpeed;

    public Transform head;
    public Transform body;
    public float normalLenght;
    public float crouchLenght;
    public Vector3 normalHight;
    public Vector3 crouchHight;
    public GameObject[] currentItem;

    public RaycastHit interact;
    
	void Start () {
        normalLenght = body.transform.localScale.y;
        normalHight.y = head.localPosition.y;
        crouchHight.y = (normalLenght - crouchLenght) / 2 + head.localScale.y - 0.05f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	void FixedUpdate () {
        if (Input.GetButton("Ctrl"))
        {
            currentSpeed = sneakSpeed;
            body.transform.localScale = new Vector3(body.transform.localScale.x, crouchLenght, body.transform.localScale.z);
            head.transform.localPosition = crouchHight;
        }
        else
        {
            body.transform.localScale = new Vector3(body.transform.localScale.x, normalLenght, body.transform.localScale.z);
            head.transform.localPosition = normalHight;
            if (Input.GetButton("Sprint"))
            {
                currentSpeed = runSpeed;
            }
            else
            {
                currentSpeed = walkSpeed;
            }
        }

        transform.Translate(Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime);

        head.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);

        if (Physics.Raycast(head.position, head.transform.forward* 5, out interact) && interact.transform.tag == "Interactable" && Input.GetButtonDown("Interact"))
        {
            interact.transform.gameObject.GetComponent<JBInteractable>().Interacted();
        }
	}
}
