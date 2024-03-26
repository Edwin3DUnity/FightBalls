using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private float posX = 7;
    [FormerlySerializedAs("posY")] [SerializeField] private float posZ = 9;


    [SerializeField] private int enemyCount;
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
    /// Genera posición Aleatoria
    /// </summary>
    /// <returns>Retorna un vector 3</returns>
    private Vector3 GeneraPosAleatoria()
    {
        float posXRandom = Random.Range(-posX, posX);
        float posZRandom = Random.Range(-posZ, posZ);

        Vector3 randomPos = new Vector3(posXRandom, 0.5f, posZRandom);

        return randomPos;

    }

    private void SpawnEnemy(int countEnemySpawn)
    {
        for (int i = 0; i < countEnemySpawn; i++)
        {
            Instantiate(enemy, GeneraPosAleatoria(), enemy.transform.rotation);
        }
        
    }

    private void CheckEnemies()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            enemyWave++;
            SpawnEnemy(enemyWave);
            
            int countIconPower = Random.Range(0, 3);
            for(int i = 0; i < countIconPower; i++)
            {
                Instantiate(powerUpIcon, GeneraPosAleatoria(), powerUpIcon.transform.rotation);
            }

        }


    }
    
}
