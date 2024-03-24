using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 30)] private float moveForce = 2.5f;
    private Rigidbody _rigidbody;


    private float horizontal;
    private float vertical;


    [SerializeField] private GameObject focalPoint;

    [SerializeField] private bool powerUPActivated;

    [SerializeField] private float replusionForce = 60;

    [SerializeField] private float timeWaitActivatedPowerUP = 10;


    [SerializeField] private GameObject[] indicatorPowerUPs;
    
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
        
        //_rigidbody.AddForce(Vector3.forward * vertical, ForceMode.Force);
        //_rigidbody.AddForce(Vector3.right * horizontal, ForceMode.Force);
        
        _rigidbody.AddForce(focalPoint.transform.forward *  moveForce * vertical, ForceMode.Force);
        _rigidbody.AddForce(focalPoint.transform.right * moveForce * horizontal, ForceMode.Force);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))
        {
            Destroy(other.gameObject);
            powerUPActivated = true;

            StartCoroutine("TimeWaitDesactPowerUP");
        }

        if (other.CompareTag("ZoneDeath"))
        {
            Destroy(gameObject);
            SceneManager.LoadSceneAsync("Prototype 4");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && powerUPActivated)
        {
           Rigidbody enemy =  collision.gameObject.GetComponent<Rigidbody>();

           Vector3 replutionDirection = enemy.transform.position - transform.position;
           
           enemy.AddForce(replutionDirection * replusionForce, ForceMode.Impulse);
           

        }

       
    }

    private void FollowPlayer()
    {
        foreach (GameObject indicator in indicatorPowerUPs)
        {
            indicator.transform.position = transform.position + 0.5f * Vector3.down;


        }
    }
    
    IEnumerator TimeWaitDesactPowerUP()
    {
        foreach (GameObject indicator in indicatorPowerUPs)
        {
            indicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(timeWaitActivatedPowerUP / indicatorPowerUPs.Length);
            indicator.gameObject.SetActive(false);
        }
        powerUPActivated = false;
        
    }

    private void DeathPlayer()
    {
        if (transform.position.y < 3)
        {
            Destroy(gameObject);
            SceneManager.LoadSceneAsync("Prototype 4");

        }
        
    }
}
