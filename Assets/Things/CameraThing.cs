using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraThing : MonoBehaviour
{
    public InputActionReference action;
    private Boolean toggle = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            toggle = !toggle;
            if (toggle)
            {
                this.transform.position = new Vector3(-18, 16, -38);
            } else {
                this.transform.position = new Vector3(0, 1, -4);
            }
        };
    }
}
