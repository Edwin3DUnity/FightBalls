using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

     private float posX = 7;
     private float posZ = 9;




    [SerializeField] private int enemyCound;
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
        enemyCound = GameObject.FindObjectsOfType<Enemy>().Length;
       

        if (enemyCound == 0)
        {
            enemyWave++;
            SpawnEnemyWave(enemyWave);
            
            int numberOfPowerUps = Random.Range(0, 2);
            for (int i = 0; i < numberOfPowerUps; i++)
            {
                Instantiate(powerUpPrefab, GenerarPosALeatoria(), powerUpPrefab.transform.rotation);
            }
            
            
        }
    }
/// <summary>
/// Genera Posicion Aleatorio  
/// </summary>
/// <returns></returns>

    private Vector3 GenerarPosALeatoria()
{
          float posRandomX = Random.Range(-posX, posX);
          float posRandomZ = Random.Range(-posZ, posZ);
        Vector3 posRandom = new Vector3(posRandomX,0.5f, posRandomZ);

        return posRandom;

    }

/// <summary>
/// Spawnea un numero determinados de enemigos
/// <param name="numberOfEnemies"> numero de enemigos a crear </param>
/// </summary>
    private void SpawnEnemyWave(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemy, GenerarPosALeatoria(), enemy.transform.rotation);
        }
    }
    
}
