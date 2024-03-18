using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    [SerializeField, Range(-10, 10)] private float posX = 7;

    [SerializeField, Range(-10, 10)] private float posZ = 9;
    // Start is called before the first frame update

  
    void Start()
    {


        Instantiate(enemy, PosRandom(), enemy.transform.rotation );

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    /// <summary>
    /// Genera una posición aleatoria en al zona del juego
    /// </summary>
    /// <returns>Retorna un vector 3</returns>
    private Vector3 PosRandom()
    {
        float posRandomX = Random.Range(-posX, posX);
        float posRandomZ = Random.Range(-posZ, posZ);

       Vector3  spawnRandom = new Vector3(posRandomX, 0.5f, posRandomZ);

         return spawnRandom;

    }
    
}
