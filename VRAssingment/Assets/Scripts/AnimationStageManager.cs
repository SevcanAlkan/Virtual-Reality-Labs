using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AnimationStageManager : MonoBehaviour
{

    public GameObject GPU;
    public int CurrentStage { get; private set; }
    public bool IsAnOperationRunning { get; private set; }

    private Animator GPUAnimator;
    private bool IsAnimatorLoaded = false;
    
    private readonly string CurrentStageName = "CurrentStage";
    private readonly string LastEnteredStageName = "LastEnteredStage";
    private readonly string IsAnOperationRunningName = "IsAnOperationRunning";


    private Dictionary<int, string> StageTriggers;
    
    void Start()
    {
        if (GPU != null && GPU.TryGetComponent(typeof(Animator), out Component animatorComponent))
        {
            GPUAnimator = (Animator) animatorComponent;
            IsAnimatorLoaded = true;
        }
        else
        {
            IsAnimatorLoaded = false;
            Debug.LogError($"GPU Animator couldn't loaded!");
        }

        StageTriggers = new Dictionary<int, string>(
            new Dictionary<int,string>() {
                {1, "Stage1"},
                {2, "Stage2"},
                {3, "Stage3"},
                {4, "Stage4"},
                {5, "Stage5"},
                {6, "Stage6"},
                {7, "Stage7"},
                {8, "Stage8"}
            });
    }

    void Update()
    {
        // CurrentStage = GPUAnimator.GetInteger(CurrentStageName);
        // IsAnOperationRunning = GPUAnimator.GetBool(IsAnOperationRunningName);
    }

    public void TriggerAnim(string action)
    {
        // get current state
        // if action is can do, do it
        // if not, do noting
        
        //check is an operation running
        //if not;
        //  disable all buttons and voice commands
        //  increase the current stage value
        //  trigger anim
        //  add delay for anim completion
        //  enable buttons
        //if there is an other animation is working;
        //  do nothing
        
        //Refresh values
        
        try
        {
            if (!IsAnimatorLoaded)
                return;

            CurrentStage = GPUAnimator.GetInteger(CurrentStageName);
            IsAnOperationRunning = GPUAnimator.GetBool(IsAnOperationRunningName);
            
            if (CurrentStage == 0)
            {
                CurrentStage++;
                GPUAnimator.SetInteger(CurrentStageName, CurrentStage);
            }

            Debug.Log($@"Current Stage: {CurrentStage.ToString()}
Action: {action}
Is Another Animation Running: {(IsAnOperationRunning ? "True": "False")}
            ");
            
            if (IsAnOperationRunning)
                return;

            switch (action)
            {
                case "MountOrRemoveAll":
                    
                    if(CurrentStage == 0)
                        return;
                    
                    for (int i = CurrentStage; i <= StageTriggers.Count; i++)
                    {
                        StartCoroutine(Trigger(i));
                        
                        if(i == 4)
                            return;
                    }
                    
                    break;
                case "NextStep":
                    StartCoroutine(Trigger(CurrentStage));
                    break;
                default:
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void StartOperation()
    {
        //Set IsAnOperationRunning property true
        GPUAnimator.SetBool(IsAnOperationRunningName, true);

        Debug.Log($"OPERATION STARTED!!!");
    }

    private void StopOperation()
    { 
        GPUAnimator.SetInteger(LastEnteredStageName, CurrentStage);
        //Increase Current State Number
        CurrentStage = GPUAnimator.GetInteger(CurrentStageName);

        CurrentStage++;
        
        if (CurrentStage > 8)
            CurrentStage = 0;
        
        // if (CurrentStage == 1)
        //     CurrentStage = 0;
        
        GPUAnimator.SetInteger(CurrentStageName, CurrentStage);
        
        //Set IsAnOperationRunning property false
        GPUAnimator.SetBool(IsAnOperationRunningName, false);
        
        Debug.Log($"OPERATION Finished!!!");
        Debug.Log($"Current Stage Updated: {CurrentStage.ToString()}");
    }

    private IEnumerator Trigger(int stage)
    {
        if (StageTriggers.TryGetValue(stage, out string triggerName))
        {
            StartOperation();
            
            Debug.Log($"Stage [{stage.ToString()}] triggered, trigger name [{triggerName}]");
            GPUAnimator.SetTrigger(triggerName);

            
            yield return new WaitForSeconds(1);
            
            StopOperation();
        }
    }

    private IEnumerator WaitAnimation(string triggerName)
    {
        while (GPUAnimator.GetCurrentAnimatorStateInfo(0).IsName(triggerName) &&
               GPUAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            //Wait every frame until animation has finished
            yield return null;
        }
    }
}
