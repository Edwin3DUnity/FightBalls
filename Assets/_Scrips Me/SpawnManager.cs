using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;

    private float posX = 7;
    private float posZ = 9;


    [SerializeField] private int enemyCount;
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
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;

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
    /// <summary>
    /// Genera una posicion aleatoria
    /// </summary>
    /// <returns></returns>
    private Vector3 GeneratePosRandom()
    {
        float randomPosX = Random.Range(-7,7);
        float randomPosZ = Random.Range(-9, 9);

        Vector3 posRandom = new Vector3(randomPosX, 0.5f, randomPosZ);

        return posRandom;


    }

/// <summary>
/// Spawnea un número determinados de enemigos
/// <param name="numberOfEnemies">numero de enemigos a crear</param>
/// </summary>

    private void SpawnEnemyWave(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemy, GeneratePosRandom(), enemy.transform.rotation);
        }
    }
}
