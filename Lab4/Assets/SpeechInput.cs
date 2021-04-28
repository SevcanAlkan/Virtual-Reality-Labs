using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows.Speech;
using System.Linq;

public class SpeechInput : MonoBehaviour
{
    [Serializable()]
    public class CommandHandler
    {
        public string phrase;
        public UnityEvent handler;
    }
    
    public List<CommandHandler> commands;
    private KeywordRecognizer recognizer;

    void Start()
    {
        
    }

    void Awake()
    {
        recognizer = new KeywordRecognizer(commands.Select(x => x.phrase).ToArray());
        recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;

    }
    
    private void OnEnable()
    {
        recognizer.Start();
    }
    private void OnDisable()
    {
        recognizer.Stop();
    }
    
    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        CommandHandler ch = commands.First(x => x.phrase == args.text);
        if(ch != null && ch.handler != null)
        {
            ch.handler.Invoke();
        }
    }
    
    public void ChangeHandler(string phrase, UnityAction newHandler)
    {
        UnityEvent ue = commands.First(x => x.phrase == phrase).handler;
        ue.RemoveAllListeners();
        ue.AddListener(newHandler);
    }
}
