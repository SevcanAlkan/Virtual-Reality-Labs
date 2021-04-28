using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Playable : MonoBehaviour
{
    public UnityEvent OnPlay;
    public UnityEvent OnStop;
    public void Play()
    {
        if(OnPlay != null)
        {
            OnPlay.Invoke();
        }
    }
    public void Stop()
    {
        if(OnStop != null)
        {
            OnStop.Invoke();
        }
    }
}
