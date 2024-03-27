using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    [SerializeField, Range(0, 25)] private float moveForce = 3.6f;
    private Rigidbody _rigidbody;


    [SerializeField] private GameObject player;

    [SerializeField] private float HightDeath = -5;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {
        PlayerAtack();
        EnemyDeath();
    }


    private void PlayerAtack()
    {
        Vector3 atackDir = (player.transform.position - transform.position).normalized;
        
        _rigidbody.AddForce(atackDir * moveForce , ForceMode.Force);
        
        

    }

    private void EnemyDeath()
    {
        if (transform.position.y < HightDeath)
        {
            Destroy(gameObject);
        }
    }
    
}
