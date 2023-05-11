using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class makeObjectGrabbable : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    void Start()
    {

        obj.AddComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
