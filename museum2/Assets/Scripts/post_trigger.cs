using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using TMPro;
using System.Text;

public class post_trigger : MonoBehaviour
{
    public GameObject postPage;
    public InputField titleInput, contentInput;
    public GameObject infotext;
    public GameObject Profile;

    public List<TextMeshPro> postTMPs;
    int step = 0;
    int trigstep = 0;

    public GameObject Map;

    int t = 0;

    void Start()
    {
        InvokeRepeating("realtime", 0f, 1f);
    }

    void Update()
    {
        if (trigstep == 1 && Input.GetKey(KeyCode.G)) {
            step = 1;
            postPage.SetActive(true);
            Map.GetComponent<MapController>().FlagOn("POST");
        }
    }

    void realtime() {
        if (trigstep == 1) {
            if (t % 3 == 0) StartCoroutine(UpdateInfo("post/update", ""));
        }
        else {
            if (t % 15 == 0) StartCoroutine(UpdateInfo("post/update", ""));
        }
        t++;
        if (t == 31) t = 1;
    }

    private void OnTriggerEnter(Collider other) {
        if (step == 0 && other.CompareTag("player")) {
            infotext.SetActive(true);
            trigstep = 1;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (step == 0 && other.CompareTag("player")) {
            infotext.SetActive(false);
            trigstep = 0;
        }
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }


    public void Send() {
        step = 0;

        if (titleInput.text.Equals("") || contentInput.text.Equals("")) return;

        string sendText = titleInput.text + "/" + contentInput.text;
        sendText = sendText.Replace("$", "");
        sendText = sendText.Replace("&", "");
        StartCoroutine(SendPost("post/upload?name=" + Profile.GetComponent<Profile>().nickname + "&text=" + sendText, ""));
        titleInput.text = "";
        contentInput.text = "";
        postPage.SetActive(false);
        Map.GetComponent<MapController>().FlagOff();
    }

    IEnumerator SendPost(string to, string query) {
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
            StartCoroutine(UpdateInfo("post/update", ""));
        }
    }

    public void Close() {
        step = 0;
        titleInput.text = "";
        contentInput.text = "";
        postPage.SetActive(false);
        Map.GetComponent<MapController>().FlagOff();
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
                if (chats.Length != 0) {
                    for (int i = 0; i < chats.Length; i++) {
                        string[] data = chats[i].Split('&');
                        postTMPs[i].text = StringDecode("제목 : " + data[1].Split('/')[0] + "\n내용 : "+ data[1].Split('/')[1] + "\n작성자 : " + data[0]);
                    }
                }
            }
            
        }
    }
}
