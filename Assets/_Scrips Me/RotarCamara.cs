using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarCamara : MonoBehaviour
{

    [SerializeField, Range(0, 50)] private float speedRotation = 25;
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            transform.Rotate(Vector3.up * -speedRotation * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.G))
        {
            transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);
        }
    }
}
