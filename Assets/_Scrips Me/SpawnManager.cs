using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    [SerializeField] private float PosX = 7;
    [SerializeField] private float PosZ = 9;

    [SerializeField] private int enemyCount;
    [SerializeField] private int enemyWave = 1;


    [SerializeField] private GameObject powerUpIcon;
    // Start is called before the first frame update
    void Start()
    {

        SpawnEnemies(enemyWave);


    }

    // Update is called once per frame
    void Update()
    {
        CheckEnimies();
    }

    private void SpawnEnemies(int countEnemySpawn)
    {

        for (int i = 0; i < countEnemySpawn; i++)
        {
            Instantiate(enemy, GeneraPosRandom(), enemy.transform.rotation);    
        }
        


    }

    
    /// <summary>
    /// Genera Posicion aleatoria
    /// </summary>
    /// <returns>Un vector  3 Random</returns>
    private Vector3 GeneraPosRandom()
    {
        float xPosRandom = Random.Range(-PosX, PosX);
        float zPosRandom = Random.Range(-PosZ, PosZ);

        Vector3 randomPos = new Vector3(xPosRandom, 0.5f, zPosRandom);


        return randomPos;
    }

    private void CheckEnimies()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            enemyWave++;
            SpawnEnemies(enemyWave);

            int countPowerUps = Random.Range(0,3);

            for (int i = 0; i < countPowerUps; i++)
            {
                Instantiate(powerUpIcon, GeneraPosRandom(), powerUpIcon.transform.rotation);
            }
            

        }
        

    }
    
}
