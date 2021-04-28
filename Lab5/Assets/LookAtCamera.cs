using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [Tooltip("The camera to look at")]
    public Camera LookAtCam;
    [Tooltip("Use negative value to always look at the camera")]
    public float LookAtDistance;
    void Update()
    {
        if(LookAtDistance < 0 || (transform.position - LookAtCam.transform.position).magnitude <
            LookAtDistance)
        {
            transform.LookAt(LookAtCam.transform.position, transform.parent.up);
        }
        else
        {
            //when not looking at camera return to zero orientation
            transform.rotation = Quaternion.identity;
        }
    }
}
