using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private Transform sphere;
    // Start is called before the first frame update
    void Start()
    {
        sphere = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        sphere.eulerAngles += new Vector3(0, 100, 0) * Time.deltaTime;
    }
}
