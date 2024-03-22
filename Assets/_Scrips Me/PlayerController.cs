using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField, Range(0, 20)] private float moveForce = 2.5f;

    private float horizontal;
    private float vertical;

    [SerializeField] private GameObject pointFocal;

    [SerializeField] private bool pickUPPowerUp;

    [SerializeField] private float replusionForce = 60;

    [SerializeField] private float timeWaitActivePowerUp = 15;


    public GameObject[] powerUpsIndicators;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        pointFocal = GameObject.Find("Focal Point");

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
        
     //   _rigidbody.AddForce(Vector3.forward * moveForce * vertical, ForceMode.Force);
     //   _rigidbody.AddForce(Vector3.right * moveForce * horizontal, ForceMode.Force);
       
        _rigidbody.AddForce(pointFocal.transform.forward * moveForce * vertical);
        _rigidbody.AddForce(pointFocal.transform.right * moveForce * horizontal);
     
     
    }

    private void FollowPlayer()
    {
        foreach (GameObject indicator in powerUpsIndicators)
        {
            indicator.transform.position = transform.position + 0.5f * Vector3.down;
        }
        
            
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))
        {
           
            pickUPPowerUp = true;
            Destroy(other.gameObject);

            StartCoroutine("TimeWaitDesactPowerUP");

        }

        if (other.CompareTag("ZoneDeath"))
        {
            SceneManager.LoadSceneAsync("Prototype 4");
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && pickUPPowerUp)
        {
            Rigidbody enemy = other.gameObject.GetComponent<Rigidbody>();

            Vector3 directionReplution = enemy.transform.position - transform.position;
            enemy.AddForce(directionReplution * replusionForce, ForceMode.Impulse);
            
        }
    }

    IEnumerator TimeWaitDesactPowerUP()
    {
        foreach (GameObject indicator in powerUpsIndicators)
        {
            indicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(timeWaitActivePowerUp / powerUpsIndicators.Length);
            indicator.gameObject.SetActive(false);
        }

        pickUPPowerUp = false;
    }

    private void DeathPlayer()
    {
        if (transform.position.y < 2)
        {
            Destroy(gameObject);
            SceneManager.LoadSceneAsync("Prototype 4");
        }
    }
    
}
