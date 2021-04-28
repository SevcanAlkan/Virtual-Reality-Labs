using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Selectable currentSelection { get; set; }
    private SpeechInput speechInput;

    void Awake()
    {
        speechInput = FindObjectOfType<SpeechInput>();
    }
    public void Select(string objName)
    {
        Debug.Log(objName);
        
        GameObject obj;
        if((obj = GameObject.Find(objName)) != null)
        {
            currentSelection = obj.GetComponent<Selectable>();
            if (currentSelection == null)
            {
                Debug.Log(objName + " is not selectable");
            }
            else
            {
                //move camera to position to view the object
                Camera.main.transform.position = currentSelection.viewPos;
                //direct camera to look at the object
                Camera.main.transform.LookAt(currentSelection.transform.position);
                //change the handlers for the play and stop commands
                speechInput.ChangeHandler("play", currentSelection.GetComponent<Playable>().Play);
                speechInput.ChangeHandler("stop", currentSelection.GetComponent<Playable>().Stop);
                Debug.Log("selected " + objName);
            }
        }
        else
        {
            Debug.Log("Object " + objName + " not found");
        }
    }
}
