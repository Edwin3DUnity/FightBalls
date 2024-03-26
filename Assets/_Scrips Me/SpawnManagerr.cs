using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManagerr : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private float posX = 7;
    [SerializeField] private float posZ = 9;

    private int enemyCount;
    [SerializeField] private int enemyWave = 1;

    [SerializeField] private GameObject powerUpIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(enemyWave);
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemies();
    }
    
    /// <summary>
    /// Genera posicion aleatoria
    /// </summary>
    /// <returns> Retorna un vector 3 random como posicion</returns>
    private Vector3 GeneraPosAletoria()
    {
        float posXRandom = Random.Range(-posX, posX);
        float poxZRandom = Random.Range(-posZ, posZ);

        Vector3 posRandom = new Vector3(posXRandom, 0.5f, poxZRandom);

        return posRandom;

    }

    private void SpawnEnemy(int countspawnEnemies)
    {
        for (int i = 0; i < countspawnEnemies; i++)
        {
            Instantiate(enemy, GeneraPosAletoria(), enemy.transform.rotation);
        }

    }
    
    private void CheckEnemies()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        
        if (enemyCount == 0)
        {
            enemyWave++;
            SpawnEnemy(enemyWave);

            int countPowerUpIcon = Random.Range(0, 3);

            for (int i = 0; i < countPowerUpIcon; i++)
            {
                Instantiate(powerUpIcon, GeneraPosAletoria(), powerUpIcon.transform.rotation);
            }

        }
        
    }
  
}
