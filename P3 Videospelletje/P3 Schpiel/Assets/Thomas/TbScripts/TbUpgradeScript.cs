using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TbUpgradeScript : TbInteractables {
    public GameObject upgradeMenu;
    public GameObject player;
    public GameObject weapon1;
    public GameObject weapon1Special;
    public int cashMoney;
    public GameObject[] buttons;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(interacted == true)
        {
            upgradeMenu.SetActive(true);
            cashMoney = player.GetComponent<TbMovementScript>().upgradeBits;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            upgradeMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
	}
    public void Button1()
    {
        int forkIt = buttons[0].transform.GetComponent<TbUpgradeButtons>().payment;
        if(cashMoney >= forkIt)
        {
            cashMoney -= forkIt;
            player.GetComponent<TbMovementScript>().upgradeBits -= forkIt;
            player.GetComponent<TbMovementScript>().maxHealth = 150;
            player.GetComponent<TbMovementScript>().health = player.GetComponent<TbMovementScript>().maxHealth;
            buttons[0].SetActive(false);
        }
    }
    public void Button2()
    {
        int forkIt = buttons[1].transform.GetComponent<TbUpgradeButtons>().payment;
        if (cashMoney >= forkIt)
        {
            cashMoney -= forkIt;
            player.GetComponent<TbMovementScript>().upgradeBits -= forkIt;
            player.GetComponent<TbMovementScript>().maxMana = 150;
            player.GetComponent<TbMovementScript>().mana = player.GetComponent<TbMovementScript>().maxMana;
            buttons[1].SetActive(false);
        }
    }
    public void Button3()
    {
        int forkIt = buttons[2].transform.GetComponent<TbUpgradeButtons>().payment;
        if (cashMoney >= forkIt)
        {
            cashMoney -= forkIt;
            player.GetComponent<TbMovementScript>().upgradeBits -= forkIt;
            player.GetComponent<TbMovementScript>().regenSpeed = 40;
            buttons[2].SetActive(false);
        }
    }
    public void Button4()
    {
        int forkIt = buttons[3].transform.GetComponent<TbUpgradeButtons>().payment;
        if (cashMoney >= forkIt)
        {
            cashMoney -= forkIt;
            player.GetComponent<TbMovementScript>().upgradeBits -= forkIt;
            player.GetComponent<TbMovementScript>().walkSpeed = 7.5f;
            player.GetComponent<TbMovementScript>().walkSpeed2 = 7.5f;
            player.GetComponent<TbMovementScript>().sprintSpeed = 10;
            buttons[3].SetActive(false);
        }
    }
    public void Button5()
    {
        int forkIt = buttons[4].transform.GetComponent<TbUpgradeButtons>().payment;
        if (cashMoney >= forkIt)
        {
            cashMoney -= forkIt;
            player.GetComponent<TbMovementScript>().upgradeBits -= forkIt;
            weapon1.GetComponent<TbWandWep>().fireRate = 0.1f;
            weapon1Special.GetComponent<TbWandAltProjectile>().fireRate = 0.1f;
            buttons[4].SetActive(false);
        }
    }
    public void Button6()
    {
        int forkIt = buttons[5].transform.GetComponent<TbUpgradeButtons>().payment;
        if (cashMoney >= forkIt)
        {
            cashMoney -= forkIt;
            player.GetComponent<TbMovementScript>().upgradeBits -= forkIt;
            weapon1.GetComponent<TbWandWep>().altManaUsage = 25;
            buttons[5].SetActive(false);
        }
    }
    public void ExitShop()
    {
        interacted = false;
    }
}
