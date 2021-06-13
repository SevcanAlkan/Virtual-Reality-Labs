using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class StartAndStopGPU : MonoBehaviour
{
    public GameObject Fan1;
    public GameObject Fan2;
    public GameObject Fan3;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void Toggle()
    {
        if (Fan1 != null)
        {
            CanRotate fan1RotationController = Fan1.GetComponent<CanRotate>();
            fan1RotationController.Toggle();
        }
        
        if (Fan2 != null)
        {
            CanRotate fan2RotationController = Fan2.GetComponent<CanRotate>();
            fan2RotationController.Toggle();
        }
        
        if (Fan3 != null)
        {
            CanRotate fan3RotationController = Fan3.GetComponent<CanRotate>();
            fan3RotationController.Toggle();
        }
    }
}
