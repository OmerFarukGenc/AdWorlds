using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using UnityEngine;
using System.Xml.Linq;
using System.Collections;
using System.IO;
using Microsoft.Cci;
using UnityEngine.Networking;

namespace AdWorldsPlugin
{
    public class AdWorlds
    {
        private static readonly HttpClient client = new HttpClient();
        public int c;
        string url = "https://oaks-advantages-coordinated-voters.trycloudflare.com";
        private Dictionary<string, string> AdIDs = new Dictionary<string, string>();
        public async Task<String> exampleReqToReceiveAd() {
            var response = await client.GetAsync("http://localhost:3000/api/custAddvert/2");
            String strRes = await response.Content.ReadAsStringAsync();
            
            return "test";
        }
        public async Task<GameObject> receiveRandAdAsync()
        {
            var responseBytes = await client.GetByteArrayAsync("http://www.example.com");
            GameObject currentAD =  responseToGameObject(responseBytes);
            return currentAD;
        }
        private GameObject responseToGameObject(Byte[] bytes)
        {
            return new GameObject();
        }
        private GameObject loadObj()
        {
            return Resources.Load("example") as GameObject; 
        }
        public async Task<GameObject> receiveSpecificAdAsync(String id)
        {
            var responseBytes = await client.GetByteArrayAsync("http://www.example.com" + id);
            GameObject currentAD = responseToGameObject(responseBytes);//add await when requests added
            return currentAD;
        }
        public bool updateExcludedTags(String[] tags)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> exampleReq(String token)

        {
            var values = new Dictionary<string, string>
              {
                  { "thing1", "hello" },
                  { "thing2", "world" }
              };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://www.example.com", content);

            var responseString = await response.Content.ReadAsStringAsync();
            return responseString != null;//or any response validation
        }
        public void generateObjNoDeform(MonoBehaviour mono)
        {
            mono.StartCoroutine(runtimeGet(mono.transform, (asset,adID) => {
                GameObject generatedObj = UnityEngine.Object.Instantiate(asset, Vector3.zero, Quaternion.identity) as GameObject;
                generatedObj.transform.SetParent(mono.transform, false);
                float scale = generatedObj.transform.lossyScale.x;
                if (scale > generatedObj.transform.lossyScale.y)
                    scale = generatedObj.transform.lossyScale.y;
                if (scale > generatedObj.transform.lossyScale.z)
                    scale = generatedObj.transform.lossyScale.z;
                generatedObj.transform.localScale = new Vector3(scale / generatedObj.transform.lossyScale.x, scale / generatedObj.transform.lossyScale.y, scale / generatedObj.transform.lossyScale.z);
                AdIDs.Add(generatedObj.name, adID);
            }));

            }
        public void generateObj(MonoBehaviour mono)
        {
            mono.StartCoroutine(runtimeGet(mono.transform, (asset, adID) => {
                GameObject generatedObj = UnityEngine.Object.Instantiate(asset, Vector3.zero, Quaternion.identity) as GameObject;
                generatedObj.transform.SetParent(mono.transform, false);
                AdIDs.Add(generatedObj.name, adID);

            }));
        }
        
        public IEnumerator runtimeGet(Transform parentTransform, System.Action<UnityEngine.Object,String> callback)
        {
            /*string path = "Assets/Resources/backendurl.txt";

            StreamReader reader = new StreamReader(path);
            String url=reader.ReadToEnd();
            MonoBehaviour.print(url);
            reader.Close();*/
            string randomUrl=url;
            string adID = "";
            using (WWW web = new WWW(url + "/api/getRandomAdId"))
            {
                yield return web;

               // MonoBehaviour.print(web);
                MonoBehaviour.print(web.text);
                adID = web.text.Replace("\"", "");
                randomUrl = url + "/api/getAdFromId/" + adID;

               // MonoBehaviour.print(web.);


            }


            using (WWW web = new WWW(randomUrl))
            {

                yield return web;
                MonoBehaviour.print(randomUrl);
                AssetBundle remoteAssetBundle = web.assetBundle;
                var names = remoteAssetBundle.GetAllAssetNames();

                if (remoteAssetBundle == null)
                {
                    Debug.LogError("Failed to download AssetBundle!");
                    yield break;
                }

                foreach (string name in names)
                {
                    MonoBehaviour.print(name);
                    yield return null;

                    callback(remoteAssetBundle.LoadAsset(name), adID);

                }
                remoteAssetBundle.Unload(false);
            }

        }
        private async void getRandID()
        {
            var response = await client.GetAsync("http://localhost:3000/api/custAddvert/2");
           // return response.Content.ToString();
        }
        public void sendInteraction(string objectName)
        {
            string ID = AdIDs[objectName];
            //get ad ID from dict
            //send req with ID    
        }
    }

}
