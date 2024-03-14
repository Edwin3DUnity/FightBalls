using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContro : MonoBehaviour
{

    [SerializeField, Range(0, 20)] private float forceMove = 10;

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
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
      //  _rigidbody.AddForce(Vector3.forward * forceMove * vertical , ForceMode.Force);
      //  _rigidbody.AddForce(Vector3.right  * forceMove * horizontal, ForceMode.Force);
        
    
            _rigidbody.AddForce(focalPoint.transform.forward * forceMove * vertical, ForceMode.Force);
            _rigidbody.AddForce(focalPoint.transform.right * forceMove * horizontal , ForceMode.Force);
        
    }
}
