using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    [SerializeField, Range(0, 200)] private float speedRotation = 25;

  
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotacion();
    }

    private void Rotacion()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * - speedRotation * Time.deltaTime);
            
        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);
        }
    }
}
