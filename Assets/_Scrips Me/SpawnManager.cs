using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField, Range(-15, 15)] private float posX = 7;
    [SerializeField, Range(-15, 15)] private float posZ = 9;


    private float enemyCount;
    [SerializeField] private int enemyWave =1;

    [SerializeField] private GameObject powerUpsIndicator;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(enemyWave);
    }

    // Update is called once per frame
    void Update()
    {
       ChecKEnemies();
    }

    
    /// <summary>
    /// Genera una posición aleatoria
    /// </summary>
    /// <returns> </returns>
    private Vector3 GeneraPosAleatoria()
    {
        float posXRandom = Random.Range(-posX, posX);
        float posZRandom = Random.Range(-posZ, posZ);

        Vector3 posRandom = new Vector3(posXRandom, 0.5f, posZRandom);

        return posRandom;

    }

    /// <summary>
    /// Spawnea enemigos
    /// </summary>
    /// <param name="countEnemyWave">Cantidad de enemigos a spawnear</param>
    private void SpawnEnemies(int countEnemyWave)
    {
        for (int i = 0; i < countEnemyWave; i++)
        {
            Instantiate(enemy, GeneraPosAleatoria(), enemy.transform.rotation);
        }

    }

    private void ChecKEnemies()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            enemyWave++;
            SpawnEnemies(enemyWave);

            int indicatorCount = Random.Range(0, 3);
            for (int i = 0; i < indicatorCount; i++)
            {
                Instantiate(powerUpsIndicator, GeneraPosAleatoria(), powerUpsIndicator.transform.rotation);
            }
        }
        {
            
        }
        
    }
    
    
    
    
}
