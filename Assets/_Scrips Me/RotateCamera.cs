using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float rotationSpeed = 15;

    private float horizontal;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // horizontal = Input.GetAxis("Horizontal");
        
        //transform.Rotate(Vector3.up , rotationSpeed * horizontal * Time.deltaTime);

        if (Input.GetKey(KeyCode.F))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
            Debug.Log("presionado f");
        }

        if (Input.GetKey(KeyCode.G))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
