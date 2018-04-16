using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_UIManager : MonoBehaviour {
    public GameObject energyBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateEnergy(int currentEnergy, int maxEnergy)
    {
        energyBar.GetComponent<Image>().fillAmount = BarCalculator(currentEnergy, maxEnergy);
    }
    public float BarCalculator(int current, int max)
    {
        print(current);
        print(max);
        print(1 / max * current);
        return (1 / max) * current;
    }
}
