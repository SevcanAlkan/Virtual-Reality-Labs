using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TrackingEventHandler : DefaultTrackableEventHandler
{
    public UnityEvent OnOpenFound;
    public UnityEvent OnCloseFound;
    
    //private GameObject Ship = GameObject.Find("ImageTargetPlatform/Transport Shuttle_fbx");

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        Debug.LogWarning(mTrackableBehaviour.name);
        
        if (mTrackableBehaviour.name == "ImageTargetOpen")
        {
            OnOpenFound?.Invoke();
        } else if (mTrackableBehaviour.name == "ImageTargetClose")
        {
            OnCloseFound?.Invoke();
        }
    }
}
