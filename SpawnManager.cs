using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    // Dit maakt een float aan voor enemyPrefab in Unity.
    public GameObject enemyPrefab;

    // Dit maakt een float aan voor powerupPrefab in Unity.
    public GameObject powerupPrefab;
    
    // Dit maakt een float aan voor spawnRange met als standaard waarde 9.
    private float spawnRange = 9.0f;

    // Dit maakt een int voor de enemyCount in Unity.
    public int enemyCount;

    // Dit maakt een int voor waveNumber in Unity met als standaard waarde 1.
    public int waveNumber = 1;

    // Dit start alle scripts voor de eerste frame.
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        
        // Dit zorgt ervoor dat er een nieuwe powerup spawned.
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Dit update alle scripts per frame.
    void Update()
    {
        // Dit zorgt ervoor dat de computer weet wat enemyCount is.
        enemyCount = FindObjectsOfType<Enemy>().Length;

        // Dit zorgt ervoor dat er een nieuwe wave komt als alle enemy's dood zijn en er 1 bij komt.
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            
            // Dit zorgt ervoor dat er een nieuwe powerup spawned.
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    // Dit zorgt ervoor dat er enemy's spawnen.
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Dit zorgt ervoor dat de enemy's spawnen op een random plek.
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Dit maakt een nieuwe functie aan voor het spawnen van de enemy's.
    private Vector3 GenerateSpawnPosition()
    {
        // Dit maakt een spawn radius aan voor de enemy om in te spawnen.
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        // Dit zorgt ervoor dat het script opnieuw wordt uitgevoerd.
        return randomPos;
    }
}
