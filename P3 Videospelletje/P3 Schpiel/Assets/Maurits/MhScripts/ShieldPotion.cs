using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPotion : MH_Item {
    public int addAmt;
    public GameObject UIManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void Interact(GameObject target)
    {
        if(addAmt <=  100 - target.GetComponent<MH_Player>().armor)
        {
            target.GetComponent<MH_Player>().armor += addAmt;
        }
        else
        {
            target.GetComponent<MH_Player>().armor += Calculate(target.GetComponent<MH_Player>().armor);
        }
        UIManager.GetComponent<MH_UIManager>().UpdateArmor(target.GetComponent<MH_Player>().armor);
        Destroy(gameObject);
    }
    public int Calculate(int armorAmt)
    {
        return 100 - armorAmt;
    }
}
