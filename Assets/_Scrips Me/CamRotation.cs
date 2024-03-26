using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{

    [SerializeField, Range(0, 360)] private float rotateCam = 45;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camRotations();
    }

    private void camRotations()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * - rotateCam * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * rotateCam * Time.deltaTime);
        }
        
    }
}
