using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private GameObject player;

    [SerializeField, Range(0, 50)] private float moveForece = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccionMovimiento = (player.transform.position - transform.position).normalized ;
        
        _rigidbody.AddForce(direccionMovimiento * moveForece , ForceMode.Force);
        
    }
}
