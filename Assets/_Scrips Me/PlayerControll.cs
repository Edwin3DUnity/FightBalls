using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{

    private Rigidbody _rigidbody;


    [SerializeField, Range(0, 50)] private float moveForce = 2;


    private float horizontal;
    private float vertical;


    [SerializeField] private GameObject focalPoint;


    public bool hasPowerUp;

    [SerializeField, Range(0, 30)] private float replutionForce = 5; 
    
    
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
        
        
        //_rigidbody.AddForce(Vector3.forward * moveForce * vertical, ForceMode.Force);
        //_rigidbody.AddForce(Vector3.right * moveForce * horizontal, ForceMode.Force);

        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * vertical, ForceMode.Force);
        _rigidbody.AddForce(focalPoint.transform.right * moveForce * horizontal , ForceMode.Force);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))
        {
            hasPowerUp = true;
            
            Destroy(other.gameObject);
            
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {


            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 dircetReplution = collision.gameObject.transform.position - transform.position; 
            
            enemyRigidbody.AddForce(dircetReplution *  replutionForce, ForceMode.Impulse);
            
            Debug.Log("EL jugador ha colisionado contra " + collision.gameObject + " y  tiene el power up a " + hasPowerUp);
            
            
            
        }
    }
}
