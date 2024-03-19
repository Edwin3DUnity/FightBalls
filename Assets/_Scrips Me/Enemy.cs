using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody _rigidbody;
    [SerializeField, Range(0, 30)] private float moveForce = 3;


    [SerializeField] private GameObject _player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = _player.transform.position - transform.position;
        
        _rigidbody.AddForce(moveDirection * moveForce , ForceMode.Force);


    }
}
