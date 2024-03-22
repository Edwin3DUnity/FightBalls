using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField, Range(0, 20)] private float moveForce = 2.5f;

    private float horizontal;
    private float vertical;

    [SerializeField] private GameObject pointFocal;
    
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
}
