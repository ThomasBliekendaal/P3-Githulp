using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_StaminaPotion : MH_Potion {
    public GameObject uiManager;
    public int addAmt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void Interact(GameObject target)
    {
        target.GetComponent<MH_Player>().maxEnergy += addAmt;
        target.GetComponent<MH_Player>().enRegenDelay = 0.05f;
        target.GetComponent<MH_Player>().energy = target.GetComponent<MH_Player>().maxEnergy;
        uiManager.GetComponent<MH_UIManager>().UpdateEnergy(target.GetComponent<MH_Player>().energy, target.GetComponent<MH_Player>().maxEnergy);
        target.GetComponent<MH_Player>().canInteract = true;
        Destroy(gameObject);
    }
}
