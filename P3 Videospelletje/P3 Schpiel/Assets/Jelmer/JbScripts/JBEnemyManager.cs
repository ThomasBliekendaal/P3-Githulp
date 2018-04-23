using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JBEnemyManager : MonoBehaviour {

    public Transform[] positions;
    public GameObject enemiePrefab;
    public int neededKillAmount;
    public int kills;
    public Text amountInput;
    public GameObject endpanel;

    public void Start()
    {
        Check();
    }

    public void SpawnEnemy()
    {
        Transform pos = positions[Random.Range(0, positions.Length)];
        Instantiate(enemiePrefab, pos.position, pos.rotation);
    }

    public void Check()
    {
        amountInput.text = kills.ToString() + " / " + neededKillAmount.ToString();
        if (kills >= neededKillAmount)
        {
            Time.timeScale = 0;
            endpanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Buttonpress()
    {
        GameObject.FindGameObjectWithTag("StatSaver").GetComponent<StatManager>().AddPendant(0);
        SceneManager.LoadScene("HubWorld");
    }
}
