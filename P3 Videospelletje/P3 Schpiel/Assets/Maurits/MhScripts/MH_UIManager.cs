using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MH_UIManager : MonoBehaviour {
    public int ogHealth;
    public bool nightmare;
    public GameObject blackBar;
    public GameObject energyBar;
    public GameObject healthBar;
    public GameObject armorBar;
    public GameObject graphicOpt;
    public GameObject player;
    public GameObject[] potions;
	// Use this for initialization
	void Start () {
        StartCoroutine(Timer());
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
    public IEnumerator Timer()
    {
        player.GetComponent<MH_Player>().canMove = false;
        player.GetComponent<MH_Player>().canInteract = false;
        blackBar.SetActive(true);
        yield return new WaitForSeconds(11);
        blackBar.SetActive(false);
        player.GetComponent<MH_Player>().canMove = true;
        player.GetComponent<MH_Player>().canInteract = true;
    }
    public void ChangeQuality(int level)
    {
        QualitySettings.SetQualityLevel(level, true);
    }
    public void ChangeDifficulty()
    {
        if (nightmare != true)
        {
            for(int i = 0; i < potions.Length; i++)
            {
                potions[i].SetActive(false);
            }
            ogHealth = player.GetComponent<MH_Player>().maxHealth;
            player.GetComponent<MH_Player>().maxHealth = 1;
            player.GetComponent<MH_Player>().health = 1;
            nightmare = true;
        }
        else
        {
            player.GetComponent<MH_Player>().maxHealth = ogHealth;
            for(int a = 0; a < potions.Length; a++)
            {
                potions[a].SetActive(true);
            }
            nightmare = false;
        }
    }
}
