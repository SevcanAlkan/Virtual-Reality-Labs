using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognizer : MonoBehaviour
{
    public string LeftLegSpeech1;
    public string LeftLegSpeech2;
    public string RightLegSpeech1;
    public string RightLegSpeech2;
    public string HeadSpeech1;
    public string HeadSpeech2;
    public string LeftArmSpeech1;
    public string LeftArmSpeech2;
    public string RightArmSpeech1;
    public string RightArmSpeech2;
    
    private Animate leftArmScript;
    private Animate rightArmScript;
    private Animate headScript;
    private Animate leftLegScript;
    private Animate rightLegScript;
    
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    
    void Start()
    {
        LoadObjects();

        CreateActions();
        
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void LoadObjects()
    {
        GameObject leftArm = GameObject.FindWithTag("LeftArm");
        GameObject rightArm = GameObject.FindWithTag("RightArm");
        GameObject head = GameObject.FindWithTag("Head");
        GameObject leftLeg = GameObject.FindWithTag("LeftLeg");
        GameObject rightLeg = GameObject.FindWithTag("RightLeg");
        
        if(leftArm != null)
            leftArmScript = leftArm.GetComponent<Animate>();
        
        if(rightArm != null)
            rightArmScript = rightArm.GetComponent<Animate>();

        if(head != null)
            headScript = head.GetComponent<Animate>();
        
        if(leftLeg != null)
            leftLegScript = leftLeg.GetComponent<Animate>();

        if(rightLeg != null)
            rightLegScript = rightLeg.GetComponent<Animate>();
    }

    private void CreateActions()
    {
        actions.Add(LeftLegSpeech1, () =>
        {
            leftLegScript.TriggerAnim(leftLegScript.FirstTriggerName);
        });
        actions.Add(LeftLegSpeech2, () =>
        {
            leftLegScript.TriggerAnim(leftLegScript.SecondTriggerName);
        });
        
        actions.Add(RightLegSpeech1, () =>
        {
            rightLegScript.TriggerAnim(rightLegScript.FirstTriggerName);
        });
        actions.Add(RightLegSpeech2, () =>
        {
            rightLegScript.TriggerAnim(rightLegScript.SecondTriggerName);
        });
        
        actions.Add(HeadSpeech1, () =>
        {
            headScript.TriggerAnim(headScript.FirstTriggerName);
        });
        actions.Add(HeadSpeech2, () =>
        {
            headScript.TriggerAnim(headScript.SecondTriggerName);
        });
        
        actions.Add(LeftArmSpeech1, () =>
        {
            leftArmScript.TriggerAnim(leftArmScript.FirstTriggerName);
        });
        actions.Add(LeftArmSpeech2, () =>
        {
            leftArmScript.TriggerAnim(leftArmScript.SecondTriggerName);
        });
        
        actions.Add(RightArmSpeech1, () =>
        {
            rightArmScript.TriggerAnim(rightArmScript.FirstTriggerName);
        });
        actions.Add(RightArmSpeech2, () =>
        {
            rightArmScript.TriggerAnim(rightArmScript.SecondTriggerName);
        });
    }
    
    private void RecognizedSpeech(PhraseRecognizedEventArgs eventArgs)
    {
        Debug.Log(eventArgs.text);
        
        actions[eventArgs.text].Invoke();
    }
}