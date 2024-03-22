using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float rotationAngle = 45;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
          transform.Rotate(Vector3.up * - rotationAngle * Time.deltaTime);  
        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * rotationAngle * Time.deltaTime);
        }
    }
}
