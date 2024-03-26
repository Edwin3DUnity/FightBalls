using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{

    [SerializeField, Range(0, 15)] private float moveForce = 2;

    private Rigidbody _rigidbody;

    private float horizontal;
    private float vertical;

    private GameObject focalPoint;

    [SerializeField] private bool catchPowerUp;

    [SerializeField] private float repulsionForce = 65;


    public GameObject[] powerUpsIndicator;
    [SerializeField] private float indicatorTime = 10;
    
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
        followPlayer();
    }

    private void FixedUpdate()
    {
        
    }

    private void Movimiento()
    {
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
  
       // _rigidbody.AddForce(Vector3.forward * moveForce * horizontal  , ForceMode.Force);
       // _rigidbody.AddForce(Vector3.right * moveForce * vertical , ForceMode.Force);
        
       _rigidbody.AddForce(focalPoint.transform.forward * moveForce * vertical, ForceMode.Force);
       _rigidbody.AddForce(focalPoint.transform.right * moveForce * horizontal, ForceMode.Force);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))
        {
            Destroy(other.gameObject);
            catchPowerUp = true;

            StartCoroutine("TimeIndicatorVisible");

        }

        if (other.CompareTag("ZoneDeath"))
        {
            SceneManager.LoadSceneAsync("Prototype 4");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && catchPowerUp)
        {
            Vector3 replusionDir = other.gameObject.transform.position - transform.position;

            Rigidbody enemyRig = other.gameObject.GetComponent<Rigidbody>();

            enemyRig.AddForce(replusionDir * repulsionForce , ForceMode.Impulse);


        }
    }



    IEnumerator TimeIndicatorVisible()
    {
        foreach (GameObject indicator in powerUpsIndicator)
        {
            indicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(indicatorTime / powerUpsIndicator.Length);
            indicator.gameObject.SetActive(false);

        }

        catchPowerUp = false;
    }

    private void followPlayer()
    {
        foreach (GameObject indicator in powerUpsIndicator)
        {
            indicator.transform.position = transform.position + 0.5f * Vector3.down;
        }
        
    }
}
