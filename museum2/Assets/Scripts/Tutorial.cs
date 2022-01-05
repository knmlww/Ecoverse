using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class Tutorial : MonoBehaviour
{
    public GameObject TutorialUI;
    public GameObject fish;
    public string nickname;
    public GameObject Profile, Map;

    public GameObject HomeTrigger, IslandTrigger;

    public GameObject ecomileageUI;

    public GameObject b1, b2, b3, b4;

    public int sceneStep;

    /* Scene 1 */
    public GameObject scene1;
    public Text letterText;

    /* Scene 2 */
    public GameObject scene2;
    public Text bubbleText;

    public GameObject MissionManager, FurnitureManager;

    public GameObject HelpUI;

    int mstep = 0;

    void Start()
    {
        
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }

    void Update()
    {
        if (sceneStep == 2) {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, b2.transform.position, Time.deltaTime);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, b2.transform.rotation, Time.deltaTime);
        }

        if (sceneStep == 3) {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, b3.transform.position, Time.deltaTime);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, b3.transform.rotation, Time.deltaTime);
        }

        if (sceneStep == 4) {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, b4.transform.position, Time.deltaTime);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, b4.transform.rotation, Time.deltaTime);

            if (HomeTrigger.GetComponent<PersonalHomeTrigger>().step == 1) {
                Step5();
            }
        }

        if (sceneStep == 7) {
            if (mstep == 1) {
                Profile.GetComponent<Profile>().ecomileage += 1;

                if (Profile.GetComponent<Profile>().ecomileage == 100) mstep = 2;
            }
            if (mstep == 2) {
                Profile.GetComponent<Profile>().ecomileage -= 1;

                if (Profile.GetComponent<Profile>().ecomileage == 0) {
                    mstep = 3;
                    Step8();
                }
            }
            
        }

        if (sceneStep == 8) {
            if (HomeTrigger.GetComponent<PersonalHomeTrigger>().step == -1) {
                Step9();
            }
        }

        if (sceneStep == 10) {
            if (IslandTrigger.GetComponent<GoEcoIsland>().tutorialFlag == 1) {
                Step11();
            }
        }

        if (sceneStep == 12) {
            if (Profile.GetComponent<Profile>().badge_subinfo2 > 0) {
                Step13();
            }
        }
    }

    public void StartTutorial() {
        TutorialUI.SetActive(true);
        FurnitureManager.GetComponent<Furniture>().TutorialGoOut();
        scene2.SetActive(false);
        fish.SetActive(true);
        nickname = Profile.GetComponent<Profile>().nickname;
        Camera.main.GetComponent<CameraRotate>().enabled = false;
        sceneStep = 0;
        scene1.SetActive(true);
        letterText.text = StringDecode("�ȳ��ϼ���! " + nickname + "��\n\n�� ���� �����Ͻñ⸦ �������ּż� �����մϴ�.\n\n���� ��ü���� ������ �Ұ��� ���� �����Ͻø�\n\n���� ���� ����帮�ڽ��ϴ�.\n\n�׷� �̻� �ɰԿ�!");
        Invoke("Step1", 10f);
        
    }

    public void Step1() {
        sceneStep = 1;
        scene1.SetActive(false);
        scene2.SetActive(true);

        Camera.main.transform.position = new Vector3(712.7f, 3.4f, -429.1f);
        Camera.main.transform.rotation = Quaternion.Euler(5f, -44.2f, 0f);

        Map.GetComponent<MapController>().FlagOn("TUTORIAL");

        GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(705f, 1.8f, -418.9f);
        GameObject.FindGameObjectWithTag("player").transform.rotation = Quaternion.Euler(0f, 133.3f, 0f);

        bubbleText.text = StringDecode("�ȳ��ϼ���! " + nickname + "��!\n\n�� ������ �̻���� ���� ���� ȯ���մϴ�.\n\n�켱 �����ϰ� ���� �Ұ��ص帱�Կ�!");

        Invoke("Step2", 8f);
    }

    public void Step2() {
        sceneStep = 2;

        bubbleText.text = StringDecode("�� �����忡�� ��Ʈ�� Ÿ�� ���� ���Ϸ���� �̵��Ͻ� �� �ֽ��ϴ�.");

        Invoke("Step3", 8f);
    }

    public void Step3() {
        sceneStep = 3;

        bubbleText.text = StringDecode("�� ���� ���� ������ ���۹��� �⸣�ٰ� �߰��� �׸��θ鼭 ��ġ�Ǿ����.\n\n" + nickname + "�Բ��� �� ���� ��ϽŴٸ� ���� ���� ������ ź���� �� ���׿�!\n\n�۹��� ����ؼ� ���͵� �� �� �ֽ��ϴ�.");

        Invoke("Step4", 10f);
    }

    public void Step4() {
        sceneStep = 4;

        bubbleText.text = StringDecode("�� ���� " + nickname + "�Բ��� �����Ͻ� ���Դϴ�. \n\n �� �� �����ðھ��?");

        Invoke("Step4A", 5f);
    }

    public void Step4A() {
        scene2.SetActive(false);
        Map.GetComponent<MapController>().FlagOff();

        GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(699.7f, 1.9f, -419f);
        GameObject.FindGameObjectWithTag("player").transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = true;
        Camera.main.GetComponent<CameraRotate>().enabled = true;

        HelpUI.SetActive(true);

        Invoke("Step4B", 5f);
    }

    public void Step4B() {
        HelpUI.SetActive(false);
    }

    public void Step5() {
        Map.GetComponent<MapController>().FlagOn("TUTORIAL");
        scene2.SetActive(true);
        sceneStep = 5;

        bubbleText.text = StringDecode("������� �� �����Ǿ ������ ���� �׿��ֳ׿�.\n�� ���� " + nickname + "�Բ��� �ϳ��� �ٲپ���ø� �Ϻ��� ���� �ɰſ���!");

        Invoke("Step6", 5f);
    }

    public void Step6() {
        sceneStep = 6;

        bubbleText.text = StringDecode("���� ���Ϸ��忡 ���ø� ���� ���� ���� ģȯ������ ������ �����۵��� �����ؼ� " + nickname + "���� ���� �ٹ� �� �ֽ��ϴ�.\n");

        Invoke("Step7", 5f);
    }

    public void Step7() {
        sceneStep = 7;

        mstep = 1;
        ecomileageUI.SetActive(true);

        bubbleText.text = StringDecode("�� ��, ���� ���ϸ����ٰ� �ö󰡴� ���� ���� �� �־��.\n\n���� ���ϸ����ٴ� ���� �� ������ �������� �󸶳� ȿ�������� ����ϰ� �ִ����� �����ݴϴ�.");
    
        // Invoke("Step8", 5f);
    }

    public void Step8() {
        Map.GetComponent<MapController>().FlagOff();
         ecomileageUI.SetActive(false);
        sceneStep = 8;

        bubbleText.text = StringDecode("ģȯ�� �������� �̿��� ���ڸ��ϸ����� �׾� ȯ���� ���� ���� ��õ�غ�����!\n\n���� �ٽ� �� ������ ���������?");
    }

    public void Step9() {
        Map.GetComponent<MapController>().FlagOn("TUTORIAL");
        sceneStep = 9;

        bubbleText.text = StringDecode("�׷� ���� ���� ���Ϸ���� �������?\n\n���� ��ħ �� ���� ������ ���� ����!");

        //MissionManager.GetComponent<MissionManager>().SubMissionFlagOn();
        Profile.GetComponent<Profile>().mission_state = 1;
    
        Invoke("Step10", 5f);
    }

    public void Step10() {
        sceneStep = 10;
        scene2.SetActive(false);
        Map.GetComponent<MapController>().FlagOff();
    }

    public void Step11() {
        sceneStep = 11;
        scene2.SetActive(true);
        Map.GetComponent<MapController>().FlagOn("TUTORIAL");

        bubbleText.text = StringDecode("���� ���Ϸ��忡 �����߽��ϴ�! \n\n�� ������ �ڹ����� �����ϸ� ȯ�濡 ���� �����ϰ� �پ��� Ȱ���� ü���� �� �־��!\n\n�پ��� Ȱ���� ü���ϸ� ������ ��ƺ�����.");

        //MissionManager.GetComponent<MissionManager>().SubMissionFlagOn();
        Profile.GetComponent<Profile>().mission_state = 2;
    
        Invoke("Step12", 10f);
    }

    public void Step12() {
        sceneStep = 12;

        bubbleText.text = StringDecode("�� ������ \'���� ����\'�� �־��. \n\n���� ���׸� ã���ø� �ȿ� �ִ� ������ ȹ���� �� �־��. ���� ������ �� �������� ����ִ� ���� ���� �ٸ��� �� �� �����ϼ���!\n\n�׷� ���ο��׸� �� �� ã�Ƽ� ������ ������!");
    
        Invoke("Step12A", 12f);
    }

    public void Step12A() {
        scene2.SetActive(false);
        Map.GetComponent<MapController>().FlagOff();
    }

    public void Step13() {
        sceneStep = 13;

        scene2.SetActive(true);
        bubbleText.text = StringDecode("���ƿ�! �׷� �������� ���� ���Ϸ��忡�� ���� �߾��� �׾ư��� �ٶ��Կ� " + nickname + "��!");

        MissionManager.GetComponent<MissionManager>().SubMissionFlagOn();

        Invoke("EndTutorial", 8f);
    }

    public void EndTutorial() {
        fish.SetActive(false);
        scene2.SetActive(false);
        TutorialUI.SetActive(false);
    }
}
