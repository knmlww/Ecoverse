using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class MissionManager : MonoBehaviour
{
    public GameObject MissionPopupUI;

    public Text missionTitleText;
    public Text missionInfoText;
    public GameObject missionSection1, missionSection2, missionSection3, missionSection4, missionSection5;
    public List<RawImage> checkeds;
    public List<Text> missionText;
    public Text RewardText;

    public GameObject Map, Profile;

    public GameObject RewardSection, CompleteButton;

    public bool newFlag, completeFlag;

    public RawImage checkedIcon;

    /* Eco Building */
    public int eco_c1, eco_c2;

    void Start()
    {
        newFlag = false;
        completeFlag = false;

        eco_c1 = 0; eco_c2 = 0;
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }

    void Update()
    {
        if (completeFlag) {
            checkedIcon.gameObject.SetActive(true);
        }
        else{
            checkedIcon.gameObject.SetActive(false);
        }

        if (Profile.GetComponent<Profile>().mission_state == 0) {
            // if (completeFlag) missionInfoText.text = "������������ �̼� 1/3";
            // else 
            missionInfoText.text = StringDecode("������������ �̼� 0/3");
        }
        else if (Profile.GetComponent<Profile>().mission_state == 1) {
            // if (completeFlag) missionInfoText.text = "������������ �̼� 2/3";
            // else 
            missionInfoText.text = StringDecode("������������ �̼� 1/3");
        }
        else if (Profile.GetComponent<Profile>().mission_state == 2) {
            if (completeFlag) missionInfoText.text = StringDecode("������������ �̼� 3/3");
            else missionInfoText.text = StringDecode("������������ �̼� 2/3");
        }

        // ���� �̼� 1 ���� ����
        else if (Profile.GetComponent<Profile>().mission_state == 3) {
            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            int count = 0;
            foreach (char t in submission_state) {
                if (t == '1') count++;
            }

            missionInfoText.text = StringDecode("������������ �̼� " + count.ToString() + "/5");
        }

        // ����Ʈ��
        else if (Profile.GetComponent<Profile>().mission_state == 4) {
            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            int count = 0;
            foreach (char t in submission_state) {
                if (t == '1') count++;
            }

            missionInfoText.text = StringDecode("������������ �̼� " + count.ToString() + "/4");
        }

        // �����
        else if (Profile.GetComponent<Profile>().mission_state == 5) {
            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            int count = 0;
            foreach (char t in submission_state) {
                if (t == '1') count++;
            }

            missionInfoText.text = StringDecode("������������ �̼� " + count.ToString() + "/5");
        }

        // ����� ���� ���Ϸ��� �ѷ�����
        else if (Profile.GetComponent<Profile>().mission_state == 6) {
            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            int count = 0;
            foreach (char t in submission_state) {
                if (t == '1') count++;
            }

            missionInfoText.text = StringDecode("������������ �̼� " + count.ToString() + "/5");
        }

        // �̼� �Ϸ�
        else if (Profile.GetComponent<Profile>().mission_state == 7) {
            missionInfoText.text = StringDecode("��� �̼��� �Ϸ��߽��ϴ�!");
        }

        if (eco_c1 == 1 && eco_c2 == 1) {
            eco_c2 = -1; eco_c1 = -1;

        }
    }

    public void MissionFlagOn(int main_num, int sub_num) {

        if (main_num == Profile.GetComponent<Profile>().mission_state && Profile.GetComponent<Profile>().submission_state[sub_num - 1] == '0') {
            Profile.GetComponent<Profile>().submission_state[sub_num - 1] = '1';
            completeFlag = true;
            MissionUpdate();
        }
    }

    public void SubMissionFlagOn() {
        completeFlag = true;
    }

    public void MissionUpdate() {
        int mission_state = Profile.GetComponent<Profile>().mission_state;

        //if (newFlag) newIcon.gameObject.SetActive(true);
        //else newIcon.gameObject.SetActive(false);

        if (completeFlag) checkedIcon.gameObject.SetActive(true);
        else checkedIcon.gameObject.SetActive(false);

        // Ʃ�丮�� �޼� ����
        // Ʃ�丮�� 1�� ���� - �����̿� ��ȭ ����
        if (mission_state == 0) {
            RewardSection.SetActive(false);
            missionTitleText.text = StringDecode("Ʃ�丮��");
            CompleteButton.SetActive(false);

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(false);
            missionSection5.SetActive(false);

            missionText[0].text = StringDecode("�����̿� ��ȭ ����");
            missionText[1].text = StringDecode("���� ������ ��Ʈ�� Ÿ�� ���� ���Ϸ���� �̵��ϱ�");
            missionText[2].text = StringDecode("���� ���Ϸ��忡�� ���� ���� �ϳ� �ݱ�");

            checkeds[0].gameObject.SetActive(false); checkeds[1].gameObject.SetActive(false); checkeds[2].gameObject.SetActive(false); 

            // if (completeFlag) {
            //     checkeds[0].gameObject.SetActive(true);
            // }
            // else {
            //     checkeds[0].gameObject.SetActive(false);
            // }
        } 

        // Ʃ�丮�� 2�� ���� - ��Ʈ�� Ÿ�� ���� ���Ϸ���� �̵��ϱ�
        else if (mission_state == 1) {
            RewardSection.SetActive(false);
            missionTitleText.text = StringDecode("Ʃ�丮��");
            CompleteButton.SetActive(false);

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(false);
            missionSection5.SetActive(false);

            missionText[0].text = StringDecode("�����̿� ��ȭ ����");
            missionText[1].text = StringDecode("���� ������ ��Ʈ�� Ÿ�� ���� ���Ϸ���� �̵��ϱ�");
            missionText[2].text = StringDecode("���� ���Ϸ��忡�� ���� ���� �ϳ� �ݱ�");

            checkeds[0].gameObject.SetActive(true); checkeds[2].gameObject.SetActive(false); checkeds[1].gameObject.SetActive(false);

            // if (completeFlag) {
            //     checkeds[1].gameObject.SetActive(true);
            // }
            // else {
                
            // }
        }

        // Ʃ�丮�� 3�� ���� - ���� ���Ϸ��忡�� ���� ���� �ϳ� �ݱ�
        else if (mission_state == 2) {
            RewardSection.SetActive(false);
            missionTitleText.text = StringDecode("Ʃ�丮��");

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(false);
            missionSection5.SetActive(false);

            missionText[0].text = StringDecode("�����̿� ��ȭ ����");
            missionText[1].text = StringDecode("���� ������ ��Ʈ�� Ÿ�� ���� ���Ϸ���� �̵��ϱ�");
            missionText[2].text = StringDecode("���� ���Ϸ��忡�� ���� ���� �ϳ� �ݱ�");

            checkeds[0].gameObject.SetActive(true); checkeds[1].gameObject.SetActive(true); 

            if (completeFlag) {
                checkeds[2].gameObject.SetActive(true);
                CompleteButton.SetActive(true);
            }
            else {
                checkeds[2].gameObject.SetActive(false);
                CompleteButton.SetActive(false);
            }
        }   
        
        // ���ι̼� 1 ���� - ��翡 ���� �����غ���
        else if (mission_state == 3) {
            missionTitleText.text = StringDecode("��翡 ���� �����غ���");
            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(true);
            missionSection5.SetActive(true);

            RewardSection.SetActive(true);
            RewardText.text = StringDecode("������ ���� ���� �����۵� unlock + 70����");

            missionText[0].text = StringDecode("���� �����ϱ�");
            missionText[1].text = StringDecode("�������� ���� �����ϰ� \'�꼺�� ü���\' ���� ü���غ���");
            missionText[2].text = StringDecode("\'�ùٸ� ���� ȭ�� Ű���\' �̴ϰ��� �÷����ϱ�");
            missionText[3].text = StringDecode("������ ���� ��ʿ� ���� �����ϰ� \'����Ŀ�� �����\' ��û�ϱ�");
            missionText[4].text = StringDecode("�������� �غ��ϱ� ���� ����� ������ �� �������� ������");

            for (int i = 0; i < submission_state.Length; i++) {
                if (submission_state[i] == '1') checkeds[i].gameObject.SetActive(true);
                else checkeds[i].gameObject.SetActive(false);
            }

            if (submission_state[0] == '1' && submission_state[1] == '1' && submission_state[2] == '1' && 
                    submission_state[3] == '1' && submission_state[4] == '1') {
                CompleteButton.SetActive(true);
            }
            else {
                CompleteButton.SetActive(false);
            }
        }

        // ���ι̼� 2 ���� - ����Ʈ������ �� �������
        else if (mission_state == 4) {
            missionTitleText.text = StringDecode("����Ʈ������ �� �������");

            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(true);
            missionSection5.SetActive(false);

            RewardSection.SetActive(true);
            RewardText.text = StringDecode("����Ʈ�� �߰� ���� + ���� 3�� unlock + 70����");

            missionText[0].text = StringDecode("�����κλ��� �湮�ؼ� ����Ʈ�� ��ġ �����ϱ�");
            missionText[1].text = StringDecode("���μ����� �̵��Ͽ� ����Ʈ�� ��ġ �� ���� �ɱ�");
            missionText[2].text = StringDecode("���� ��Ȯ�ϱ�");
            missionText[3].text = StringDecode("�����κλ������� ���� ���� �Ǹ��Ͽ� �� ����");

            for (int i = 0; i < submission_state.Length; i++) {
                if (submission_state[i] == '1') checkeds[i].gameObject.SetActive(true);
                else checkeds[i].gameObject.SetActive(false);
            }

            if (submission_state[0] == '1' && submission_state[1] == '1' && submission_state[2] == '1' && 
                    submission_state[3] == '1') {
                CompleteButton.SetActive(true);
            }
            else {
                CompleteButton.SetActive(false);
            }
        }

        // ���ι̼� 3 ���� - ��������������� ���� �����غ���
        else if (mission_state == 5) {
            missionTitleText.text = StringDecode("��������������� ���� �����غ���");

            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(true);
            missionSection5.SetActive(true);

            RewardSection.SetActive(true);
            RewardText.text = StringDecode("������ ������������� ���� �����۵� unlock + 70����");

            missionText[0].text = StringDecode("������������� �����ϱ�");
            missionText[1].text = StringDecode("\'�ſ�����&��������� �����ϱ�\' �̴ϰ��� �÷����ϱ� ");
            missionText[2].text = StringDecode("\'OX ����\' �̴ϰ��� �÷����ϱ�");
            missionText[3].text = StringDecode("\'���� ���߱�\' �̴ϰ��� �÷����ϱ�");
            missionText[4].text = StringDecode("��Ȱ �� ����������� �����ϰ� \'������ ���ο�����\' ü��� ü���ϱ�");

            for (int i = 0; i < submission_state.Length; i++) {
                if (submission_state[i] == '1') checkeds[i].gameObject.SetActive(true);
                else checkeds[i].gameObject.SetActive(false);
            }

            if (submission_state[0] == '1' && submission_state[1] == '1' && submission_state[2] == '1' && 
                    submission_state[3] == '1' && submission_state[4] == '1') {
                CompleteButton.SetActive(true);
            }
            else {
                CompleteButton.SetActive(false);
            }
        }

        // ���ι̼� 4 ���� - ���� ���Ϸ��忡�� ����������� ��� ���캸��
        else if (mission_state == 6) {
            missionTitleText.text = StringDecode("���� ���Ϸ��忡�� ����������� ��� ���캸��");

            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(true);
            missionSection5.SetActive(true);

            RewardSection.SetActive(true);
            RewardText.text = StringDecode("70����");

            missionText[0].text = StringDecode("solar �౸�忡 ���� �� �ֱ�");
            missionText[1].text = StringDecode("���ݰ����� ž���ϱ�");
            missionText[2].text = StringDecode("���ں��������� �ִ� �ǹ� �����ϱ�");
            missionText[3].text = StringDecode("���ҡ������� �����忡 ���� 1���� ���� ���� ��ġ��");
            missionText[4].text = StringDecode("���������� ���μ��� ���ڸ��ϸ��� 20�ۼ�Ʈ�� �ø���");

            for (int i = 0; i < submission_state.Length; i++) {
                if (submission_state[i] == '1') checkeds[i].gameObject.SetActive(true);
                else checkeds[i].gameObject.SetActive(false);
            }

            if (submission_state[0] == '1' && submission_state[1] == '1' && submission_state[2] == '1' && 
                    submission_state[3] == '1' && submission_state[4] == '1') {
                CompleteButton.SetActive(true);
            }
            else {
                CompleteButton.SetActive(false);
            }
        }

        // 1�� ��� ���ι̼� �Ϸ�
        else if (mission_state == 7) {
            missionTitleText.text = StringDecode("��� �̼��� �Ϸ��߽��ϴ�.");

            missionSection1.SetActive(false);
            missionSection2.SetActive(false);
            missionSection3.SetActive(false);
            missionSection4.SetActive(false);
            missionSection5.SetActive(false);
            RewardSection.SetActive(false);
            CompleteButton.SetActive(false);
        }
    }

    public void MissionCompleteButton() {
        Map.GetComponent<MapController>().MissionPopupClose();
        completeFlag = false;
    }

    public void NextTutorialMission() {
        int mission_state = Profile.GetComponent<Profile>().mission_state;

        // Ʃ�丮�� �޼� ����
        // Ʃ�丮�� 1�� ���� - �����̿� ��ȭ ����
        if (mission_state == 0) {
            // MissionPopupUI.SetActive(false);
            checkedIcon.gameObject.SetActive(false);
            return;
        } 

        // Ʃ�丮�� 2�� ���� - ��Ʈ�� Ÿ�� ���� ���Ϸ���� �̵��ϱ�
        else if (mission_state == 1) {
            // MissionPopupUI.SetActive(false);
            checkedIcon.gameObject.SetActive(false);
            return;
        }
    }

    public void NextMission() {
        int mission_state = Profile.GetComponent<Profile>().mission_state;

        // Ʃ�丮�� 3�� ���� - ���� ���Ϸ��忡�� ���� ���� �ϳ� �ݱ�
        if (mission_state == 2) {
            Profile.GetComponent<Profile>().mission_state = 3;

            // ���� ����
            Profile.GetComponent<Profile>().museum_unlock = 1;

            // ���ι̼� 1�� �Ѿ
            Profile.GetComponent<Profile>().submission_state = new char[5]{'0', '0', '0', '0', '0'};
        }   

        // ���ι̼� 1 ���� - ��翡 ���� �����غ��� -> soil_item_unlock 1�� ���� (����, ����Ʈ�� 1����)
        else if (mission_state == 3) {
            Profile.GetComponent<Profile>().mission_state = 4;
            Profile.GetComponent<Profile>().soil_item_unlock = 1;
            Profile.GetComponent<Profile>().Coin(70);

            // ���ι̼� 2�� �Ѿ
            Profile.GetComponent<Profile>().submission_state = new char[4]{'0', '0', '0', '0'};
        }

        // ���ι̼� 2 ���� - ����Ʈ������ �� ������� -> soil_item_unlock 2�� ���� (����)
        else if (mission_state == 4) {
            Profile.GetComponent<Profile>().mission_state = 5;
            Profile.GetComponent<Profile>().soil_item_unlock = 2;
            Profile.GetComponent<Profile>().Coin(70);

            // ������������� ����
            Profile.GetComponent<Profile>().museum_unlock = 2;

            // ���ι̼� 3�� �Ѿ
            Profile.GetComponent<Profile>().submission_state = new char[5]{'0', '0', '0', '0', '0'};
        }

        // ���ι̼� 3 ���� - ��������������� ���� �����غ���
        else if (mission_state == 5) {
            Profile.GetComponent<Profile>().mission_state = 6;
            Profile.GetComponent<Profile>().energy_item_unlock = 1;
            Profile.GetComponent<Profile>().Coin(70);

            // ���ι̼� 4�� �Ѿ
            Profile.GetComponent<Profile>().submission_state = new char[5]{'0', '0', '0', '0', '0'};
        }

        // ���ι̼� 4 ���� - ���� ���Ϸ��忡�� ����������� ��� ���캸��
        else if (mission_state == 6) {
            Profile.GetComponent<Profile>().mission_state = 7;
            Profile.GetComponent<Profile>().Coin(70);

            Profile.GetComponent<Profile>().submission_state = new char[1]{'0'};
        }

        // 1�� ��� ���ι̼� �Ϸ�
        else if (mission_state == 7) {
            
        }

        Map.GetComponent<MapController>().MissionPopupClose();
    }
}
