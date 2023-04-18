using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdWorldsPlugin;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AdWorlds utils = new AdWorlds();
        StartCoroutine(utils.runtimeGet(transform));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
