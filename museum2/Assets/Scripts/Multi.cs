using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class Multi : MonoBehaviour
{
    public GameObject pp1, pp2, pp3, pp4, pp5, pp6;
    public List<GameObject> playerprefabs;
    public GameObject thisPlayer;
    public List<GameObject> players;

    public string playername;

    public GameObject Profile;

    float speed = 1f;

    void Start()
    {
        playerprefabs = new List<GameObject>(); playerprefabs.Add(pp1);playerprefabs.Add(pp2);playerprefabs.Add(pp3);playerprefabs.Add(pp4);playerprefabs.Add(pp5);playerprefabs.Add(pp6);
        players = new List<GameObject>();
    }

    public void StartMulti() {
        playername = Profile.GetComponent<Profile>().nickname;
        thisPlayer = Instantiate(playerprefabs[Profile.GetComponent<Profile>().player]);
        thisPlayer.tag = "player";
        thisPlayer.name = playername;
        thisPlayer.GetComponent<keyboard>().enabled = false;
        thisPlayer.GetComponent<FirstView>().enabled = true;
        thisPlayer.transform.position = new Vector3(-13f, 4f, -78f);
        Camera.main.GetComponent<CameraRotate>().enabled = true;
        Camera.main.GetComponent<CameraRotate>().target = thisPlayer;

        // login to the session
        StartCoroutine(Upload("gamein?name=" + playername + "&player=" + Profile.GetComponent<Profile>().player.ToString(), ""));

        InvokeRepeating("realtime", 0.05f, 0.05f);
    }

    public void RestartMulti() {
        playername = Profile.GetComponent<Profile>().nickname;
        StartCoroutine(Upload("gameout?name=" + playername, ""));
        CancelInvoke("realtime");

        Vector3 lastpos = thisPlayer.transform.position;
        Quaternion lastrot = thisPlayer.transform.rotation;
        bool k1 = thisPlayer.GetComponent<keyboard>().enabled, f1 = thisPlayer.GetComponent<FirstView>().enabled;
        Destroy(thisPlayer);
        
        thisPlayer = Instantiate(playerprefabs[Profile.GetComponent<Profile>().player]);
        thisPlayer.tag = "player";
        thisPlayer.name = playername;
        thisPlayer.GetComponent<keyboard>().enabled = k1;
        thisPlayer.GetComponent<FirstView>().enabled = f1;
        thisPlayer.transform.position = lastpos;
        thisPlayer.transform.rotation = lastrot;
        Camera.main.GetComponent<CameraRotate>().enabled = true;
        Camera.main.GetComponent<CameraRotate>().target = thisPlayer;

        StartCoroutine(Upload("gamein?name=" + playername + "&player=" + Profile.GetComponent<Profile>().player.ToString(), ""));

        players.Clear();
        InvokeRepeating("realtime", 1f, 0.05f);
    }

    public void StopMulti() {
        StartCoroutine(Upload("gameout?name=" + playername, ""));
        CancelInvoke("realtime");
        Destroy(thisPlayer);
        Camera.main.GetComponent<CameraRotate>().enabled = false;
        Camera.main.GetComponent<ThirdCamera>().enabled = false;
        Camera.main.GetComponent<SoccerCamera>().enabled = false;

        Camera.main.transform.position = new Vector3(144.0966f, 17.78041f, -215.2413f);
        Camera.main.transform.rotation = Quaternion.Euler(-13.716f, -33.864f, 0f);
    }

    public void StopMultiPersonalIsland() {
        StartCoroutine(Upload("gameout?name=" + playername, ""));
        CancelInvoke("realtime");
    }

    public void RestartMultiPersonalIsland() {
        playername = Profile.GetComponent<Profile>().nickname;
        StartCoroutine(Upload("gameout?name=" + playername, ""));
        CancelInvoke("realtime");

        players.Clear();
        StartCoroutine(Upload("gamein?name=" + playername + "&player=" + Profile.GetComponent<Profile>().player.ToString(), ""));
        InvokeRepeating("realtime", 1f, 0.05f);
    }

    void Update()
    {
        // realtime();
    }

    void OnApplicationQuit()
    {
        StartCoroutine(Upload("gameout?name=" + playername, ""));
    }

    void realtime() {
        string query = "update?name=" + playername + "&";
        Vector3 pos = thisPlayer.transform.position;
        Vector3 rot = thisPlayer.transform.rotation.eulerAngles;
        query += "px=" + Round3(pos.x).ToString() + "&py=" + Round3(pos.y).ToString() + "&pz=" + Round3(pos.z).ToString() + "&";
        query += "rx=" + Round3(rot.x).ToString() + "&ry=" + Round3(rot.y).ToString() + "&rz=" + Round3(rot.z).ToString();
        StartCoroutine(UpdateInfo(query, ""));
    }

    float Round3(float x) {
        return Mathf.RoundToInt(x * 100000f) / 100000f;
    }

    IEnumerator Upload(string to, string query) {
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
            // Debug.Log(www.downloadHandler.text);
        }
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
            string result = www.downloadHandler.text;
            if (!result.Equals("-1")) {
                string[] playerdata = result.Split('?');

                foreach (string pd in playerdata) {
                    string[] data = pd.Split('&');
                    if (data.Length != 8) continue;
                    if (data[1].Equals("")) continue;

                    // exception
                    try {
                        float.Parse(data[1]);
                        float.Parse(data[2]);
                        float.Parse(data[3]);
                    }
                    catch {
                        continue;
                    }

                    if (data[0].Equals(playername)) continue;
                    int idx = players.FindIndex(x => x.name.Equals(data[0]));
                    if (idx == -1) {
                        GameObject temp = Instantiate(playerprefabs[int.Parse(data[7])]);
                        temp.name = data[0];
                        temp.transform.position = new Vector3(float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]));
                        temp.transform.rotation = Quaternion.Euler(float.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]));
                        players.Add(temp);
                    }
                    
                    else {
                        // players[idx].transform.position = Vector3.MoveTowards(pos, new Vector3(float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3])), speed);
                        // players[idx].transform.rotation = Quaternion.RotateTowards(rot, new Quaternion(float.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]), 0f), speed);
                        players[idx].transform.position = new Vector3(float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]));
                        players[idx].transform.rotation = Quaternion.Euler(float.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]));
                    }
                }

                for (int i = 0; i < players.Count; i++) {
                    int idx = Array.FindIndex(playerdata, x => x.Contains(players[i].name));
                    if (idx == -1) {
                        Destroy(players[i]);
                        players.RemoveAt(i);
                    }
                }
            }
        }
    }
}
