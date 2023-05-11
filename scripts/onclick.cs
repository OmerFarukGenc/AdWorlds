using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class onclick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<XRGrabInteractable>().selectEntered.AddListener(delegate { test(); });
    }
    void test()
    {
        Debug.Log("asd");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
