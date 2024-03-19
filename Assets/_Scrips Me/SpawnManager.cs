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
        Instantiate(enemy, GenerarPosALeatoria(), enemy.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private Vector3 GenerarPosALeatoria()
    {
        posX = Random.Range(-posX, posX);
        posZ = Random.Range(-posZ, posZ);

        Vector3 posRandom = new Vector3(posX,0.5f, posZ);

        return posRandom;

    }
    
}
