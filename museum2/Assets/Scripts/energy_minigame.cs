using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class energy_minigame : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject Building;

    public int step = 0;
    public Text qtext;

    public GameObject info1, info2, info4, info5;
    // public Button finalButton;

    public Button startButton, explainButton;

    public AudioSource startSound, gameSound, endSound;

    public GameObject trigger1, trigger2;

    int corr1, corr2, corr3, corr4, corr5;
    int ans1 = 0, ans2 = 1, ans3 = 1, ans4 = 0, ans5 = 1; 

    public RawImage o1, o2, o3, o4, o5, x1, x2, x3, x4, x5;
    public Text a1, a2, a3, a4, a5;
    public Text resultText;
    
    public GameObject Profile;


    void Start()
    {

    }

    void Update()
    {
        if (step == 1) {
            if (Input.GetKey(KeyCode.Escape)) {
                step0();
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
        startSound.Play();
        info1.SetActive(true);
        step0();
        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.transform.position = new Vector3(1011.79f, 1f, 1022.84f);
        mainCamera.GetComponent<ThirdCamera>().enabled = false;
        mainCamera.transform.position = new Vector3(1012f, 14.8f, 1024.2f);
        mainCamera.transform.rotation = Quaternion.Euler(65f, 0f, 0f);
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

    public void OnGame() {
        qtext.text = StringDecode("Q1.\n�¾翭 �������� �¾��� �� �������� �̿��� �������̴�.");
        startSound.Stop();
        gameSound.Play();
        step = 3;
        info1.SetActive(false);
        info4.SetActive(true);
    }

    public void CheckAns(int slt) {
        if (step == 3) {
            corr1 = slt;
            step++;
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(1011.79f, 1f, 1022.84f);
            qtext.text = StringDecode("Q2.\n�ؾ翡������ ��������Ŀ� ����\n����, �ķ�, ����, �µ������� 4������ ������.");
        }

        else if (step == 4) {
            corr2 = slt;
            step++;
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(1011.79f, 1f, 1022.84f);
            qtext.text = StringDecode("Q3.\n���̿��Ž�(Biomass)�� �¾翡������ ���� �Ĺ��� �̻�����\n���ռ��� ���� �����Ǵ� �Ĺ�ü �� ����ü��\n�̸� �԰� ��ư��� ����ü�� ������ ���� ����ü�� ���Ѵ�.");
        }

        else if (step == 5) {
            corr3 = slt;
            step++;
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(1011.79f, 1f, 1022.84f);
            qtext.text = StringDecode("Q4.\n���������� �������� ���� ���Ḧ �����Ͽ�\n�����ؼ� ����� �� �����Ƿ� \'3�� ����\'�� �з��ȴ�.");
        }

        else if (step == 6) {
            corr4 = slt;
            step++;
            GameObject player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(1011.79f, 1f, 1022.84f);
            qtext.text = StringDecode("Q5.\n���ҿ��������� ���ҿ� ����� �����޴� ������\n����, ����, ����� �����ϱ� �����̴�.");
        }


        else if (step == 7) {
            corr5 = slt;
            step++;
            Result();
        }
    }

    public void Result() {
        
        int corrcount = 0;

        if (corr1 == 1) a1.text = "O";
        else a1.text = "X";

        if (corr2 == 1) a2.text = "O";
        else a2.text = "X";

        if (corr3 == 1) a3.text = "O";
        else a3.text = "X";

        if (corr4 == 1) a4.text = "O";
        else a4.text = "X";

        if (corr5 == 1) a5.text = "O";
        else a5.text = "X";


        if (corr1 == ans1) {
            o1.gameObject.SetActive(true);
            x1.gameObject.SetActive(false);
            corrcount++;
        }
        else {
            x1.gameObject.SetActive(true);
            o1.gameObject.SetActive(false);
        }

        if (corr2 == ans2) {
            o2.gameObject.SetActive(true);
            x2.gameObject.SetActive(false);
            corrcount++;
        }
        else {
            x2.gameObject.SetActive(true);
            o2.gameObject.SetActive(false);
        }

        if (corr3 == ans3) {
            o3.gameObject.SetActive(true);
            x3.gameObject.SetActive(false);
            corrcount++;
        }
        else {
            x3.gameObject.SetActive(true);
            o3.gameObject.SetActive(false);
        }

        if (corr4 == ans4) {
            o4.gameObject.SetActive(true);
            x4.gameObject.SetActive(false);
            corrcount++;
        }
        else {
            x4.gameObject.SetActive(true);
            o4.gameObject.SetActive(false);
        }

        if (corr5 == ans5) {
            o5.gameObject.SetActive(true);
            x5.gameObject.SetActive(false);
            corrcount++;
        }
        else {
            x5.gameObject.SetActive(true);
            o5.gameObject.SetActive(false);
        }

    
        qtext.text = "";
        resultText.text = StringDecode("���� " + corrcount.ToString() + "/5");
        info4.SetActive(false);
        info5.SetActive(true);
        gameSound.Stop();
        endSound.Play();

        if (corrcount == 5) {
            if (Profile.GetComponent<Profile>().badge_subinfo3[0] == '0') {
                Profile.GetComponent<Profile>().badge_subinfo3[0] = '1';
                Profile.GetComponent<Profile>().CheckBadge();
            }
        }
    }

    public void OutGame() {
        Building.SetActive(true);
        GameObject player = GameObject.FindGameObjectWithTag("player");
        GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = true;
        player.transform.position = new Vector3(896.28f, 1f, 640f);
        info5.SetActive(false);
        o1.gameObject.SetActive(false); o2.gameObject.SetActive(false); o3.gameObject.SetActive(false); o4.gameObject.SetActive(false); o5.gameObject.SetActive(false);
        x1.gameObject.SetActive(false); x2.gameObject.SetActive(false); x3.gameObject.SetActive(false); x4.gameObject.SetActive(false); x5.gameObject.SetActive(false);
        endSound.Stop();
        mainCamera.transform.position = new Vector3(896.28f, 1f + 4f, 640f - 8f);
        mainCamera.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        mainCamera.GetComponent<ThirdCamera>().enabled = true;
        gameObject.SetActive(false);
    }
}
