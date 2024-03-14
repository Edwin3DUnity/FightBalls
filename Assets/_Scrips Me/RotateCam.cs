using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    [SerializeField, Range(0, 60), Tooltip("velocidad de rotacionde la camara")]
    private float rotacionSpeed = 15;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * -rotacionSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * rotacionSpeed * Time.deltaTime);
        }
        
    }
}
