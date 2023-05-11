using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class billboard : MonoBehaviour
{
    public string url = @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSr4Fo2rTO4AovAp8Qpz4bg9p_UkHTmEkNXIQ&usqp=CAU";
    public Renderer r;
    void Start()
    {
        StartCoroutine(DownloadImage());
    }

    IEnumerator DownloadImage()
    {
        WWW l = new WWW(url);
        yield return l;

        r.material.color = Color.white;
        r.material.mainTexture = l.texture;
    }
}
