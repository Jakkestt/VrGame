using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketScript : MonoBehaviour
{
    private bool grabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGrabbed(bool g)
    {
        grabbed = g;
    }

    public bool GetGrabbed() { return grabbed; }
}
