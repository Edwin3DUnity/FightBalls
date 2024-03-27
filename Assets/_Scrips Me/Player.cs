using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0, 50)] private float moveForce = 2.6f;
    private Rigidbody _rigidbody;

    private GameObject focalPoint;


    private float horizontal;
    private float vertical;

    [SerializeField] private bool powerIconActivate;

    [SerializeField] private float replusionForce = 75;

    [SerializeField] private GameObject[] powerUpsIndicators;
    [SerializeField] private float indicatorTime = 12;
    
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
         FollowPlayer();
    }


    private void Movimiento()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        
        
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * vertical, ForceMode.Force);
        _rigidbody.AddForce(focalPoint.transform.right * moveForce * horizontal, ForceMode.Force);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))
        {
            powerIconActivate = true;
            Destroy(other.gameObject);

            StartCoroutine("TimeIndicator");
        }

        if (other.CompareTag("ZoneDeath"))
        {
            SceneManager.LoadSceneAsync("Prototype 4");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && powerIconActivate)
        {
            Vector3 replusionDirection = other.gameObject.transform.position - transform.position;

            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            
            enemyRigidbody.AddForce(replusionDirection * replusionForce , ForceMode.Impulse);


        }
    }


    IEnumerator TimeIndicator()
    {
        foreach (GameObject indicator in powerUpsIndicators)
        {
            indicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(indicatorTime / powerUpsIndicators.Length);
            indicator.gameObject.SetActive(false);


        }

        powerIconActivate = false;
    }


    private void FollowPlayer()
    {
        foreach (GameObject indicator in powerUpsIndicators)
        {
            indicator.transform.position = transform.position;
        }
        
        
    }
    
}
