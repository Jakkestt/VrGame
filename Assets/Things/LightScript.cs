using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LightScript : MonoBehaviour
{
    private new Light light;
    public Color color1;
    public Color color2;
    public InputActionReference action;
    private Boolean toggle = false;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
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
                light.color = color1;
            } else
            {
                light.color = color2;
            }
        };
    }
}
