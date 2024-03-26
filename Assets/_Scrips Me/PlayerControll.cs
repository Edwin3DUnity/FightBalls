using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    [SerializeField, Range(0, 60)] private float moveForce = 2.5f;
    private Rigidbody _rigidbody;

    private float horizontal;
    private float vertical;

    [SerializeField] private GameObject focalPoint;
    
    
    [SerializeField] private bool powerUpActivated;
    [SerializeField] private float replusionForce = 80;


    [SerializeField] private GameObject[] powerUpIcon;
    [SerializeField] private float iconDurationTime = 10;
    
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
        PlayerFollow();
    }

    private void Movimiento()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        
        // _rigidbody.AddForce(Vector3.forward * vertical * moveForce , ForceMode.Force);
        // _rigidbody.AddForce(Vector3.right * horizontal * moveForce, ForceMode.Force);
        
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * vertical, ForceMode.Force);
        _rigidbody.AddForce(focalPoint.transform.right * moveForce * horizontal, ForceMode.Force);


    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUps"))
        {
            powerUpActivated = true;
            Destroy(other.gameObject);

            StartCoroutine("DurationIcon");
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
            Vector3 replusionDir = other.gameObject.transform.position - transform.position;

            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            
            enemyRigidbody.AddForce(replusionDir * replusionForce , ForceMode.Impulse);

        }
    }

    private void PlayerFollow()
    {
        foreach (GameObject powerUpIcons in powerUpIcon)
        {
            powerUpIcons.transform.position = transform.position + 0.5f * Vector3.down;

        }
        
            
        
        
    }

    IEnumerator DurationIcon()
    {
        foreach (GameObject powerUpsIcons in powerUpIcon)
        {
            powerUpsIcons.gameObject.SetActive(true);
            yield return new WaitForSeconds(iconDurationTime / powerUpIcon.Length);
            powerUpsIcons.gameObject.SetActive(false);

        }

        powerUpActivated = false;
    }
    
    
}
