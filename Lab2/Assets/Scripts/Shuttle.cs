using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuttle : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoors()
    {
        Debug.Log("Shuttle.Open");
        animator.SetTrigger("Open");
    }
}
