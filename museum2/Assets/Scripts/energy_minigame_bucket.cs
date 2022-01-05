using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class energy_minigame_bucket : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject Building;
    int step = 0;

    public GameObject info1, info2, info3;

    public AudioSource pushSound;

    public Button startButton, explainButton, finishButton;

    public AudioSource startSound, gameSound, endSound;

    public List<Vector3> left_result_v, right_result_v;

    public Text resultText;

    public List<GameObject> leftb, rightb;

    public GameObject a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11;

    public GameObject o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11;
    public GameObject x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11;

    public List<GameObject> olist, xlist;

    public List<string> leftans;

    public bool f1 = false, f2 = false, f3 = false, f4 = false, f5 = false, f6 = false, f7 = false, f8 = false, f9 = false, f10 = false, f11 = false;

    int count = 0;

    public GameObject Profile;

    public Text buttonText;

    void Start()
    {
        // StartGame();
    }

    void Update()
    {
        if (step == 3) {
            Debug.Log(a11.transform.localPosition);
            if (!f1 && Vector3.Distance(a1.transform.localPosition, new Vector3(-500f, -317f, 0f)) < 130f) {
                leftb.Add(a1);
                pushSound.Play();
                count++;
                a1.SetActive(false);
                f1 = true;
            }
            else if (!f1 && Vector3.Distance(a1.transform.localPosition, new Vector3(500f, -317f, 0f)) < 130f) {
                rightb.Add(a1);
                pushSound.Play();
                count++;
                a1.SetActive(false);
                f1 = true;
            }

            if (!f2 && Vector3.Distance(a2.transform.localPosition, new Vector3(-500f, -317f, 0f)) < 130f) {
                leftb.Add(a2);
                pushSound.Play();
                count++;
                a2.SetActive(false);
                f2 = true;
            }
            else if (!f2 && Vector3.Distance(a2.transform.localPosition, new Vector3(500f, -317f, 0f)) < 130f) {
                rightb.Add(a2);
                pushSound.Play();
                count++;
                a2.SetActive(false);
                f2 = true;
            }

            if (!f3 && Vector3.Distance(a3.transform.localPosition, new Vector3(-500f, -317f, 0f)) < 130f) {
                leftb.Add(a3);
                pushSound.Play();
                count++;
                a3.SetActive(false);
                f3 = true;
            }
            else if (!f3 && Vector3.Distance(a3.transform.localPosition, new Vector3(500f, -317f, 0f)) < 130f) {
                rightb.Add(a3);
                pushSound.Play();
                count++;
                a3.SetActive(false);
                f3 = true;
            }

            if (!f4 && Vector3.Distance(a4.transform.localPosition, new Vector3(-500f, -317f, 0f)) < 130f) {
                leftb.Add(a4);
                pushSound.Play();
                count++;
                a4.SetActive(false);
                f4 = true;
            }
            else if (!f4 && Vector3.Distance(a4.transform.localPosition, new Vector3(500f, -317f, 0f)) < 130f) {
                rightb.Add(a4);
                pushSound.Play();
                count++;
                a4.SetActive(false);
                f4 = true;
            }

            if (!f5 && Vector3.Distance(a5.transform.localPosition, new Vector3(-500f, -317f, 0f)) < 130f) {
                leftb.Add(a5);
                pushSound.Play();
                count++;
                a5.SetActive(false);
                f5 = true;
            }
            else if (!f5 && Vector3.Distance(a5.transform.localPosition, new Vector3(500f, -317f, 0f)) < 130f) {
                rightb.Add(a5);
                pushSound.Play();
                count++;
                a5.SetActive(false);
                f5 = true;
            }

            if (!f6 && Vector3.Distance(a6.transform.localPosition, new Vector3(-500f, -317f, 0f)) < 130f) {
                leftb.Add(a6);
                pushSound.Play();
                count++;
                a6.SetActive(false);
                f6 = true;
            }
            else if (!f6 && Vector3.Distance(a6.transform.localPosition, new Vector3(500f, -317f, 0f)) < 130f) {
                rightb.Add(a6);
                pushSound.Play();
                count++;
                a6.SetActive(false);
                f6 = true;
            }

            if (!f7 && Vector3.Distance(a7.transform.localPosition, new Vector3(-500f, -317f, 0f)) < 130f) {
                leftb.Add(a7);
                pushSound.Play();
                count++;
                a7.SetActive(false);
                f7 = true;
            }
            else if (!f7 && Vector3.Distance(a7.transform.localPosition, new Vector3(500f, -317f, 0f)) < 130f) {
                rightb.Add(a7);
                pushSound.Play();
                count++;
                a7.SetActive(false);
                f7 = true;
            }

            if (!f8 && Vector3.Distance(a8.transform.localPosition, new Vector3(-500f, -317f, 0f)) < 130f) {
                leftb.Add(a8);
                pushSound.Play();
                count++;
                a8.SetActive(false);
                f8 = true;
            }
            else if (!f8 && Vector3.Distance(a8.transform.localPosition, new Vector3(500f, -317f, 0f)) < 130f) {
                rightb.Add(a8);
                pushSound.Play();
                count++;
                a8.SetActive(false);
                f8 = true;
            }

            if (!f9 && Vector3.Distance(a9.transform.localPosition, new Vector3(-500f, -317f, 0f)) < 130f) {
                leftb.Add(a9);
                pushSound.Play();
                count++;
                a9.SetActive(false);
                f9 = true;
            }
            else if (!f9 && Vector3.Distance(a9.transform.localPosition, new Vector3(500f, -317f, 0f)) < 130f) {
                rightb.Add(a9);
                pushSound.Play();
                count++;
                a9.SetActive(false);
                f9 = true;
            }

            if (!f10 && Vector3.Distance(a10.transform.localPosition, new Vector3(-500f, -317f, 0f)) < 130f) {
                leftb.Add(a10);
                pushSound.Play();
                count++;
                a10.SetActive(false);
                f10 = true;
            }
            else if (!f10 && Vector3.Distance(a10.transform.localPosition, new Vector3(500f, -317f, 0f)) < 130f) {
                rightb.Add(a10);
                pushSound.Play();
                count++;
                a10.SetActive(false);
                f10 = true;
            }

            if (!f11 && Vector3.Distance(a11.transform.localPosition, new Vector3(-500f, -317f, 0f)) < 130f) {
                leftb.Add(a11);
                pushSound.Play();
                count++;
                a11.SetActive(false);
                f11 = true;
            }
            else if (!f11 && Vector3.Distance(a11.transform.localPosition, new Vector3(500f, -317f, 0f)) < 130f) {
                rightb.Add(a11);
                pushSound.Play();
                count++;
                a11.SetActive(false);
                f11 = true;
            }

            if (count == 11) {
                finishButton.gameObject.SetActive(true);
            }
        }
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }

    public void StartGame() {
        count = 0;
        step = 0;

        olist = new List<GameObject>();
        olist.Add(o1); olist.Add(o2); olist.Add(o3); olist.Add(o4); olist.Add(o5); olist.Add(o6); olist.Add(o7); olist.Add(o8); olist.Add(o9); olist.Add(o10); olist.Add(o11); 
        xlist = new List<GameObject>();
        xlist.Add(x1); xlist.Add(x2); xlist.Add(x3); xlist.Add(x4); xlist.Add(x5); xlist.Add(x6); xlist.Add(x7); xlist.Add(x8); xlist.Add(x9); xlist.Add(x10); xlist.Add(x11); 

        leftb = new List<GameObject>();
        rightb = new List<GameObject>();

        left_result_v = new List<Vector3>();
        right_result_v = new List<Vector3>();

        left_result_v.Add(new Vector3(-560f, -125f, 0f));
        left_result_v.Add(new Vector3(-360f, -125f, 0f));

        left_result_v.Add(new Vector3(-464f, 32f, 0f));
        left_result_v.Add(new Vector3(-673f, 32f, 0f));
        left_result_v.Add(new Vector3(-274.5f, 32f, 0f));

        left_result_v.Add(new Vector3(-570f, 193f, 0f));
        left_result_v.Add(new Vector3(-371f, 193f, 0f));

        left_result_v.Add(new Vector3(-746f, 252f, 0f));
        left_result_v.Add(new Vector3(-221f, 252f, 0f));
        
        right_result_v.Add(new Vector3(393f - 974f, 350f, 0f));
        right_result_v.Add(new Vector3(603f - 974f, 350f, 0f));

        right_result_v.Add(new Vector3(-360f + 974f, -125f, 0f));
        right_result_v.Add(new Vector3(-560f + 974f, -125f, 0f));

        right_result_v.Add(new Vector3(-274.5f + 974f, 32f, 0f));
        right_result_v.Add(new Vector3(-673f + 974f, 32f, 0f));
        right_result_v.Add(new Vector3(-464f + 974f, 32f, 0f));

        right_result_v.Add(new Vector3(-371f + 974f, 193f, 0f));
        right_result_v.Add(new Vector3(-570f + 974f, 193f, 0f));

        right_result_v.Add(new Vector3(-485f + 974f, 252f, 0f));
        right_result_v.Add(new Vector3(-221f + 974f, 252f, 0f));

        right_result_v.Add(new Vector3(603f, 350f, 0f));
        right_result_v.Add(new Vector3(393f, 350f, 0f));

        leftans = new List<string>();

        leftans.Add("bk energy");
        leftans.Add("bk coal");
        leftans.Add("bk hi");

        finishButton.gameObject.SetActive(false);
        startSound.Play();
        info1.SetActive(true);
        step0();
        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.transform.position = new Vector3(907f, 0f, 565f);
        Building.SetActive(false);
    }

    public void step0() {
        step = 0;
        info1.SetActive(true);
        info2.SetActive(false);
    }

    public void step0_explain() {
        step = 1;
        info1.SetActive(false);
        info2.SetActive(true);
    }

    bool FindLeft(string nm) {
        for (int i = 0; i < leftb.Count; i++) {
            if (leftb[i].Equals(nm)) return true;
        }
        return false;
    }

    public void OnGame() {
        startSound.Stop();
        gameSound.Play();
        step = 3;
        info1.SetActive(false);
        info3.SetActive(true);
        buttonText.text = StringDecode("결과 확인하기");
    }

    public void Result() {
        step = 4;
        buttonText.text = StringDecode("게임 종료하기");
        gameSound.Stop();
        endSound.Play();

        int leftpoint = 0;
        int rightpoint = 0;

        int corrcount = 0;

        int oxpoint = 0;

        for (int i = 0; i < leftb.Count; i++) {
            leftb[i].SetActive(true);
            leftb[i].transform.localPosition = left_result_v[leftpoint];

            if (leftans.Contains(leftb[i].gameObject.name)) {
                olist[oxpoint].SetActive(true);
                xlist[oxpoint].SetActive(false);
                olist[oxpoint].transform.localPosition = left_result_v[leftpoint];
                corrcount++;
            }
            else {
                olist[oxpoint].SetActive(false);
                xlist[oxpoint].SetActive(true);
                xlist[oxpoint].transform.localPosition = left_result_v[leftpoint];
            }
            leftpoint++;
            oxpoint++;
        }

        for (int i = 0; i < rightb.Count; i++) {
            rightb[i].SetActive(true);
            rightb[i].transform.localPosition = right_result_v[rightpoint];

            if (!leftans.Contains(rightb[i].gameObject.name)) {
                olist[oxpoint].SetActive(true);
                xlist[oxpoint].SetActive(false);
                olist[oxpoint].transform.localPosition = right_result_v[rightpoint];
                corrcount++;
            }
            else {
                olist[oxpoint].SetActive(false);
                xlist[oxpoint].SetActive(true);
                xlist[oxpoint].transform.localPosition = right_result_v[rightpoint];
            }
            rightpoint++;
            oxpoint++;
        }

        
        /*for (int i = 0; i < blist.Count; i++) {
            if (leftb.Contains(blist[i].name.ToString())) {
            if (FindLeft(blist[i].name)) {
                blist[i].transform.localPosition = left_result_v[leftpoint];

                if (leftans.Contains(blist[i].name.ToString())) {
                    olist[i].SetActive(true);
                    xlist[i].SetActive(false);
                    olist[i].transform.localPosition = left_result_v[leftpoint];
                    corrcount++;
                }
                else {
                    olist[i].SetActive(false);
                    xlist[i].SetActive(true);
                    xlist[i].transform.localPosition = left_result_v[leftpoint];
                }
                leftpoint++;
            }
            else (rightb.Contains(blist[i].name.ToString())) {
                
                blist[i].transform.localPosition = right_result_v[rightpoint];

                if (!leftans.Contains(blist[i].name.ToString())) {
                    olist[i].SetActive(true);
                    xlist[i].SetActive(false);
                    olist[i].transform.localPosition = right_result_v[rightpoint];
                    corrcount++;
                }
                else {
                    olist[i].SetActive(false);
                    xlist[i].SetActive(true);
                    xlist[i].transform.localPosition = right_result_v[rightpoint];
                }
                rightpoint++;
            }
        }*/

        resultText.text = StringDecode("맞은 개수 " + corrcount.ToString() + "/11");

        if (corrcount == 11) {
            if (Profile.GetComponent<Profile>().badge_subinfo3[1] == '0') {
                Profile.GetComponent<Profile>().badge_subinfo3[1] = '1';
                Profile.GetComponent<Profile>().CheckBadge();
            }
        }
    }

    public void PressButton() {
        if (step == 3) {
            Result();
        }
        else if (step == 4) {
            OutGame();
        }
    }

    public void OutGame() {
        Building.SetActive(true);
        step = 0;
        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.transform.position = new Vector3(879.58f, 1f, 640f);
        mainCamera.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        info3.SetActive(false);
        endSound.Stop();
        finishButton.gameObject.SetActive(false);
        mainCamera.transform.position = new Vector3(879.58f, 1f + 4f, 640f - 8f);
        mainCamera.GetComponent<ThirdCamera>().enabled = true;
        GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = true;
        gameObject.SetActive(false);
    }
}
