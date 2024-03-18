using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayaerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float moveForce = 2;



    private float horizontal;
    private float vertical;


    [SerializeField] private GameObject focalPoint;


    public bool ActivatePowerUp;

    [SerializeField, Range(0, 50)] private float repulsionForce = 20;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("Focal Point");

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }


    private void Movimiento()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        
        
       // _rigidbody.AddForce(Vector3.forward * moveForce * vertical, ForceMode.Force);
       // _rigidbody.AddForce(Vector3.forward * moveForce * horizontal, ForceMode.Force);
        
       _rigidbody.AddForce(focalPoint.transform.forward * moveForce * vertical, ForceMode.Force);
       _rigidbody.AddForce(focalPoint.transform.right * moveForce * horizontal, ForceMode.Force);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))
        {
            Destroy(other.gameObject);
            ActivatePowerUp = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && ActivatePowerUp )
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 repulsionDirection = collision.gameObject.transform.position - transform.position;

            
             Debug.Log("ENemigo" + enemyRigidbody.name);
            enemyRigidbody.AddForce(repulsionDirection * repulsionForce, ForceMode.Impulse);



        }
    }
}


