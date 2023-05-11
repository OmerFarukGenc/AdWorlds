using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdWorldsPlugin;

public class parentScript : MonoBehaviour
{
    AdWorlds aw;
    // Start is called before the first frame update
    void Start()
    {
        aw = new AdWorlds();
        aw.generateObj(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
