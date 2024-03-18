using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;

    [SerializeField] private float posX = 7;
    [SerializeField] private float posZ = 9;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, GenerarPosRandom(), enemy.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerarPosRandom()
    {
        float posXRandom = Random.Range(-posX, posX);
        float posZRandom = Random.Range(-posZ, posZ);
        Vector3 posRandom = new Vector3(posXRandom, 0.5f, posZRandom);

        return posRandom;
    }
    
}
