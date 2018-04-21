using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrEnemySpawner : MonoBehaviour
{

    public GameObject[] enemySpawners;
    public GameObject enemy;

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
            SpawnEnemies();
        }
	}


    public void SpawnEnemies()
    {
        Debug.Log(" REE");
        spawnPoint = Random.Range(0, 2);
        Instantiate(enemy, enemySpawners[spawnPoint].transform.position, Quaternion.identity);
    }
}
