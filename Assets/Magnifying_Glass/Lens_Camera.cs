using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lens_Camera : MonoBehaviour
{
    public Transform Main_Camera;
    private Transform Camera;

    private void Start()
    {
        Camera = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.rotation = Main_Camera.rotation;
        float dist = 
    }
}
