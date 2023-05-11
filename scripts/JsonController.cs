using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class JsonController : MonoBehaviour
{
    public string url;
    public Text data;

    public class Data
    {
        public string name;
    }
    void Update()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if(request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Success");
                var text = request.downloadHandler.text;
                Data d = JsonUtility.FromJson<Data>(text);
                data.text = d.name;
                Debug.Log(data.text);
            }

        }

    }
}
