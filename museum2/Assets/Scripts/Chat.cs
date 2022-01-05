using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using System.Text;

public class Chat : MonoBehaviour
{
    public Text chattext;
    public InputField chatinput;

    public GameObject Profile; 
    public GameObject Map;

    string thisname;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }

    public void Init() 
    {
        thisname = Profile.GetComponent<Profile>().nickname;
        InvokeRepeating("realtime", 0f, 1f);
    }

    public void Send() {
        CancelInvoke("CloseChatInput");
        string sendText = chatinput.text;

        if (!sendText.Equals("")) {
            sendText = sendText.Replace("$", "");
            sendText = sendText.Replace("&", "");
            StartCoroutine(SendChat("chat/upload?name=" + thisname + "&text=" + sendText, ""));
        }
        chatinput.text = "";
        chatinput.ActivateInputField();
    }

    IEnumerator SendChat(string to, string query) {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        if (!query.Equals("")) {
            formData.Add(new MultipartFormDataSection(query));
        }

        UnityWebRequest www = UnityWebRequest.Post("http://158.247.221.17:8000/" + to, formData);
        yield return www.SendWebRequest();

        if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError)) {
            Debug.Log(www.error);
        }
        else {
            StartCoroutine(UpdateInfo("chat/update", ""));
        }
    }

    void realtime() {
        StartCoroutine(UpdateInfo("chat/update", ""));
    }

    IEnumerator UpdateInfo(string to, string query) {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        if (!query.Equals("")) {
            formData.Add(new MultipartFormDataSection(query));
        }

        UnityWebRequest www = UnityWebRequest.Post("http://158.247.221.17:8000/" + to, formData);
        yield return www.SendWebRequest();

        if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError)) {
            Debug.Log(www.error);
        }
        else {
            if (!www.downloadHandler.text.Equals("")) {
                string[] chats = www.downloadHandler.text.Split('$');
                string bstr = chats[0].Split('&')[0] + " : " + chats[0].Split('&')[1];
                for (int i = 1; i < chats.Length; i++) {
                    string[] data = chats[i].Split('&');
                    bstr += "\n" + data[0] + " : " + data[1];
                }
                chattext.text = StringDecode(bstr);
            }
            
        }
    }
}
