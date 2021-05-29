using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Animate : MonoBehaviour
{
    public Animator anim;

    public string TriggerKey;

    public string FirstTriggerName;
    public string SecondTriggerName;
    public string AnimatedStateName;

    public void TriggerAnim(string key)
    {
        if (key.Equals(FirstTriggerName)
            && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            anim.SetTrigger(FirstTriggerName);
        } else if (key.Equals(SecondTriggerName)
                   && anim.GetCurrentAnimatorStateInfo(0).IsName(AnimatedStateName))
        {
            anim.SetTrigger(SecondTriggerName);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(TriggerKey)
            && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            anim.SetTrigger(FirstTriggerName);
        } else if (Input.GetKeyDown(TriggerKey)
                   && anim.GetCurrentAnimatorStateInfo(0).IsName(AnimatedStateName))
        {
            anim.SetTrigger(SecondTriggerName);
        }
        
        // if (Application.platform == RuntimePlatform.WindowsPlayer 
        //     || Application.platform == RuntimePlatform.WindowsEditor)
        // {
        //    
        // } else if (Application.platform == RuntimePlatform.Android)
        // {
        //     for (int i = 0; i < Input.touchCount; i++)
        //     {
        //         if (Input.GetTouch(i).phase == TouchPhase.Began
        //             && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        //         {
        //             anim.SetTrigger(FirstTriggerName);
        //         } else if (Input.GetTouch(i).phase == TouchPhase.Began
        //                    && anim.GetCurrentAnimatorStateInfo(0).IsName(AnimatedStateName))
        //         {
        //             anim.SetTrigger(SecondTriggerName);
        //         }
        //     }
        // }
    }
}
