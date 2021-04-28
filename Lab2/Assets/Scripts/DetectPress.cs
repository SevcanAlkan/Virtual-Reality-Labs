using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectPress : MonoBehaviour
{
    private Shuttle shuttle;

    public InputAction Press;
    public InputAction Position;

    private Vector2 CurrentPosition;


    void Awake()
    {
        shuttle = GetComponent<Shuttle>();

        Press.performed += Press_Performed;

        Position.Enable();
        Position.performed += x => CurrentPosition = Position.ReadValue<Vector2>();
    }

    private void Press_Performed(InputAction.CallbackContext obj)
    {
        Ray r = Camera.main.ScreenPointToRay(CurrentPosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(r, out hitInfo) && hitInfo.collider.tag == "Shuttle")
        {
            shuttle.OpenDoors();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
