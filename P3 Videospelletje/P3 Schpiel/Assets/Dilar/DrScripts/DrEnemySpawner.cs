using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrEnemySpawner : MonoBehaviour
{

    public GameObject[] enemySpawners;
    public GameObject enemy;
    public GameObject panel;

    public bool enemyKilled = false;
    public int kills;
    public int spawnPoint;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemyKilled == true)
        {
            kills++;
            enemyKilled = false;
            if (kills < 10)
            {
                SpawnEnemies();
            }
            else
            {
                panel.SetActive(true);
            }
        }
	}


    public void SpawnEnemies()
    {
        spawnPoint = Random.Range(0, 2);
        Instantiate(enemy, enemySpawners[spawnPoint].transform.position, Quaternion.identity);
        Instantiate(enemy, enemySpawners[spawnPoint].transform.position, Quaternion.identity);
    }
}
