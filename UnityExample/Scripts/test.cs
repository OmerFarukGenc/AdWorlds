using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdWorldsPlugin;
public class test : MonoBehaviour
{
    AdWorlds plugin;
    // Start is called before the first frame update
    void Start()
    {
        plugin = new AdWorlds();
        plugin.generateObj(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
