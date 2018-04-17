using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MH_UIManager : MonoBehaviour {
    public GameObject blackBar;
    public GameObject energyBar;
    public GameObject healthBar;
    public GameObject armorBar;
	// Use this for initialization
	void Start () {
      //  StartCoroutine(Timer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateArmor(int currentArmor)
    {
        armorBar.GetComponent<Image>().fillAmount = BarCalculator(currentArmor, 100);
    }
    public void UpdateEnergy(int currentEnergy, int maxEnergy)
    {
        energyBar.GetComponent<Image>().fillAmount = BarCalculator(currentEnergy, maxEnergy);
    }
    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        healthBar.GetComponent<Image>().fillAmount = BarCalculator(currentHealth, maxHealth);
    }
    public float BarCalculator(int current, int max)
    {
        return (float) current / max;
    }
    /*public IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        blackBar.SetActive(false);
    }
    */
}
