using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField, Range(0, 20)] private float rotationSpeed = 15;

    private float horizontal;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        transform.Rotate(Vector3.up , rotationSpeed * Time.deltaTime * horizontal);
        
    }
    
}
