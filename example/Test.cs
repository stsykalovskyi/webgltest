using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class Message
{
    public bool success;
    public string message;
}

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("Request");
            StartCoroutine(GetRequest("http://localhost:1080/test"));
        }
    }

    IEnumerator GetRequest(string uri) {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)) {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
 
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
 
            if (webRequest.isNetworkError) {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else {
                Message message = JsonUtility.FromJson<Message>(webRequest.downloadHandler.text);
                Debug.Log(message.message);
                Debug.Log(message.success);
            }
        }
    }
}
