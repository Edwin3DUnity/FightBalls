using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField, Range(0, 25)] private float moveForce = 2;

    private Rigidbody _rigidbody;

    private float horizontal;

    private float vertical;


    [SerializeField] private GameObject focalPoint;
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
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
     //   _rigidbody.AddForce(Vector3.forward * moveForce * vertical, ForceMode.Force);
      //  _rigidbody.AddForce(Vector3.right * moveForce * horizontal, ForceMode.Force );
    
        _rigidbody.AddForce(focalPoint.transform.forward * vertical * moveForce , ForceMode.Force);
        _rigidbody.AddForce(focalPoint.transform.right * moveForce * horizontal, ForceMode.Force);

    }
    
}
