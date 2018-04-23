using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MH_UIManager : MonoBehaviour {
    public int ogHealth;
    public bool nightmare;
    private bool canPause;
    public bool paused;
    public GameObject blackBar;
    public GameObject energyBar;
    public GameObject healthBar;
    public GameObject armorBar;
    public GameObject player;
    public GameObject pauseUI;
    public GameObject pauseScreen;
    public GameObject[] allPauseUI;
    public GameObject[] potions;
	// Use this for initialization
	void Start () {
        StartCoroutine(Timer());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            if (canPause)
            {
                PauseGame();
            }
        }
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
        yield return new WaitForSeconds(9.5f);
        blackBar.SetActive(false);
        player.GetComponent<MH_Player>().canMove = true;
        player.GetComponent<MH_Player>().canInteract = true;
        canPause = true;
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
            UpdateHealth(player.GetComponent<MH_Player>().health, player.GetComponent<MH_Player>().maxHealth);
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
            UpdateHealth(player.GetComponent<MH_Player>().health, player.GetComponent<MH_Player>().maxHealth);
        }
    }
    public void Options(GameObject optionsUI)
    {
        optionsUI.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void ToPause(GameObject optionsUI)
    {
        for(int i = 0; i < allPauseUI.Length; i++)
        {
            allPauseUI[i].SetActive(false);
        }
        pauseScreen.SetActive(true);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        if (paused)
        {
            pauseUI.SetActive(false);
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
        else
        {
            pauseUI.SetActive(true);
            paused = true;
            Cursor.lockState = CursorLockMode.None;
            ToPause(pauseScreen);
            Time.timeScale = 0;
        }
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
