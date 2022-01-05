using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class SmartFarm : MonoBehaviour
{   
    public GameObject Profile, Map;

    // 현재 들어와있는 스마트팜 번호
    public int smartfarmtype;

    // 남은 시간 텍스트
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

    // 영양제 관련 섹션, 체크박스
    public GameObject NutSection;
    public RawImage NutCheckbox;
    public Text NutNumText;

    public List<Texture> itemTextures;
    
    // 가지고 있는 씨앗 종류 수, 마지막 선택 (체크박스), 영양제 사용 여부
    public int nowSeedNum, lastselect, useNut;
    public string lastselect_itemcode;

    // 현재 가지고 있는 씨앗 리스트
    List<string> seedList;

    // 스마트팜1
    public List<GameObject> basilList1, vitList1, LecList1, tomList1;
    
    // 스마트팜2
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
                    // 시간이 다 된 경우
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
                    // 시간이 다 된 경우
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

            // 상추
            if (planttype == 1) {
                int mindiff = (Profile.GetComponent<Profile>().sf1time - DateTime.Now).Minutes;
                // 다 자란 경우
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf1time) >= 0) {
                    LecList1[2].SetActive(true);
                }
                // 절반 이하
                else if (mindiff <= 15) {
                    LecList1[1].SetActive(true);
                }
                else {
                    LecList1[0].SetActive(true);
                }
            }

            // 비타민
            else if (planttype == 2) {
                int mindiff = (Profile.GetComponent<Profile>().sf1time - DateTime.Now).Minutes;
                // 다 자란 경우
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf1time) >= 0) {
                    vitList1[2].SetActive(true);
                }
                // 절반 이하
                else if (mindiff <= 30) {
                    vitList1[1].SetActive(true);
                }
                else {
                    vitList1[0].SetActive(true);
                }
            }

            // 바질
            else if (planttype == 3) {
                int mindiff = (Profile.GetComponent<Profile>().sf1time - DateTime.Now).Minutes;
                // 다 자란 경우
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf1time) >= 0) {
                    basilList1[2].SetActive(true);
                }
                // 절반 이하
                else if (mindiff <= 30) {
                    basilList1[1].SetActive(true);
                }
                else {
                    basilList1[0].SetActive(true);
                }
            }

            // 토마토
            else if (planttype == 4) {
                int mindiff = (Profile.GetComponent<Profile>().sf1time - DateTime.Now).Minutes;
                // 다 자란 경우
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf1time) >= 0) {
                    tomList1[2].SetActive(true);
                }
                // 절반 이하
                else if (mindiff <= 60) {
                    tomList1[1].SetActive(true);
                }
                else {
                    tomList1[0].SetActive(true);
                }
            }
        }

        // 스마트팜2
        else {
            int planttype = Profile.GetComponent<Profile>().sf_type2;
            DateTime leftTime = Profile.GetComponent<Profile>().sf2time;

            // 상추
            if (planttype == 1) {
                int mindiff = (Profile.GetComponent<Profile>().sf2time - DateTime.Now).Minutes;
                // 다 자란 경우
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf2time) >= 0) {
                    LecList2[2].SetActive(true);
                }
                // 절반 이하
                else if (mindiff <= 15) {
                    LecList2[1].SetActive(true);
                }
                else {
                    LecList2[0].SetActive(true);
                }
            }

            // 비타민
            else if (planttype == 2) {
                int mindiff = (Profile.GetComponent<Profile>().sf2time - DateTime.Now).Minutes;
                // 다 자란 경우
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf2time) >= 0) {
                    vitList2[2].SetActive(true);
                }
                // 절반 이하
                else if (mindiff <= 30) {
                    vitList2[1].SetActive(true);
                }
                else {
                    vitList2[0].SetActive(true);
                }
            }

            // 바질
            else if (planttype == 3) {
                int mindiff = (Profile.GetComponent<Profile>().sf2time - DateTime.Now).Minutes;
                // 다 자란 경우
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf2time) >= 0) {
                    basilList2[2].SetActive(true);
                }
                // 절반 이하
                else if (mindiff <= 30) {
                    basilList2[1].SetActive(true);
                }
                else {
                    basilList2[0].SetActive(true);
                }
            }

            // 토마토
            else if (planttype == 4) {
                int mindiff = (Profile.GetComponent<Profile>().sf2time - DateTime.Now).Minutes;
                // 다 자란 경우
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf2time) >= 0) {
                    tomList2[2].SetActive(true);
                }
                // 절반 이하
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
            // 안심은 경우
            if (Profile.GetComponent<Profile>().sf_type1 == 0) {
                TimeDraw.SetActive(false);
                StartButton.gameObject.SetActive(true);
                GetButton.gameObject.SetActive(false);

                DrawModels();
            }

            // 심은 경우 
            else {
                // 시간이 다 된 경우

                // if (DateTime.Now > Profile.GetComponent<Profile>().sf1time) {
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf1time) >= 0) {
                    TimeDraw.SetActive(true);
                    StartButton.gameObject.SetActive(false);
                    GetButton.gameObject.SetActive(true);

                    screenTime = true;

                    DrawModels();
                }

                // 시간이 남은 경우
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
            // 안심은 경우
            if (Profile.GetComponent<Profile>().sf_type2 == 0) {
                TimeDraw.SetActive(false);
                StartButton.gameObject.SetActive(true);
                GetButton.gameObject.SetActive(false);

                DrawModels();
            }

            // 심은 경우 
            else {
                // 시간이 다 된 경우
                if (DateTime.Compare(DateTime.Now, Profile.GetComponent<Profile>().sf2time) >= 0) {
                    TimeDraw.SetActive(true);
                    StartButton.gameObject.SetActive(false);
                    GetButton.gameObject.SetActive(true);

                    screenTime = true;

                    DrawModels();
                }

                // 시간이 남은 경우
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

        // 가지고 있는 씨앗 정보 수집 , 영양제 보유 여부 체크
        for (int i = 1; i < inventory_state.Count; i++) {
            string[] temparr = inventory_state[i].Split('-');

            if (temparr[0].Equals("MS003") || temparr[0].Equals("MS004") || temparr[0].Equals("MS005") || temparr[0].Equals("MS006")) 
            {
                seedList.Add(inventory_state[i]);
            }

            else if (temparr[0].Equals("MS001")) {
                NutSection.SetActive(true);
                NutNumText.text = StringDecode(temparr[1]);
                useNut = 0; // 사용할 수 있는데 안함
            }
        }

        // 영양제 체크박스 초기화, 비활성화
        NutCheckbox.gameObject.SetActive(false);
        if (useNut == -1) {
            NutSection.SetActive(false);
        }

        // 섹션 비활성화
        for (int i = 0; i < sectionList.Count; i++) {
            sectionList[i].SetActive(false);
            sectionCheckboxList[i].SetActive(false);
        }

        // 가지고 있는 씨앗 개수
        nowSeedNum = seedList.Count;

        // 가지고 있는 씨앗만큼 섹션 활성화 밑 정보 표시
        for (int i = 0; i < nowSeedNum; i++) {
            string[] temparr = seedList[i].Split('-');
            sectionList[i].SetActive(true); // 섹션 활성화 
            sectionItemImageList[i].GetComponent<RawImage>().texture = itemTextures.Find(x => x.name.Equals(temparr[0])); // 이미지 변경
            sectionItemNumberList[i].text = StringDecode(temparr[1]);

            if (temparr[0].Equals("MS003")) {
                sectionItemNameList[i].text = StringDecode("상추 모종");
                sectionItemDiscList[i].text = StringDecode("30분 소요, 100 coin으로 판매 가능");
            }
            else if (temparr[0].Equals("MS004")) {
                sectionItemNameList[i].text = StringDecode("비타민 모종");
                sectionItemDiscList[i].text = StringDecode("1시간 소요, 115 coin으로 판매 가능");
            }
            else if (temparr[0].Equals("MS005")) {
                sectionItemNameList[i].text = StringDecode("바질 모종");
                sectionItemDiscList[i].text = StringDecode("1시간 소요, 120 coin으로 판매 가능");
            }
            else if (temparr[0].Equals("MS006")) {
                sectionItemNameList[i].text = StringDecode("토마토 모종");
                sectionItemDiscList[i].text = StringDecode("2시간 소요, 145 coin으로 판매 가능");
            }
        }

        DrawModels();
    }

    // 수확
    public void Get() { 
        int planttype;

        // 1번 건물
        if (smartfarmtype == 1) planttype = Profile.GetComponent<Profile>().sf_type1;
        // 2번 건물
        else planttype = Profile.GetComponent<Profile>().sf_type2;

        // 상추 MS003
        if (planttype == 1) {
            Profile.GetComponent<Profile>().AddToInventory("VT001", 1);
            Profile.GetComponent<MissionManager>().MissionFlagOn(4, 3);
        }
        // 비타민 MS004
        else if (planttype == 2) {
            Profile.GetComponent<Profile>().AddToInventory("VT002", 1);
        }
        // 바질 MS005
        else if (planttype == 3) {
            Profile.GetComponent<Profile>().AddToInventory("VT003", 1);
        }
        // 토마토 MS006
        else if (planttype == 4) {
            Profile.GetComponent<Profile>().AddToInventory("VT004", 1);
        }

        if (smartfarmtype == 1) Profile.GetComponent<Profile>().sf_type1 = 0;
        // 2번 건물
        else Profile.GetComponent<Profile>().sf_type2 = 0;

        DrawModels();

        FarmStartPage(smartfarmtype);
    }


    // 심기 시작
    public void StartWork() {
        if (lastselect == -1) {
            return;
        }

        Profile.GetComponent<Profile>().RemoveFromInventory(lastselect_itemcode);

        if (useNut == 1) {
            Profile.GetComponent<Profile>().RemoveFromInventory("MS001");
        }

        // 1번 건물
        if (smartfarmtype == 1) {

            // 상추 MS003 30분
            if (lastselect_itemcode.Equals("MS003")) {
                Profile.GetComponent<Profile>().sf_type1 = 1;
                
                if (useNut == 1) Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(15);
                else Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(30);

                Profile.GetComponent<MissionManager>().MissionFlagOn(4, 2);
            }
            
            // 비타민 MS004 1시간
            else if (lastselect_itemcode.Equals("MS004")) {
                Profile.GetComponent<Profile>().sf_type1 = 2;

                if (useNut == 1) Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(30);
                else Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(60);
            }

            // 바질 MS005 1시간
            else if (lastselect_itemcode.Equals("MS005")) {
                Profile.GetComponent<Profile>().sf_type1 = 3;

                if (useNut == 1) Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(30);
                else Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(60);
            }

            // 토마토 MS006 2시간
            else if (lastselect_itemcode.Equals("MS006")) {
                Profile.GetComponent<Profile>().sf_type1 = 4;

                if (useNut == 1) Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(60);
                else Profile.GetComponent<Profile>().sf1time = DateTime.Now.AddMinutes(120);
            }
        }
        // 2번 건물
        else {
            // 상추 MS003 30분
            if (lastselect_itemcode.Equals("MS003")) {
                Profile.GetComponent<Profile>().sf_type2 = 1;
                
                if (useNut == 1) Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(15);
                else Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(30);
            }
            
            // 비타민 MS004 1시간
            else if (lastselect_itemcode.Equals("MS004")) {
                Profile.GetComponent<Profile>().sf_type2 = 2;

                if (useNut == 1) Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(30);
                else Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(60);
            }

            // 바질 MS005 1시간
            else if (lastselect_itemcode.Equals("MS005")) {
                Profile.GetComponent<Profile>().sf_type2 = 3;

                if (useNut == 1) Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(30);
                else Profile.GetComponent<Profile>().sf2time = DateTime.Now.AddMinutes(60);
            }

            // 토마토 MS006 2시간
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

    // 영양제 사용 여부
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
