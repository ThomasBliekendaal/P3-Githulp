using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_HealthPotion : MH_Potion
{
    public GameObject uiManager;
    public int addAmt;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Interact(GameObject target)
    {
        target.GetComponent<MH_Player>().maxHealth += addAmt;
        target.GetComponent<MH_Player>().health = target.GetComponent<MH_Player>().maxHealth;
        uiManager.GetComponent<MH_UIManager>().UpdateHealth(target.GetComponent<MH_Player>().health, target.GetComponent<MH_Player>().maxHealth);
        target.GetComponent<MH_Player>().canInteract = true;
        Destroy(gameObject);
    }
}
