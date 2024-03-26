using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField, Range(0, 20)] private float moveForce = 3.5f;
    private Rigidbody _rigidbody;

    [SerializeField] private GameObject player;

    [SerializeField] private float hightDeath = -3;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        player = GameObject.Find("Player");



    }

    // Update is called once per frame
    void Update()
    {
        playerAtack();
        EnemyDeath();
    }

    private void playerAtack()
    {
        Vector3 movementDir = (player.transform.position - transform.position).normalized;
        
        _rigidbody.AddForce(movementDir * moveForce , ForceMode.Force);


    }

    private void EnemyDeath()
    {
        if (transform.position.y < hightDeath)
        {
            Destroy(gameObject);
        }
    }
    
    
}
