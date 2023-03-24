using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using UnityEngine;
using System.Xml.Linq;
using Newtonsoft.Json;
namespace AdWorldsPlugin
{
    public class AdWorlds
    {
        private static readonly HttpClient client = new HttpClient();
        public int c;
        public async Task<String> exampleReqToReceiveAd() {
            var response = await client.GetAsync("http://localhost:3000/api/custAddvert/2");
            String strRes = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(strRes);
            MonoBehaviour.print(json["data"][0]["addid"]);
            return json["data"][0]["addid"];
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
        public void generateObjNoDeform(Transform parentTransform)
        {
            GameObject child = loadObj();
            GameObject generatedObj = UnityEngine.Object.Instantiate(child, Vector3.zero, Quaternion.identity) as GameObject;
            generatedObj.transform.SetParent(parentTransform.transform, false);
            float scale = generatedObj.transform.lossyScale.x;
            if (scale > generatedObj.transform.lossyScale.y)
                scale = generatedObj.transform.lossyScale.y;
            if (scale > generatedObj.transform.lossyScale.z)
                scale = generatedObj.transform.lossyScale.z;
            generatedObj.transform.localScale = new Vector3(scale / generatedObj.transform.lossyScale.x, scale / generatedObj.transform.lossyScale.y, scale / generatedObj.transform.lossyScale.z);
        }
        public void generateObj(Transform parentTransform)
        {
            GameObject child = loadObj();//change with received gameobject from backend
            GameObject myBrick = UnityEngine.Object.Instantiate(child, Vector3.zero, Quaternion.identity) as GameObject;
            myBrick.transform.SetParent(parentTransform.transform, false);
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
    }
}
