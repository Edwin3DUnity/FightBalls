using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private float posX = 7;
    private float PosZ = 9;


    [SerializeField] private float enemyCount;
    public int enemyWave = 1;

    public GameObject powerUpPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(enemyWave);
    }

    // Update is called once per frame
    void Update()
    {
        
        GenerarEnemies();
        
        
    }

    private Vector3 GeneratePosRandom()
    {
        float randomPosX = Random.Range(-posX, posX);
        float randomPosZ = Random.Range(-PosZ, PosZ);

        Vector3 posRandom = new Vector3(randomPosX, 0.5f, randomPosZ);

        return posRandom;

    }

    private void GenerarEnemies()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemies>().Length;

        if (enemyCount == 0)
        {
            enemyWave++;
            SpawnEnemyWave(enemyWave);

            int numberOfPowerUps = Random.Range(0, 2);
            for (int i = 0; i < numberOfPowerUps; i++)
            {
                Instantiate(powerUpPrefab, GeneratePosRandom(), powerUpPrefab.transform.rotation);
            }

        }
        
    }

    private void SpawnEnemyWave(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemy, GeneratePosRandom(), enemy.transform.rotation);
        }
    }
    
}
