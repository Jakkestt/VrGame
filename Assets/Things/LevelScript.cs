using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LevelScript : MonoBehaviour
{
    public GameObject pLight;
    public GameObject sLight;
    public Transform cube;
    public RacketScript racket;
    public Ball ball;
    public TextScript text;
    private bool game = false;
    private uint gScore = 0;

    internal void lose()
    {
        gScore = 0;
        ball.transform.position = new Vector3(2f, 1f, 0f);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    internal void score()
    {
        gScore++;
        print(gScore);
    }

    // Start is called before the first frame update
    void Start()
    {
        pLight.GetComponent<Light>().enabled = false;
        sLight.GetComponent<Light>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (racket.GetGrabbed() && !game)
        {
            pLight.GetComponent<Light>().enabled = true;
            sLight.GetComponent<Light>().enabled = false;
            game = true;
        } else if (game) {
            cube.position = new Vector3(100f, 100f, 100f);
        }
        text.SetScore(gScore);
    }
}
