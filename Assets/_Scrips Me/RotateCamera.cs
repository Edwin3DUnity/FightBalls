using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField, Range(0, 360)] private float rotationVel = 45;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up *  -rotationVel * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * rotationVel * Time.deltaTime);
        }
    }
    
}
