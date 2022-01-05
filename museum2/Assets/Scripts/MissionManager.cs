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
            // if (completeFlag) missionInfoText.text = "현재진행중인 미션 1/3";
            // else 
            missionInfoText.text = StringDecode("현재진행중인 미션 0/3");
        }
        else if (Profile.GetComponent<Profile>().mission_state == 1) {
            // if (completeFlag) missionInfoText.text = "현재진행중인 미션 2/3";
            // else 
            missionInfoText.text = StringDecode("현재진행중인 미션 1/3");
        }
        else if (Profile.GetComponent<Profile>().mission_state == 2) {
            if (completeFlag) missionInfoText.text = StringDecode("현재진행중인 미션 3/3");
            else missionInfoText.text = StringDecode("현재진행중인 미션 2/3");
        }

        // 메인 미션 1 토양관 공부
        else if (Profile.GetComponent<Profile>().mission_state == 3) {
            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            int count = 0;
            foreach (char t in submission_state) {
                if (t == '1') count++;
            }

            missionInfoText.text = StringDecode("현재진행중인 미션 " + count.ToString() + "/5");
        }

        // 스마트팜
        else if (Profile.GetComponent<Profile>().mission_state == 4) {
            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            int count = 0;
            foreach (char t in submission_state) {
                if (t == '1') count++;
            }

            missionInfoText.text = StringDecode("현재진행중인 미션 " + count.ToString() + "/4");
        }

        // 신재생
        else if (Profile.GetComponent<Profile>().mission_state == 5) {
            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            int count = 0;
            foreach (char t in submission_state) {
                if (t == '1') count++;
            }

            missionInfoText.text = StringDecode("현재진행중인 미션 " + count.ToString() + "/5");
        }

        // 신재생 에코 아일랜드 둘러보기
        else if (Profile.GetComponent<Profile>().mission_state == 6) {
            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            int count = 0;
            foreach (char t in submission_state) {
                if (t == '1') count++;
            }

            missionInfoText.text = StringDecode("현재진행중인 미션 " + count.ToString() + "/5");
        }

        // 미션 완료
        else if (Profile.GetComponent<Profile>().mission_state == 7) {
            missionInfoText.text = StringDecode("모든 미션을 완료했습니다!");
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

        // 튜토리얼 달성 이전
        // 튜토리얼 1번 진행 - 뻐끔이와 대화 진행
        if (mission_state == 0) {
            RewardSection.SetActive(false);
            missionTitleText.text = StringDecode("튜토리얼");
            CompleteButton.SetActive(false);

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(false);
            missionSection5.SetActive(false);

            missionText[0].text = StringDecode("뻐끔이와 대화 진행");
            missionText[1].text = StringDecode("개인 섬에서 보트를 타고 에코 아일랜드로 이동하기");
            missionText[2].text = StringDecode("에코 아일랜드에서 코인 에그 하나 줍기");

            checkeds[0].gameObject.SetActive(false); checkeds[1].gameObject.SetActive(false); checkeds[2].gameObject.SetActive(false); 

            // if (completeFlag) {
            //     checkeds[0].gameObject.SetActive(true);
            // }
            // else {
            //     checkeds[0].gameObject.SetActive(false);
            // }
        } 

        // 튜토리얼 2번 진행 - 보트를 타고 에코 아일랜드로 이동하기
        else if (mission_state == 1) {
            RewardSection.SetActive(false);
            missionTitleText.text = StringDecode("튜토리얼");
            CompleteButton.SetActive(false);

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(false);
            missionSection5.SetActive(false);

            missionText[0].text = StringDecode("뻐끔이와 대화 진행");
            missionText[1].text = StringDecode("개인 섬에서 보트를 타고 에코 아일랜드로 이동하기");
            missionText[2].text = StringDecode("에코 아일랜드에서 코인 에그 하나 줍기");

            checkeds[0].gameObject.SetActive(true); checkeds[2].gameObject.SetActive(false); checkeds[1].gameObject.SetActive(false);

            // if (completeFlag) {
            //     checkeds[1].gameObject.SetActive(true);
            // }
            // else {
                
            // }
        }

        // 튜토리얼 3번 진행 - 에코 아일랜드에서 코인 에그 하나 줍기
        else if (mission_state == 2) {
            RewardSection.SetActive(false);
            missionTitleText.text = StringDecode("튜토리얼");

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(false);
            missionSection5.SetActive(false);

            missionText[0].text = StringDecode("뻐끔이와 대화 진행");
            missionText[1].text = StringDecode("개인 섬에서 보트를 타고 에코 아일랜드로 이동하기");
            missionText[2].text = StringDecode("에코 아일랜드에서 코인 에그 하나 줍기");

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
        
        // 메인미션 1 진행 - 토양에 관해 공부해보기
        else if (mission_state == 3) {
            missionTitleText.text = StringDecode("토양에 관해 공부해보기");
            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(true);
            missionSection5.SetActive(true);

            RewardSection.SetActive(true);
            RewardText.text = StringDecode("상점에 토양관 섹션 아이템들 unlock + 70코인");

            missionText[0].text = StringDecode("토양관 입장하기");
            missionText[1].text = StringDecode("토양오염에 대해 공부하고 \'산성비 체험관\' 들어가서 체험해보기");
            missionText[2].text = StringDecode("\'올바른 비료로 화분 키우기\' 미니게임 플레이하기");
            missionText[3].text = StringDecode("토양오염 실제 사례에 대해 공부하고 \'러브커넬 영상관\' 시청하기");
            missionText[4].text = StringDecode("토양오염을 극복하기 위한 방안을 공부한 후 토양관에서 나가기");

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

        // 메인미션 2 진행 - 스마트팜으로 돈 벌어오기
        else if (mission_state == 4) {
            missionTitleText.text = StringDecode("스마트팜으로 돈 벌어오기");

            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(true);
            missionSection5.SetActive(false);

            RewardSection.SetActive(true);
            RewardText.text = StringDecode("스마트팜 추가 구매 + 모종 3종 unlock + 70코인");

            missionText[0].text = StringDecode("구구부부상점 방문해서 스마트팜 설치 구매하기");
            missionText[1].text = StringDecode("개인섬으로 이동하여 스마트팜 설치 후 상추 심기");
            missionText[2].text = StringDecode("상추 수확하기");
            missionText[3].text = StringDecode("구구부부상점으로 가서 상추 판매하여 돈 벌기");

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

        // 메인미션 3 진행 - 신재생에너지관에 대해 공부해보기
        else if (mission_state == 5) {
            missionTitleText.text = StringDecode("신재생에너지관에 대해 공부해보기");

            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(true);
            missionSection5.SetActive(true);

            RewardSection.SetActive(true);
            RewardText.text = StringDecode("상점에 신재생에너지관 섹션 아이템들 unlock + 70코인");

            missionText[0].text = StringDecode("신재생에너지관 입장하기");
            missionText[1].text = StringDecode("\'신에너지&재생에너지 구분하기\' 미니게임 플레이하기 ");
            missionText[2].text = StringDecode("\'OX 게임\' 미니게임 플레이하기");
            missionText[3].text = StringDecode("\'퍼즐 맞추기\' 미니게임 플레이하기");
            missionText[4].text = StringDecode("생활 속 신재생에너지 공부하고 \'베딩턴 제로에너지\' 체험관 체험하기");

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

        // 메인미션 4 진행 - 에코 아일랜드에서 신재생에너지 사례 살펴보기
        else if (mission_state == 6) {
            missionTitleText.text = StringDecode("에코 아일랜드에서 신재생에너지 사례 살펴보기");

            char[] submission_state = Profile.GetComponent<Profile>().submission_state;

            missionSection1.SetActive(true);
            missionSection2.SetActive(true);
            missionSection3.SetActive(true);
            missionSection4.SetActive(true);
            missionSection5.SetActive(true);

            RewardSection.SetActive(true);
            RewardText.text = StringDecode("70코인");

            missionText[0].text = StringDecode("solar 축구장에 가서 골 넣기");
            missionText[1].text = StringDecode("휭휭관람차 탑승하기");
            missionText[2].text = StringDecode("에코빌딩단지에 있는 건물 구경하기");
            missionText[3].text = StringDecode("수소·전기차 승차장에 가서 1바퀴 운전 주행 마치기");
            missionText[4].text = StringDecode("아이템으로 개인섬의 에코마일리지 20퍼센트로 올리기");

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

        // 1차 모든 메인미션 완료
        else if (mission_state == 7) {
            missionTitleText.text = StringDecode("모든 미션을 완료했습니다.");

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

        // 튜토리얼 달성 이전
        // 튜토리얼 1번 진행 - 뻐끔이와 대화 진행
        if (mission_state == 0) {
            // MissionPopupUI.SetActive(false);
            checkedIcon.gameObject.SetActive(false);
            return;
        } 

        // 튜토리얼 2번 진행 - 보트를 타고 에코 아일랜드로 이동하기
        else if (mission_state == 1) {
            // MissionPopupUI.SetActive(false);
            checkedIcon.gameObject.SetActive(false);
            return;
        }
    }

    public void NextMission() {
        int mission_state = Profile.GetComponent<Profile>().mission_state;

        // 튜토리얼 3번 진행 - 에코 아일랜드에서 코인 에그 하나 줍기
        if (mission_state == 2) {
            Profile.GetComponent<Profile>().mission_state = 3;

            // 토양관 열림
            Profile.GetComponent<Profile>().museum_unlock = 1;

            // 메인미션 1로 넘어감
            Profile.GetComponent<Profile>().submission_state = new char[5]{'0', '0', '0', '0', '0'};
        }   

        // 메인미션 1 진행 - 토양에 관해 공부해보기 -> soil_item_unlock 1로 해제 (상추, 스마트팜 1개만)
        else if (mission_state == 3) {
            Profile.GetComponent<Profile>().mission_state = 4;
            Profile.GetComponent<Profile>().soil_item_unlock = 1;
            Profile.GetComponent<Profile>().Coin(70);

            // 메인미션 2로 넘어감
            Profile.GetComponent<Profile>().submission_state = new char[4]{'0', '0', '0', '0'};
        }

        // 메인미션 2 진행 - 스마트팜으로 돈 벌어오기 -> soil_item_unlock 2로 해제 (전부)
        else if (mission_state == 4) {
            Profile.GetComponent<Profile>().mission_state = 5;
            Profile.GetComponent<Profile>().soil_item_unlock = 2;
            Profile.GetComponent<Profile>().Coin(70);

            // 신재생에너지관 열림
            Profile.GetComponent<Profile>().museum_unlock = 2;

            // 메인미션 3로 넘어감
            Profile.GetComponent<Profile>().submission_state = new char[5]{'0', '0', '0', '0', '0'};
        }

        // 메인미션 3 진행 - 신재생에너지관에 대해 공부해보기
        else if (mission_state == 5) {
            Profile.GetComponent<Profile>().mission_state = 6;
            Profile.GetComponent<Profile>().energy_item_unlock = 1;
            Profile.GetComponent<Profile>().Coin(70);

            // 메인미션 4로 넘어감
            Profile.GetComponent<Profile>().submission_state = new char[5]{'0', '0', '0', '0', '0'};
        }

        // 메인미션 4 진행 - 에코 아일랜드에서 신재생에너지 사례 살펴보기
        else if (mission_state == 6) {
            Profile.GetComponent<Profile>().mission_state = 7;
            Profile.GetComponent<Profile>().Coin(70);

            Profile.GetComponent<Profile>().submission_state = new char[1]{'0'};
        }

        // 1차 모든 메인미션 완료
        else if (mission_state == 7) {
            
        }

        Map.GetComponent<MapController>().MissionPopupClose();
    }
}
