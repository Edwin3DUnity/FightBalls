using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] private float posX = 7;
    [SerializeField] private float posZ = 9;

    [SerializeField] private int enemyCount;
    public int enemyWave = 1;

    public GameObject powerUPPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnearEnemies(enemyWave);
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemiesScene();
    }
    
    
    /// <summary>
    /// Genera una posición Aleatoria
    /// </summary>
    /// <returns>Retorna un Vector 3 </returns>
    private Vector3 GenerarPosAleatoria()
    {
        float posXRandom = Random.Range(-posX, posX);
        float posZRandom = Random.Range(-posZ, posZ);



        Vector3 RandomPos = new Vector3(posXRandom, 0.5f , posZRandom);

        return RandomPos;
    }

    /// <summary>
    /// Genera enemigos 
    /// </summary>
    /// <param name="numberOfEnemies">Cantidad de enemigos a spawnear</param>
    private void SpawnearEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemy, GenerarPosAleatoria(), enemy.transform.rotation);
        }
        
        
    }

    private void CheckEnemiesScene()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            enemyWave++;
            SpawnearEnemies(enemyWave);

            int numberOfPowerUps = Random.Range(0, 2);
            for(int i = 0; i < numberOfPowerUps; i ++)
            {
                Instantiate(powerUPPrefab, GenerarPosAleatoria(), powerUPPrefab.transform.rotation);
            }
        }
    }
}
