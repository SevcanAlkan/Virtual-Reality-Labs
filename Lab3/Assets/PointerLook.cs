using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerLook : MonoBehaviour
{
    public float MouseSensitivity = 20.0f;
    public InputAction Look;
    public InputAction Attitude;
    private Transform childCamera;
    private void Awake()
    {
        //find the camera as a component of a child object
        childCamera = GetComponentInChildren<Camera>().transform;
        Look.Enable();
        Look.performed += x => RotateLook(x.ReadValue<Vector2>());
        
        if (AttitudeSensor.current != null)
        {
            InputSystem.EnableDevice(AttitudeSensor.current);
            Attitude.Enable();
            Attitude.performed += Attitude_Performed;
        }
        else
        {
            Debug.Log("No gyro detected."); 
        }

    }
    
    private void Attitude_Performed(InputAction.CallbackContext obj)
    {
        Quaternion gyroAttitude = obj.ReadValue<Quaternion>();
        ApplyGyroRotation(gyroAttitude);
    }
    void ApplyGyroRotation(Quaternion attitude)
    {
        childCamera.rotation = attitude;
        childCamera.Rotate(0f, 0f, 180f, Space.Self);
        childCamera.Rotate(90f, 180f, 0f, Space.World); 
    }

    private void RotateLook(Vector2 delta)
    {
        //horizontal movement rotates around vertical axis
        //transform.Rotate(0, delta.x * Time.deltaTime * MouseSensitivity, 0);
        //childCamera.Rotate(-delta.y * Time.deltaTime * MouseSensitivity, 0, 0);
        transform.Rotate(0, delta.x, 0);
        childCamera.Rotate(-delta.y, 0, 0);
    }
}
