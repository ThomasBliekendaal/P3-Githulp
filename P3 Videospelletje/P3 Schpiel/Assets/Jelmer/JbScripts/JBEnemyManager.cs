using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JBEnemyManager : MonoBehaviour {

    public Transform[] positions;
    public GameObject enemiePrefab;
    public int neededKillAmount;
    public int kills;
    public Text amountInput;

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
            Debug.Log("you did it, youre a good boi");
        }
    }
}
