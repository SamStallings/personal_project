using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject powerupPrefab;
    public GameObject enemyPrefab;

    private float spawnRangeX = 10.0f;
    private float spawnYMin = 5.0f;
    private float spawnYMax = 15.0f;

    public int enemyCount;
    public int waveCount = 1;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveCount);
        }
    }

    //Spawn randomly on platforms
    Vector3 GenerateSpawnPosition()
    {
        float yPos = Random.Range(spawnYMin, spawnYMax);
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        return new Vector3(xPos, yPos, 3.5f);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, 15); // make powerups spawn at the opposite end

        //spawn one powerup if there aren't any
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) ; // check for no powerups
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // spawn enemy robots depending on wave order
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        waveCount++;

        enemyPrefab.GetComponent<Enemy>().enemySpeed += 2;
    }
}
