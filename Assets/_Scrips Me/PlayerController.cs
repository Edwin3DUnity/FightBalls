using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(0, 50)] private float moveForce = 18;

    private Rigidbody _rigidbody;

    private float vertical;
    private float horizontal;

   [SerializeField] private GameObject focalPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        focalPoint =  GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        
        //_rigidbody.AddForce(Vector3.forward * moveForce * vertical);
        //_rigidbody.AddForce(Vector3.right * moveForce * horizontal);
        
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * vertical, ForceMode.Force);
        _rigidbody.AddForce(focalPoint.transform.right * moveForce * horizontal, ForceMode.Force);
        
    }
}
