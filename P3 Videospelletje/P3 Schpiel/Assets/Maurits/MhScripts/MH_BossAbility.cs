using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_BossAbility : MonoBehaviour {
    public GameObject uiManager;
	// Use this for initialization

    public void DealDmg(int dmg, GameObject target)
    {
        if(target.GetComponent<MH_Player>().armor < dmg)
        {
            target.GetComponent<MH_Player>().health -= (dmg - target.GetComponent<MH_Player>().armor);
            target.GetComponent<MH_Player>().armor = 0;
            if(target.GetComponent<MH_Player>().health <= 0)
            {
                //target.GetComponent<MH_Player>().Death();
            }
        }
        else
        {
            target.GetComponent<MH_Player>().armor -= dmg;
        }
        uiManager.GetComponent<MH_UIManager>().UpdateArmor(target.GetComponent<MH_Player>().armor);
        uiManager.GetComponent<MH_UIManager>().UpdateHealth(target.GetComponent<MH_Player>().health, target.GetComponent<MH_Player>().maxHealth);
    }
}
