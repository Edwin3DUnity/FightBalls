using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    [SerializeField] private float posX = 7;
    [SerializeField] private float posZ = 9;
    
    // Start is called before the first frame update
    
    
    
    void Start()
    {
        SpawnEnemyWave(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/// <summary>
/// Genera Posicion Aleatorio  
/// </summary>
/// <returns></returns>

    private Vector3 GenerarPosALeatoria()
    {
        posX = Random.Range(-posX, posX);
        posZ = Random.Range(-posZ, posZ);

        Vector3 posRandom = new Vector3(posX,0.5f, posZ);

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
