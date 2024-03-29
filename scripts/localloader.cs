using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class localloader : MonoBehaviour
{
    // Start is called before the first frame update,
    public string assetName = "Cube";
    public string bundleName = "testbundle";
    void Start()
    {
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));

        if (localAssetBundle == null)
        {
            Debug.LogError("fail");
            return;
        }

        GameObject asset = localAssetBundle.LoadAsset<GameObject>(assetName);
        Instantiate(asset);
        localAssetBundle.Unload(false);
    }

    
}
