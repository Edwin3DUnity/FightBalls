using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField, Range(0, 15)] private float moveForce = 3;

    [SerializeField] private GameObject player;
    
    
    
    
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
        
        _rigidbody.AddForce(moveDirection * moveForce , ForceMode.Force);
        
        
    }
}
