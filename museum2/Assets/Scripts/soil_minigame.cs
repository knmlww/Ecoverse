using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class soil_minigame : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject Building;

    public int step = 0;
    public Image subback;
    public Text subtitle;

    public GameObject info1, info2, info3, info4, info5;
    public Text roundText;
    // public Button finalButton;

    public GameObject fpb1, fpb2, fpb3, fpb4, fpb5, fpb6, fpb7, fpb8, fpb9;
    public GameObject fl1, fl2, fl3, fl4, fl5;
    public GameObject ff1, ff2;

    public Button startButton, explainButton, howtoButton;

    public AudioSource startSound, gameSound, endSound;

    public GameObject trigger1, trigger2, trigger3;

    GameObject fff1, fff2, fff3;

    Vector3 f1pos = new Vector3(-5.7f, 4f, 1030.06f), f2pos = new Vector3(0.6f, 4f, 1030.06f), f3pos = new Vector3(6.9f, 4f, 1030.06f);

    public int corrpointer;

    List<GameObject> Flowers;

    int corr1, corr2, corr3;

    public RawImage o1, o2, o3, x1, x2, x3;
    public Text resultText;

    public GameObject Profile;


    void Start()
    {
        Flowers = new List<GameObject>();
        Flowers.Add(fl1); Flowers.Add(fl2); Flowers.Add(fl3); Flowers.Add(fl4); Flowers.Add(fl5);
        // StartGame();
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }

    void Update()
    {
        if (step == 1 || step == 2) {
            if (Input.GetKey(KeyCode.Escape)) {
                step0();
            }
        }
    }

    public void StartGame() {
        corrpointer = 2;
        startSound.Play();
        info1.SetActive(true);
        step0();
        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.transform.position = new Vector3(0f, 1f, 1025f);
        mainCamera.GetComponent<ThirdCamera>().enabled = false;
        mainCamera.transform.position = new Vector3(0f, 8.02f, 1022.418f);
        mainCamera.transform.Rotate(new Vector3(40f, 0f, 0f));
    }

    public void step0() {
        info1.SetActive(true);
        info2.SetActive(false);
        info3.SetActive(false);
        step = 0;
    }

    public void step0_explain() {
        step = 1;
        info1.SetActive(false);
        info2.SetActive(true);
    }

    public void step0_howto() {
        step = 2;
        info1.SetActive(false);
        info3.SetActive(true);
    }

    public void OnGame() {
        subback.gameObject.SetActive(true);
        subtitle.text = StringDecode("인간과 식물에게 질병을 일으키는 중금속이 아닌 물질을 고르세요!");
        startSound.Stop();
        gameSound.Play();
        step = 3;
        info1.SetActive(false);
        info4.SetActive(true);
        roundText.text = "Round 1";

        GameStep1();
    }

    public void CheckAns(int slt) {
        if (step == 3) {
            if (slt == 1) {
                Flowers[corrpointer].SetActive(false);
                corrpointer++;
                Flowers[corrpointer].SetActive(true);
                corr1 = 1;
            }
            else {
                Flowers[corrpointer].SetActive(false);
                corrpointer--;
                Flowers[corrpointer].SetActive(true);
                corr1 = 0;
            }
            step++;
            Destroy(fff1); Destroy(fff2); Destroy(fff3);
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(0f, 1f, 1025f);
            GameStep2();
        }

        else if (step == 4) {
            if (slt == 3) {
                Flowers[corrpointer].SetActive(false);
                corrpointer++;
                Flowers[corrpointer].SetActive(true);
                corr2 = 1;
            }
            else {
                Flowers[corrpointer].SetActive(false);
                corrpointer--;
                Flowers[corrpointer].SetActive(true);
                corr2 = 0;
            }
            Destroy(fff1); Destroy(fff2); Destroy(fff3);
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(0f, 1f, 1025f);
            step++;
            GameStep3();
        }

        else if (step == 5) {
            if (slt == 2) {
                Flowers[corrpointer].SetActive(false);
                corrpointer++;
                corr3 = 1;
            }
            else {
                Flowers[corrpointer].SetActive(false);
                corrpointer--;
                corr3 = 0;
            }
            Destroy(fff1); Destroy(fff2); Destroy(fff3);
            step++;
            Result();
        }
    }

    public void GameStep1() {
        Flowers[corrpointer].SetActive(true);
        fff1 = Instantiate(fpb1);
        fff1.transform.position = f1pos;
        fff2 = Instantiate(fpb2);
        fff2.transform.position = f2pos;
        fff3 = Instantiate(fpb3);
        fff3.transform.position = f3pos;
    }

    public void GameStep2() {
        roundText.text = "Round 2";
        fff1 = Instantiate(fpb4);
        fff1.transform.position = f1pos;
        fff2 = Instantiate(fpb5);
        fff2.transform.position = f2pos;
        fff3 = Instantiate(fpb6);
        fff3.transform.position = f3pos;
    }

    public void GameStep3() {
        roundText.text = "Round 3";
        fff1 = Instantiate(fpb8);
        fff1.transform.position = f1pos;
        fff2 = Instantiate(fpb7);
        fff2.transform.position = f2pos;
        fff3 = Instantiate(fpb9);
        fff3.transform.position = f3pos;
    }

    public void Result() {
        mainCamera.transform.position = new Vector3(-247.05f, 6f, 1068.9f);
        mainCamera.transform.Rotate(new Vector3(-40f, 0f, 0f));

        subback.gameObject.SetActive(false);

        if (corr1 == 1) o1.gameObject.SetActive(true);
        else x1.gameObject.SetActive(true);

        if (corr2 == 1) o2.gameObject.SetActive(true);
        else x2.gameObject.SetActive(true);

        if (corr3 == 1) o3.gameObject.SetActive(true);
        else x3.gameObject.SetActive(true);

        if (corr1 + corr2 + corr3 >= 2){
            ff1.SetActive(false);
            ff2.SetActive(true);
            resultText.text = StringDecode("꽃 피우기\n★ 성공 ★");
        }
        else {
            ff1.SetActive(true);
            ff2.SetActive(false);
            resultText.text = StringDecode("꽃 피우기\n실패...");
        }

        subtitle.text = "";
        info4.SetActive(false);
        info5.SetActive(true);
        gameSound.Stop();
        endSound.Play();

        if (corr1 == 1 && corr2 == 1 && corr3 == 1) {
            if (Profile.GetComponent<Profile>().badge_state[0] == '0') {
                Profile.GetComponent<Profile>().badge_state[0] = '1';
                Profile.GetComponent<Profile>().BadgePopup(0);
            }
        }
    }

    public void OutGame() {
        Building.SetActive(true);
        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.transform.position = new Vector3(-88f, 1f, 640f);
        info5.SetActive(false);
        o1.gameObject.SetActive(false); o2.gameObject.SetActive(false); o3.gameObject.SetActive(false);
        x1.gameObject.SetActive(false); x2.gameObject.SetActive(false); x3.gameObject.SetActive(false);
        endSound.Stop();
        mainCamera.transform.position = new Vector3(-88f, 1f + 4f, 640f - 8f);
        mainCamera.GetComponent<ThirdCamera>().enabled = true;
        gameObject.SetActive(false);
    }
}
