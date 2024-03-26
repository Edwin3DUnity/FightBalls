using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Range(0, 20)] private float moveForce = 3.5f;
    private Rigidbody _rigidbody;

    [SerializeField] private GameObject player;

    [SerializeField] private float higthDead = -5;
    
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
        EnemyDead();
    }

    private void PlayerAtack()
    {
        Vector3 atackDirection = (player.transform.position - transform.position).normalized;
        
        
        _rigidbody.AddForce(atackDirection * moveForce , ForceMode.Force);

    }

    private void EnemyDead()
    {
        if (transform.position.y < higthDead)
        {
            Destroy(gameObject);
        }
        
    }
}
