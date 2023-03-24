using AdWorldsPlugin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        AdWorlds utils = new AdWorlds();
        utils.generateObjNoDeform(transform);
    }

    void Update()
    {
    }
}
