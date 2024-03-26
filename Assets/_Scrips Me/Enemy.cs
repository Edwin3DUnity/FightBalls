using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField, Range(0, 30)] private float moveForce = 3.8f;
    private Rigidbody _rigidbody;

    [SerializeField] private GameObject player;

    [SerializeField] private float hightDead = -5;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        _rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        AtackPlayer();
        
        EnemyDeath();
    }

    private void AtackPlayer()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        
        _rigidbody.AddForce(moveDirection * moveForce , ForceMode.Force);


    }


    private void EnemyDeath()
    {
        if (transform.position.y < hightDead)
        {
            Destroy(gameObject);
        }
    }
}
