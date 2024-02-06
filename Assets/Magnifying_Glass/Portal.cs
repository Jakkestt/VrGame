using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Camera Main_Camera;
    private Camera Lens_Camera;

    private void Start()
    {
        //Lens_Camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //var M = transform.localToWorldMatrix * transform.worldToLocalMatrix * Main_Camera.transform.localToWorldMatrix;
        //Lens_Camera.transform = M;
    }
}
