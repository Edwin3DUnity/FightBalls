using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Range(0, 15)] private float moveForce;

    [SerializeField] private GameObject player;

    private Rigidbody _rigidbody;

    [SerializeField] private float hightDeath = -5;
    
    // Start is called before the first frame update
    void Start()
    {

        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;

        _rigidbody.AddForce(moveDirection * moveForce, ForceMode.Force);
        
         DeathEnemy();
    }

    private void DeathEnemy()
    {
        if (transform.position.y < hightDeath)
        {
            Destroy(gameObject);
        }
    }
    
}
