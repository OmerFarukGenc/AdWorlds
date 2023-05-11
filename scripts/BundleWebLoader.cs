using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//https://drive.google.com/uc?export=download&id=1hF8tl9Y4VrhlQKp-fJIeEZROBVw1-oEh
using System;


public class BundleWebLoader : MonoBehaviour
{
    /*
    void Start()
    {
        StartCoroutine(GetAssetBundle());
    }
    
    IEnumerator GetAssetBundle()
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("https://drive.google.com/uc?export=download&id=1hF8tl9Y4VrhlQKp-fJIeEZROBVw1-oEh");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            Debug.Log(bundle.AllAssetNames()[0]);
            Instantiate(bundle.LoadAsset("kub"));
        }
    }
    */

    public string bundleUrl = "https://drive.google.com/uc?export=download&id=1hF8tl9Y4VrhlQKp-fJIeEZROBVw1-oEh";
    public string assetName = "Cube";
    IEnumerator Start()
    {
        using (WWW web = new WWW(bundleUrl))
        {
            yield return web;
            AssetBundle remoteAssetBundle = web.assetBundle;
            if (remoteAssetBundle == null)
            {
                Debug.LogError("Failed to download AssetBundle!");
                yield break;
            }
           
            Instantiate(remoteAssetBundle.LoadAsset(assetName));
            remoteAssetBundle.Unload(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
