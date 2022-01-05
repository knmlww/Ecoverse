using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class SmartFarm : MonoBehaviour
{   
    public GameObject Profile, Map;

    // ���� �����ִ� ����Ʈ�� ��ȣ
    public int smartfarmtype;

    // ���� �ð� �ؽ�Ʈ
    public Text timeText;
    public bool screenTime;

    /* UI */
    public GameObject SmartFarmUI, StartPageUI;

    public GameObject TimeDraw;
    public Button StartButton, GetButton;

    public List<GameObject> sectionList; 

    public List<RawImage> sectionItemImageList;
    public List<Text> sectionItemNumberList, sectionItemNameList, sectionItemDiscList;
    public List<GameObject> sectionCheckboxList;

    // ������ ���� ����, üũ�ڽ�
    public GameObject NutSection;
    public RawImage NutCheckbox;
    public Text NutNumText;

    public List<Texture> itemTextures;
    
    // ������ �ִ� ���� ���� ��, ������ ���� (üũ�ڽ�), ������ ��� ����
    public int nowSeedNum, lastselect, useNut;
    public string lastselect_itemcode;

    // ���� ������ �ִ� ���� ����Ʈ
    List<string> seedList;

    // ����Ʈ��1
    public List<GameObject> basilList1, vitList1, LecList1, tomList1;
    
    // ����Ʈ��2
    public List<GameObject> basilList2, vitList2, LecList2, tomList2;

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
        if (smartfarmtype == 1) {
            if (screenTime) {
                if (Profile.GetComponent<Profile>().sf_type1 != 0) {
                    // �ð��� �� �� ���
                    if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf1time) >= 0) {
                        timeText.text = "00:00:00";
                    }
                    else {
                        TimeSpan timediff = Profile.GetComponent<Profile>().sf1time - DateTime.Now;
                        timeText.text = makeTwo(timediff.Hours.ToString()) + ":" + makeTwo(timediff.Minutes.ToString()) + ":" + makeTwo(timediff.Seconds.ToString());
                    }
                }
            }
        }
        else {
            if (screenTime) {
                if (Profile.GetComponent<Profile>().sf_type2 != 0) {
                    // �ð��� �� �� ���
                    if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf2time) >= 0) {
                        timeText.text = "00:00:00";
                    }
                    else {
                        TimeSpan timediff = Profile.GetComponent<Profile>().sf2time - DateTime.Now;
                        timeText.text = makeTwo(timediff.Hours.ToString()) + ":" + makeTwo(timediff.Minutes.ToString()) + ":" + makeTwo(timediff.Seconds.ToString());
                    }
                }
            }
        }
    }

    public string makeTwo(string t) {
        if (t.Length == 1) return "0" + t;
        else if (t.Length == 0) return "00";
        else return t;
    }

    public void DrawModels() {
        
        for (int i = 0; i < 3; i++) {
            basilList1[i].SetActive(false);
            basilList2[i].SetActive(false);
            vitList1[i].SetActive(false);
            vitList2[i].SetActive(false);
            tomList1[i].SetActive(false);
            tomList2[i].SetActive(false);
            LecList1[i].SetActive(false);
            LecList2[i].SetActive(false);
        }

        if (smartfarmtype == 1) {
            int planttype = Profile.GetComponent<Profile>().sf_type1;
            DateTime leftTime = Profile.GetComponent<Profile>().sf1time;

            // ����
            if (planttype == 1) {
                int mindiff = (Profile.GetComponent<Profile>().sf1time - DateTime.Now).Minutes;
                // �� �ڶ� ���
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf1time) >= 0) {
                    LecList1[2].SetActive(true);
                }
                // ���� ����
                else if (mindiff <= 15) {
                    LecList1[1].SetActive(true);
                }
                else {
                    LecList1[0].SetActive(true);
                }
            }

            // ��Ÿ��
            else if (planttype == 2) {
                int mindiff = (Profile.GetComponent<Profile>().sf1time - DateTime.Now).Minutes;
                // �� �ڶ� ���
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf1time) >= 0) {
                    vitList1[2].SetActive(true);
                }
                // ���� ����
                else if (mindiff <= 30) {
                    vitList1[1].SetActive(true);
                }
                else {
                    vitList1[0].SetActive(true);
                }
            }

            // ����
            else if (planttype == 3) {
                int mindiff = (Profile.GetComponent<Profile>().sf1time - DateTime.Now).Minutes;
                // �� �ڶ� ���
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf1time) >= 0) {
                    basilList1[2].SetActive(true);
                }
                // ���� ����
                else if (mindiff <= 30) {
                    basilList1[1].SetActive(true);
                }
                else {
                    basilList1[0].SetActive(true);
                }
            }

            // �丶��
            else if (planttype == 4) {
                int mindiff = (Profile.GetComponent<Profile>().sf1time - DateTime.Now).Minutes;
                // �� �ڶ� ���
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf1time) >= 0) {
                    tomList1[2].SetActive(true);
                }
                // ���� ����
                else if (mindiff <= 60) {
                    tomList1[1].SetActive(true);
                }
                else {
                    tomList1[0].SetActive(true);
                }
            }
        }

        // ����Ʈ��2
        else {
            int planttype = Profile.GetComponent<Profile>().sf_type2;
            DateTime leftTime = Profile.GetComponent<Profile>().sf2time;

            // ����
            if (planttype == 1) {
                int mindiff = (Profile.GetComponent<Profile>().sf2time - DateTime.Now).Minutes;
                // �� �ڶ� ���
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf2time) >= 0) {
                    LecList2[2].SetActive(true);
                }
                // ���� ����
                else if (mindiff <= 15) {
                    LecList2[1].SetActive(true);
                }
                else {
                    LecList2[0].SetActive(true);
                }
            }

            // ��Ÿ��
            else if (planttype == 2) {
                int mindiff = (Profile.GetComponent<Profile>().sf2time - DateTime.Now).Minutes;
                // �� �ڶ� ���
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf2time) >= 0) {
                    vitList2[2].SetActive(true);
                }
                // ���� ����
                else if (mindiff <= 30) {
                    vitList2[1].SetActive(true);
                }
                else {
                    vitList2[0].SetActive(true);
                }
            }

            // ����
            else if (planttype == 3) {
                int mindiff = (Profile.GetComponent<Profile>().sf2time - DateTime.Now).Minutes;
                // �� �ڶ� ���
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf2time) >= 0) {
                    basilList2[2].SetActive(true);
                }
                // ���� ����
                else if (mindiff <= 30) {
                    basilList2[1].SetActive(true);
                }
                else {
                    basilList2[0].SetActive(true);
                }
            }

            // �丶��
            else if (planttype == 4) {
                int mindiff = (Profile.GetComponent<Profile>().sf2time - DateTime.Now).Minutes;
                // �� �ڶ� ���
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf2time) >= 0) {
                    tomList2[2].SetActive(true);
                }
                // ���� ����
                else if (mindiff <= 60) {
                    tomList2[1].SetActive(true);
                }
                else {
                    tomList2[0].SetActive(true);
                }
            }
        }
    }

    public void FarmStartPage(int type) {
        SmartFarmUI.SetActive(true);
        StartPageUI.SetActive(false);
        smartfarmtype = type;

        screenTime = false;
        
        if (smartfarmtype == 1) {
            // �Ƚ��� ���
            if (Profile.GetComponent<Profile>().sf_type1 == 0) {
                TimeDraw.SetActive(false);
                StartButton.gameObject.SetActive(true);
                GetButton.gameObject.SetActive(false);

                DrawModels();
            }

            // ���� ��� 
            else {
                // �ð��� �� �� ���

                // if (DateTime.Now > Profile.GetComponent<Profile>().sf1time) {
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf1time) >= 0) {
                    TimeDraw.SetActive(true);
                    StartButton.gameObject.SetActive(false);
                    GetButton.gameObject.SetActive(true);

                    screenTime = true;

                    DrawModels();
                }

                // �ð��� ���� ���
                else {
                    TimeDraw.SetActive(true);
                    StartButton.gameObject.SetActive(false);
                    GetButton.gameObject.SetActive(false);

                    screenTime = true;

                    DrawModels();
                }
            }
        }

        else {
            // �Ƚ��� ���
            if (Profile.GetComponent<Profile>().sf_type2 == 0) {
                TimeDraw.SetActive(false);
                StartButton.gameObject.SetActive(true);
                GetButton.gameObject.SetActive(false);

                DrawModels();
            }

            // ���� ��� 
            else {
                // �ð��� �� �� ���
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf2time) >= 0) {
                    TimeDraw.SetActive(true);
                    StartButton.gameObject.SetActive(false);
                    GetButton.gameObject.SetActive(true);

                    screenTime = true;

                    DrawModels();
                }

                // �ð��� ���� ���
                else {
                    TimeDraw.SetActive(true);
                    StartButton.gameObject.SetActive(false);
                    GetButton.gameObject.SetActive(false);

                    screenTime = true;

                    DrawModels();
                }
            }
        }
    }

    public void StartPage() {
        StartPageUI.SetActive(true);
        Map.GetComponent<MapController>().FlagOn("SMARTFARM1");
        lastselect = -1;
        useNut = -1;
        
        List<string> inventory_state = Profile.GetComponent<Profile>().inventory_state;
        seedList = new List<string>();

        // ������ �ִ� ���� ���� ���� , ������ ���� ���� üũ
        for (int i = 1; i < inventory_state.Count; i++) {
            string[] temparr = inventory_state[i].Split('-');

            if (temparr[0].Equals("MS003") || temparr[0].Equals("MS004") || temparr[0].Equals("MS005") || temparr[0].Equals("MS006")) 
            {
                seedList.Add(inventory_state[i]);
            }

            else if (temparr[0].Equals("MS001")) {
                NutSection.SetActive(true);
                NutNumText.text = StringDecode(temparr[1]);
                useNut = 0; // ����� �� �ִµ� ����
            }
        }

        // ������ üũ�ڽ� �ʱ�ȭ, ��Ȱ��ȭ
        NutCheckbox.gameObject.SetActive(false);
        if (useNut == -1) {
            NutSection.SetActive(false);
        }

        // ���� ��Ȱ��ȭ
        for (int i = 0; i < sectionList.Count; i++) {
            sectionList[i].SetActive(false);
            sectionCheckboxList[i].SetActive(false);
        }

        // ������ �ִ� ���� ����
        nowSeedNum = seedList.Count;

        // ������ �ִ� ���Ѹ�ŭ ���� Ȱ��ȭ �� ���� ǥ��
        for (int i = 0; i < nowSeedNum; i++) {
            string[] temparr = seedList[i].Split('-');
            sectionList[i].SetActive(true); // ���� Ȱ��ȭ 
            sectionItemImageList[i].GetComponent<RawImage>().texture = itemTextures.Find(x => x.name.Equals(temparr[0])); // �̹��� ����
            sectionItemNumberList[i].text = StringDecode(temparr[1]);

            if (temparr[0].Equals("MS003")) {
                sectionItemNameList[i].text = StringDecode("���� ����");
                sectionItemDiscList[i].text = StringDecode("30�� �ҿ�, 100 coin���� �Ǹ� ����");
            }
            else if (temparr[0].Equals("MS004")) {
                sectionItemNameList[i].text = StringDecode("��Ÿ�� ����");
                sectionItemDiscList[i].text = StringDecode("1�ð� �ҿ�, 115 coin���� �Ǹ� ����");
            }
            else if (temparr[0].Equals("MS005")) {
                sectionItemNameList[i].text = StringDecode("���� ����");
                sectionItemDiscList[i].text = StringDecode("1�ð� �ҿ�, 120 coin���� �Ǹ� ����");
            }
            else if (temparr[0].Equals("MS006")) {
                sectionItemNameList[i].text = StringDecode("�丶�� ����");
                sectionItemDiscList[i].text = StringDecode("2�ð� �ҿ�, 145 coin���� �Ǹ� ����");
            }
        }

        DrawModels();
    }

    // ��Ȯ
    public void Get() { 
        int planttype;

        // 1�� �ǹ�
        if (smartfarmtype == 1) planttype = Profile.GetComponent<Profile>().sf_type1;
        // 2�� �ǹ�
        else planttype = Profile.GetComponent<Profile>().sf_type2;

        // ���� MS003
        if (planttype == 1) {
            Profile.GetComponent<Profile>().AddToInventory("VT001", 1);
            Profile.GetComponent<MissionManager>().MissionFlagOn(4, 3);
        }
        // ��Ÿ�� MS004
        else if (planttype == 2) {
            Profile.GetComponent<Profile>().AddToInventory("VT002", 1);
        }
        // ���� MS005
        else if (planttype == 3) {
            Profile.GetComponent<Profile>().AddToInventory("VT003", 1);
        }
        // �丶�� MS006
        else if (planttype == 4) {
            Profile.GetComponent<Profile>().AddToInventory("VT004", 1);
        }

        if (smartfarmtype == 1) Profile.GetComponent<Profile>().sf_type1 = 0;
        // 2�� �ǹ�
        else Profile.GetComponent<Profile>().sf_type2 = 0;

        DrawModels();

        FarmStartPage(smartfarmtype);
    }


    // �ɱ� ����
    public void StartWork() {
        if (lastselect == -1) {
            return;
        }

        Profile.GetComponent<Profile>().RemoveFromInventory(lastselect_itemcode);

        if (useNut == 1) {
            Profile.GetComponent<Profile>().RemoveFromInventory("MS001");
        }

        // 1�� �ǹ�
        if (smartfarmtype == 1) {

            // ���� MS003 30��
            if (lastselect_itemcode.Equals("MS003")) {
                Profile.GetComponent<Profile>().sf_type1 = 1;
                
                if (useNut == 1) Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(15);
                else Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(30);

                Profile.GetComponent<MissionManager>().MissionFlagOn(4, 2);
            }
            
            // ��Ÿ�� MS004 1�ð�
            else if (lastselect_itemcode.Equals("MS004")) {
                Profile.GetComponent<Profile>().sf_type1 = 2;

                if (useNut == 1) Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(30);
                else Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(60);
            }

            // ���� MS005 1�ð�
            else if (lastselect_itemcode.Equals("MS005")) {
                Profile.GetComponent<Profile>().sf_type1 = 3;

                if (useNut == 1) Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(30);
                else Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(60);
            }

            // �丶�� MS006 2�ð�
            else if (lastselect_itemcode.Equals("MS006")) {
                Profile.GetComponent<Profile>().sf_type1 = 4;

                if (useNut == 1) Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(60);
                else Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(120);
            }
        }
        // 2�� �ǹ�
        else {
            // ���� MS003 30��
            if (lastselect_itemcode.Equals("MS003")) {
                Profile.GetComponent<Profile>().sf_type2 = 1;
                
                if (useNut == 1) Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(15);
                else Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(30);
            }
            
            // ��Ÿ�� MS004 1�ð�
            else if (lastselect_itemcode.Equals("MS004")) {
                Profile.GetComponent<Profile>().sf_type2 = 2;

                if (useNut == 1) Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(30);
                else Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(60);
            }

            // ���� MS005 1�ð�
            else if (lastselect_itemcode.Equals("MS005")) {
                Profile.GetComponent<Profile>().sf_type2 = 3;

                if (useNut == 1) Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(30);
                else Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(60);
            }

            // �丶�� MS006 2�ð�
            else if (lastselect_itemcode.Equals("MS006")) {
                Profile.GetComponent<Profile>().sf_type2 = 4;

                if (useNut == 1) Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(60);
                else Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(120);
            }
        }

        Map.GetComponent<MapController>().FlagOff();
        DrawModels();
        FarmStartPage(smartfarmtype);
    }   

    public void SelectCheckbox(int section) {
        lastselect = section;
        lastselect_itemcode = seedList[section].Split('-')[0];

        for (int i = 0; i < nowSeedNum; i++) {
            if (i == section) sectionCheckboxList[i].SetActive(true);
            else sectionCheckboxList[i].SetActive(false);
        }
    }

    // ������ ��� ����
    public void flipNut() {
        if (useNut == 0) {
            NutCheckbox.gameObject.SetActive(true);
            useNut = 1;
        }
        else if (useNut == 1) {
            NutCheckbox.gameObject.SetActive(false);
            useNut = 0;
        }
    }

    public void ClosePage() {
        SmartFarmUI.SetActive(false);
        Map.GetComponent<MapController>().FlagOff();
        FarmStartPage(smartfarmtype);
    }
}
