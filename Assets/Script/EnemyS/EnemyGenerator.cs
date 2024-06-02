using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public float spawnTime;
    public int enemyNumber;
    public int maxEnemies;
    private int currentEnemies; 
    void Start()
    {
        currentEnemies = 0;
        InvokeRepeating("SpawnEnemies", 0f, spawnTime); //corrutina
        
    }

    public void SpawnEnemies ()
    {
        if(currentEnemies >= maxEnemies)
            return;

        for (int i = 0; i < enemyNumber; i++)
        {
            Instantiate(enemyPrefab, spawnPoints[Random.Range(0,spawnPoints.Length)].position,Quaternion.identity);
           
        }

         currentEnemies += enemyNumber;
    }
}
