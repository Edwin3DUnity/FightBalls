using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    [SerializeField, Range(0, 20)] private float moveForce = 3.5f;
    private Rigidbody _rigidbody;


    private GameObject _player;

    [SerializeField] private float deathEnemyHight = - 3;
        
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        DeathEnemy();
    }

    private void FollowPlayer()
    {
        Vector3 moveDirection = (_player.transform.position - transform.position).normalized;
        
        
        _rigidbody.AddForce(moveDirection * moveForce, ForceMode.Force);

    }


    private void DeathEnemy()
    {
        if (transform.position.y < deathEnemyHight)
        {
            Destroy(gameObject);
        }
    }
    
}
