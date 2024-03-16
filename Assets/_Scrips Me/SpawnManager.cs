using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemy;


    [SerializeField] private float spwanRange = 9;

    
    
    // Start is called before the first frame update
    void Start()
    {

        
        
        Instantiate(enemy, GenerarPosAleatoria(),  enemy.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Genera una posicion aleatoria dentro de la zona de juego
    /// </summary>
    /// 
    /// <returns> Devuelve una posicion aleatoria dentro de la zona del juego</returns>
    private Vector3 GenerarPosAleatoria()
    {
        float spawnPosx = Random.Range(-spwanRange , spwanRange);
        float spawnPosZ = Random.Range(-spwanRange, spwanRange);
        
        Vector3 spawnPos = new Vector3 (spawnPosx, 0, spawnPosZ);

        return spawnPos;
    }

   
}
