using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 20)] private float moveForce = 2;

    private Rigidbody _rigidbody;

    private float horizontal;
    private float vertical;


    [SerializeField] private GameObject focalPoint;

    public bool activedPowerUps;
    [SerializeField] private float forceReplusion = 25;

    [SerializeField] private float timeWaitActivedPowerUP = 15;


    public GameObject[] powerupsIndicators;
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


        //_rigidbody.AddForce(Vector3.forward * moveForce * vertical, ForceMode.Force);
        //_rigidbody.AddForce(Vector3.right * moveForce * horizontal, ForceMode.Force);
        
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * vertical, ForceMode.Force);
        _rigidbody.AddForce(focalPoint.transform.right * moveForce * horizontal, ForceMode.Force);
        
    }

    private void FollowPlayer()
    {
        foreach (GameObject indicator in powerupsIndicators)
        {
            indicator.transform.position = transform.position + 0.5f * Vector3.down;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))
        {
            activedPowerUps = true;
            Destroy(other.gameObject); 
            powerupsIndicators[0].SetActive(true);
            StartCoroutine("TimeWaitDesactiPowerUp");

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && activedPowerUps)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 replusionDir = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(replusionDir * forceReplusion, ForceMode.Impulse );
            
        }
    }


    IEnumerator TimeWaitDesactiPowerUp()
    {
        yield return new WaitForSeconds(timeWaitActivedPowerUP);

        activedPowerUps = false;
        powerupsIndicators[0].SetActive(false);

    }
}
