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
        letterText.text = StringDecode("안녕하세요! " + nickname + "님\n\n이 섬에 거주하시기를 결정해주셔서 감사합니다.\n\n섬의 전체적인 구성과 소개는 섬에 도착하시면\n\n제가 직접 설명드리겠습니다.\n\n그럼 이삿날 뵐게요!");
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

        bubbleText.text = StringDecode("안녕하세요! " + nickname + "님!\n\n이 섬으로 이사오신 것을 정말 환영합니다.\n\n우선 간단하게 섬을 소개해드릴게요!");

        Invoke("Step2", 8f);
    }

    public void Step2() {
        sceneStep = 2;

        bubbleText.text = StringDecode("이 선착장에서 보트를 타고 에코 아일랜드로 이동하실 수 있습니다.");

        Invoke("Step3", 8f);
    }

    public void Step3() {
        sceneStep = 3;

        bubbleText.text = StringDecode("이 곳은 이전 주인이 농작물을 기르다가 중간에 그만두면서 방치되었어요.\n\n" + nickname + "님께서 이 곳을 운영하신다면 정말 좋은 농장이 탄생할 것 같네요!\n\n작물을 재배해서 수익도 낼 수 있습니다.");

        Invoke("Step4", 10f);
    }

    public void Step4() {
        sceneStep = 4;

        bubbleText.text = StringDecode("이 곳이 " + nickname + "님께서 거주하실 집입니다. \n\n 한 번 들어가보시겠어요?");

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

        bubbleText.text = StringDecode("사용한지 꽤 오래되어서 먼지가 많이 쌓여있네요.\n이 집은 " + nickname + "님께서 하나씩 바꾸어나가시면 완벽한 집이 될거예요!");

        Invoke("Step6", 5f);
    }

    public void Step6() {
        sceneStep = 6;

        bubbleText.text = StringDecode("에코 아일랜드에 가시면 돈을 벌고 여러 친환경적인 가구나 아이템들을 구매해서 " + nickname + "님의 섬을 꾸밀 수 있습니다.\n");

        Invoke("Step7", 5f);
    }

    public void Step7() {
        sceneStep = 7;

        mstep = 1;
        ecomileageUI.SetActive(true);

        bubbleText.text = StringDecode("이 때, 에코 마일리지바가 올라가는 것을 보실 수 있어요.\n\n에코 마일리지바는 현재 이 섬에서 에너지를 얼마나 효율적으로 사용하고 있는지를 보여줍니다.");
    
        // Invoke("Step8", 5f);
    }

    public void Step8() {
        Map.GetComponent<MapController>().FlagOff();
         ecomileageUI.SetActive(false);
        sceneStep = 8;

        bubbleText.text = StringDecode("친환경 아이템을 이용해 에코마일리지를 쌓아 환경을 위한 삶을 실천해보세요!\n\n이제 다시 집 밖으로 나가볼까요?");
    }

    public void Step9() {
        Map.GetComponent<MapController>().FlagOn("TUTORIAL");
        sceneStep = 9;

        bubbleText.text = StringDecode("그럼 이제 에코 아일랜드로 가볼까요?\n\n저도 마침 갈 일이 있으니 같이 가요!");

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

        bubbleText.text = StringDecode("에코 아일랜드에 도착했습니다! \n\n이 곳에서 박물관을 관람하며 환경에 대해 공부하고 다양한 활동을 체험할 수 있어요!\n\n다양한 활동을 체험하며 뱃지도 모아보세요.");

        //MissionManager.GetComponent<MissionManager>().SubMissionFlagOn();
        Profile.GetComponent<Profile>().mission_state = 2;
    
        Invoke("Step12", 10f);
    }

    public void Step12() {
        sceneStep = 12;

        bubbleText.text = StringDecode("이 섬에는 \'코인 에그\'가 있어요. \n\n코인 에그를 찾으시면 안에 있는 코인을 획득할 수 있어요. 코인 에그의 각 종류마다 들어있는 코인 수도 다르니 이 점 참고하세요!\n\n그럼 코인에그를 한 개 찾아서 코인을 얻어보세요!");
    
        Invoke("Step12A", 12f);
    }

    public void Step12A() {
        scene2.SetActive(false);
        Map.GetComponent<MapController>().FlagOff();
    }

    public void Step13() {
        sceneStep = 13;

        scene2.SetActive(true);
        bubbleText.text = StringDecode("좋아요! 그럼 이제부터 에코 아일랜드에서 좋은 추억을 쌓아가길 바랄게요 " + nickname + "님!");

        MissionManager.GetComponent<MissionManager>().SubMissionFlagOn();

        Invoke("EndTutorial", 8f);
    }

    public void EndTutorial() {
        fish.SetActive(false);
        scene2.SetActive(false);
        TutorialUI.SetActive(false);
    }
}
