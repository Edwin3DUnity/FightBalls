using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarCamara : MonoBehaviour
{
    [SerializeField, Range(0, 25)] private float speed = 15;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up *  -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
