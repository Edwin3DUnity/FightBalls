using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0, 15)] private float moveForce = 2.5f;
    private Rigidbody _rigidbody;

    private float horizontal;
    private float vertical;

    [SerializeField] private GameObject focalPoint;

    [SerializeField] private bool powerUpActivated;

    [SerializeField, Range(0, 300)] private float replusionForce = 65;

    [SerializeField] private GameObject[] powerUpsIndicator;
    [SerializeField] private float powerUpsDurationTime = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        playerFollow();
    }

    private void FixedUpdate()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
     //   _rigidbody.AddForce(Vector3.forward * moveForce * vertical, ForceMode.Force);
      //  _rigidbody.AddForce(Vector3.right * moveForce * horizontal, ForceMode.Force);
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * vertical, ForceMode.Force);
        _rigidbody.AddForce(focalPoint.transform.right * moveForce * horizontal, ForceMode.Force);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))
        {
            
            Destroy(other.gameObject);
            powerUpActivated = true;

            StartCoroutine("DurationPowerUp");
        }

        if (other.CompareTag("ZoneDeath"))
        {
            SceneManager.LoadSceneAsync("Prototype 4");
        }
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && powerUpActivated)
        {
            Rigidbody enemyRigd = other.gameObject.GetComponent<Rigidbody>()  ;
            
            Vector3 replusionDir = other.gameObject.transform.position - transform.position;
            
            enemyRigd.AddForce(replusionDir * replusionForce , ForceMode.Impulse);
            

        }
    }


    IEnumerator DurationPowerUp()
    {
        foreach (GameObject indicator in powerUpsIndicator)
        {
            indicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpsDurationTime / powerUpsIndicator.Length);
            indicator.gameObject.SetActive(false);

        }
        powerUpActivated = false;
        
    }

    private void playerFollow()
    {
        foreach (GameObject indicator in powerUpsIndicator)
        {
            indicator.transform.position = transform.position + 0.5f * Vector3.down;

        }
    }
    
}
