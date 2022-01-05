using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using System.Text;

public class CoinEgg : MonoBehaviour
{
    public GameObject map;
    public GameObject goldpf, silverpf;
    public GameObject linepf1, linepf2, linepf3;
    public GameObject eggpf1, eggpf2, eggpf3, eggpf4, eggpf5;

    public List<GameObject> eggs;

    public GameObject[] lines;
    public GameObject[] justs;
    public GameObject Profile;

    public GameObject coinPopup;
    public Text coinText;

    public bool eatflag = false;

    void Start()
    {
        eggs = new List<GameObject>();
        eatflag = false;

        lines = new GameObject[3]; lines[0] = linepf1; lines[1] = linepf2; lines[2] = linepf3;
        justs = new GameObject[5]; justs[0] = eggpf1; justs[1] = eggpf2; justs[2] = eggpf3; justs[3] = eggpf4; justs[4] = eggpf5;

        map = GameObject.Find("MAP");

        InvokeRepeating("realtime", 0f, 3f);
    }

    void Update()
    {   
        if (eatflag) {
            if (Input.GetKey(KeyCode.Escape)) {
                ClosePopup();
            }
        }
    }

    public void GetCoin(int number) {
        int coin = 0;
        eatflag = true;

        // gold
        if (0 <= number && number <= 2) {
            coin = 15; //3 
            coinText.text = StringDecode("골드 코인에그를 발견하여" + "\n" + coin.ToString() + "코인을 획득하셨습니다.");
        }
        else if (3 <= number && number <= 7) {
            coin = 10; //5
            coinText.text = StringDecode("실버 코인에그를 발견하여" + "\n" + coin.ToString() + "코인을 획득하셨습니다.");
        }
        else if (8 <= number && number <= 14) {
            coin = 5; //7
            coinText.text = StringDecode("패턴 코인에그를 발견하여" + "\n" + coin.ToString() + "코인을 획득하셨습니다.");
        }
        else {
            coin = 3; //7
            coinText.text = StringDecode("컬러 코인에그를 발견하여" + "\n" + coin.ToString() + "코인을 획득하셨습니다.");
        }

        StartCoroutine(EatEgg("egg/eat?num=" + number.ToString(), ""));

        coinPopup.SetActive(true);
        map.GetComponent<MapController>().FlagOn("COINEGG_POPUP");
        Profile.GetComponent<Profile>().Coin(coin);

        Profile.GetComponent<Profile>().badge_subinfo2 += 1;
        if (Profile.GetComponent<Profile>().badge_state[6] == '0') {
            Profile.GetComponent<Profile>().CheckBadge();
        }
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }

    IEnumerator EatEgg(string to, string query) {
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
            Debug.Log("updating...");
            StartCoroutine(UpdateInfo("egg/update", ""));
        }
    }

    public void ClosePopup() {
        coinPopup.SetActive(false);
        coinText.text = "";
        eatflag = false;

        map.GetComponent<MapController>().FlagOff();
    }

    void realtime() {
        StartCoroutine(UpdateInfo("egg/update", ""));
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
                Debug.Log(result);
                string[] playerdata = result.Split('?');

                foreach (string pd in playerdata) {
                    string[] data = pd.Split('&');
                    if (data.Length != 3) continue;
                    int idx = eggs.FindIndex(x => x.name.Equals("egg-" + data[0]));
                    if (idx == -1) {
                        GameObject temp;

                        if (data[1].Equals("15")) temp = Instantiate(goldpf);
                        else if (data[1].Equals("10")) temp = Instantiate(silverpf);
                        else if (data[1].Equals("5")) {
                            int r = UnityEngine.Random.Range(0, 3);
                            temp = Instantiate(lines[r]);
                        }
                        else {
                            int r = UnityEngine.Random.Range(0, 5);
                            temp = Instantiate(justs[r]);
                        }
                       
                        temp.name = "egg-" + data[0];

                        float x = float.Parse(data[2].Split('/')[0]);
                        float z = float.Parse(data[2].Split('/')[1]);
                        
                        temp.transform.position = new Vector3(x, 3.5f, z);
                        eggs.Add(temp);
                    } 
                    
                    else {
                        float x = float.Parse(data[2].Split('/')[0]);
                        float z = float.Parse(data[2].Split('/')[1]);

                        eggs[idx].transform.position = new Vector3(x, 3.5f, z);
                    }
                }
            }
        }
    }
}
