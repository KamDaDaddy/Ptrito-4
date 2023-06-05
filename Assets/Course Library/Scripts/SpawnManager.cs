using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    private float spawnRange = 9;

    public GameObject[] enemiPrefab;
    public GameObject powerupPrefab;
    public int enemiCount;
    public int waveNumber = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);

        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiCount = FindObjectsOfType<Enemi>().Length;
        
        if (enemiCount == 0)
        {
            waveNumber++; 
            SpawnEnemyWave(waveNumber);
            
            
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }

        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        int enemiIndex = Random.Range(0, 2);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemiPrefab[enemiIndex], GenerateSpawnPosition(), enemiPrefab[enemiIndex].transform.rotation);

        }


    }

}
