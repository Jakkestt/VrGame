using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public LevelScript level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToLower() == "score")
        {
            level.score();
        }
        if (other.tag.ToLower() == "lose")
        {
            level.lose();
        }
    }
}
