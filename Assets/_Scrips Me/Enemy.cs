using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField, Range(0, 25)] private float moveForce = 2;

    private GameObject player;


    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");

        _rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
            
        _rigidbody.AddForce(moveDirection * moveForce , ForceMode.Force);
        
    }
    
    
}
