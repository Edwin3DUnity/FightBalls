using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 50)] private float moveForce = 2.5f;
    private Rigidbody _rigidbody;

    [SerializeField] private GameObject focalPoint;


    private float horizontal;
    private float vertical;

    [SerializeField] private bool powerUpActivated;
    [SerializeField] private float repulsionForce = 75;

    [SerializeField] private GameObject[] powerUpIcon;

    [SerializeField] private float timePowerUpIcon = 10;
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
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce *  vertical, ForceMode.Force);
        _rigidbody.AddForce(focalPoint.transform.right * moveForce * horizontal, ForceMode.Force);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))
        {
            powerUpActivated = true;
            
            Destroy(other.gameObject);

            StartCoroutine("TimePowerUp");

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
            Vector3 dirRepulsion = other.gameObject.transform.position - transform.position;

            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            
            enemyRigidbody.AddForce(dirRepulsion * repulsionForce, ForceMode.Impulse);


        }
    }

    private void FollowPlayer()
    {
        foreach (GameObject iconPower in powerUpIcon)
        {
            iconPower.gameObject.transform.position = transform.position + 0.5f * Vector3.down;
        }
        
    }


    IEnumerator TimePowerUp()
    {
        foreach (GameObject iconPower in powerUpIcon)
        {
            iconPower.gameObject.SetActive(true);
            yield return new WaitForSeconds(timePowerUpIcon / powerUpIcon.Length);
            iconPower.gameObject.SetActive(false);

        }

        powerUpActivated = false;
    }
}
