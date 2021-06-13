using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognizer : MonoBehaviour
{
    public string NextStepSpeech;
    public string MountOrRemoveAllSpeech;

    public GameObject AnimationTriggerHolder;
    private AnimationStageManager _AnimationStageManager;
    
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    
    void Start()
    {
        _AnimationStageManager = AnimationTriggerHolder.GetComponent<AnimationStageManager>();
        
        CreateActions();
        
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void CreateActions()
    {
        actions.Add(NextStepSpeech, () =>
        {
            _AnimationStageManager.TriggerAnim("NextStep");
        });
        actions.Add(MountOrRemoveAllSpeech, () =>
        {
            _AnimationStageManager.TriggerAnim("MountOrRemoveAll");
        });
    }
    
    private void RecognizedSpeech(PhraseRecognizedEventArgs eventArgs)
    {
        Debug.Log(eventArgs.text);
        
        actions[eventArgs.text].Invoke();
    }
}