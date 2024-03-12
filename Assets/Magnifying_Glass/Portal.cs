using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Camera Main_Camera;
    private Camera Lens_Camera;
    private float Min_Fov = 10.0f;
    private float Max_Fov = 75.0f;

    private void Start()
    {
        Lens_Camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Lens_Camera.transform.rotation = Main_Camera.transform.rotation;
        float distance = Vector3.Distance(Main_Camera.transform.position, Lens_Camera.transform.position);
        float fov = Max_Fov - Max_Fov * distance;
        Lens_Camera.fieldOfView = fov;
        float dz = Lens_Camera.transform.eulerAngles.z - transform.eulerAngles.z;
        transform.Rotate(new Vector3(0.0f, 0.0f, dz));
    }
}
