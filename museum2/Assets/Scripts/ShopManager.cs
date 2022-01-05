using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class ShopManager : MonoBehaviour
{
    public int step = 0;

    public GameObject Map, Profile;

    /* Shop UI */
    public GameObject ShopPopupUI;
    public Text ItemTitle, ItemContent, ItemPrice;
    public RawImage itemIamge;
    public List<Texture> images;
    public GameObject coinwarning1;
    public GameObject lockImage, soldImage;
    public Button BuyButton1;

    /* Seed UI */
    public GameObject ShopSeedPopupUI;
    public List<GameObject> lockImages;
    public List<Button> seedButtons;
    public GameObject coinwarning2;

    public int lastSelect;

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
        if (step == 1) {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);

                if (hit.collider != null) {
                    Debug.Log(hit.transform.name);
                    ItemSelected(hit.transform.name);
                }
            }
        }

        if (step == 2 || step == 3) {
            if (Input.GetKey(KeyCode.Escape)) {
                Map.GetComponent<MapController>().FlagOff();
            }
        }
    }

    public void StartShop() {
        step = 1;
    }

    public void EndShop() {

    }

    public void ItemSelected(string item_code) {
        // 토양

        // MS001 스마트팜 영양제
        if (item_code.Equals("MS001")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("MS001"));
            ItemTitle.text = StringDecode("스마트팜 영양제");
            ItemContent.text = StringDecode("작물을 수확하는 시간을 절반으로 단축시켜준다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 20 coin");

            lastSelect = 18;


            if (Profile.GetComponent<Profile>().mission_state >= 4) {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(false);
                lockImage.SetActive(true);
            }
        }

        // MS002 스마트팜
        else if (item_code.Equals("MS002")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("MS002"));
            ItemTitle.text = StringDecode("스마트팜");
            ItemContent.text = StringDecode("개인 섬에 설치할 수 있으며, 작물을 심어 이익을 창출할 수 있다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            
            if (Profile.GetComponent<Profile>().nsmartfarm == 0) ItemPrice.text = StringDecode("가격 : 200 coin\n에코마일리지 : +5점");
            else ItemPrice.text = StringDecode("가격 : 620 coin\n에코마일리지 : +5점");

            lastSelect = 19;

            if (Profile.GetComponent<Profile>().nsmartfarm == 2) {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                if (Profile.GetComponent<Profile>().nsmartfarm < Profile.GetComponent<Profile>().soil_item_unlock) {
                    BuyButton1.gameObject.SetActive(true);
                    soldImage.SetActive(false);
                    lockImage.SetActive(false);
                }
                else if ((Profile.GetComponent<Profile>().nsmartfarm == 1 && Profile.GetComponent<Profile>().soil_item_unlock == 1) || Profile.GetComponent<Profile>().soil_item_unlock == 0) {
                    BuyButton1.gameObject.SetActive(false);
                    soldImage.SetActive(false);
                    lockImage.SetActive(true);
                }
            }
        }

        // SEED 모종
        else if (item_code.Equals("SEED")) {
            step = 3;
            ShopSeedPopupUI.SetActive(true);

            int mission_state = Profile.GetComponent<Profile>().mission_state;

            // 메인 미션 2 완료 (상추만 열림)
            if (mission_state == 4) {
                lockImages[0].SetActive(false);
                lockImages[1].SetActive(true);
                lockImages[2].SetActive(true);
                lockImages[3].SetActive(true);
                lockImages[4].SetActive(true);
                lockImages[5].SetActive(true);

                seedButtons[0].gameObject.SetActive(true);
                seedButtons[1].gameObject.SetActive(false);
                seedButtons[2].gameObject.SetActive(false);
                seedButtons[3].gameObject.SetActive(false);
                seedButtons[4].gameObject.SetActive(false);
                seedButtons[5].gameObject.SetActive(false);
            }
            // 메인 미션 3 완료 (상추, 비타민, 토마토, 바질 열림)
            else if (mission_state >= 5) { 
                lockImages[0].SetActive(false);
                lockImages[1].SetActive(false);
                lockImages[2].SetActive(false);
                lockImages[3].SetActive(false);
                lockImages[4].SetActive(true);
                lockImages[5].SetActive(true);

                seedButtons[0].gameObject.SetActive(true);
                seedButtons[1].gameObject.SetActive(true);
                seedButtons[2].gameObject.SetActive(true);
                seedButtons[3].gameObject.SetActive(true);
                seedButtons[4].gameObject.SetActive(false);
                seedButtons[5].gameObject.SetActive(false);
            }
            else {
                lockImages[0].SetActive(true);
                lockImages[1].SetActive(true);
                lockImages[2].SetActive(true);
                lockImages[3].SetActive(true);
                lockImages[4].SetActive(true);
                lockImages[5].SetActive(true);

                seedButtons[0].gameObject.SetActive(false);
                seedButtons[1].gameObject.SetActive(false);
                seedButtons[2].gameObject.SetActive(false);
                seedButtons[3].gameObject.SetActive(false);
                seedButtons[4].gameObject.SetActive(false);
                seedButtons[5].gameObject.SetActive(false);
            }

            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
        }

        // MS009 실내용 화분
        else if (item_code.Equals("MS009")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("MS009"));
            ItemTitle.text = StringDecode("실내용 화분");
            ItemContent.text = StringDecode("주위 분위기를 맑게 만들어준다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 110 coin\n에코마일리지 : +2점");

            lastSelect = 0;

            if (Profile.GetComponent<Profile>().furniture_state[0] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                if (Profile.GetComponent<Profile>().mission_state >= 4) {
                    BuyButton1.gameObject.SetActive(true);
                    soldImage.SetActive(false);
                    lockImage.SetActive(false);
                }
                else {
                    BuyButton1.gameObject.SetActive(false);
                    soldImage.SetActive(false);
                    lockImage.SetActive(true);
                }
            }
        }

        // MS010 실외용 화분
        else if (item_code.Equals("MS010")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("MS010"));
            ItemTitle.text = StringDecode("실외용 화분");
            ItemContent.text = StringDecode("실외에 배치되는 화분으로 마당을 화사하게 만들어준다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 120 coin\n에코마일리지 : +2점");

            lastSelect = 1;

            if (Profile.GetComponent<Profile>().furniture_state[1] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                if (Profile.GetComponent<Profile>().mission_state >= 4) {
                    BuyButton1.gameObject.SetActive(true);
                    soldImage.SetActive(false);
                    lockImage.SetActive(false);
                }
                else {
                    BuyButton1.gameObject.SetActive(false);
                    soldImage.SetActive(false);
                    lockImage.SetActive(true);
                }
            }
        }   

        // 신재생

        // ME001 태양광 전지판
        else if (item_code.Equals("ME001")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("ME001"));
            ItemTitle.text = StringDecode("지붕용 태양광 전지판");
            ItemContent.text = StringDecode("지붕 위에 설치되는 태양광 전지판으로, 태양의 빛 에너지를 통해 전기를 생산할 수 있다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 520 coin\n에코마일리지 : +8점");

            lastSelect = 2;

            if (Profile.GetComponent<Profile>().furniture_state[2] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                if (Profile.GetComponent<Profile>().mission_state >= 6) {
                    BuyButton1.gameObject.SetActive(true);
                    soldImage.SetActive(false);
                    lockImage.SetActive(false);
                }
                else {
                    BuyButton1.gameObject.SetActive(false);
                    soldImage.SetActive(false);
                    lockImage.SetActive(true);
                }
            }
        }   

        // ME002 야외 태양광 조명
        else if (item_code.Equals("ME002")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("ME002"));
            ItemTitle.text = StringDecode("야외 태양광 조명");
            ItemContent.text = StringDecode("실외에 위치하는 조명으로, 태양의 빛 에너지를 통해 전기를 생산할 수 있다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 220 coin\n에코마일리지 : +3점");

            lastSelect = 3;

            if (Profile.GetComponent<Profile>().furniture_state[3] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                if (Profile.GetComponent<Profile>().mission_state >= 6) {
                    BuyButton1.gameObject.SetActive(true);
                    soldImage.SetActive(false);
                    lockImage.SetActive(false);
                }
                else {
                    BuyButton1.gameObject.SetActive(false);
                    soldImage.SetActive(false);
                    lockImage.SetActive(true);
                }
            }
        }

        // ME003 지열에너지 에어컨
        else if (item_code.Equals("ME003")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("ME003"));
            ItemTitle.text = StringDecode("지열에너지용 에어컨");
            ItemContent.text = StringDecode("지열에너지를 이용한 벽걸이형 에어컨으로, 친환경적이다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 420 coin\n에코마일리지 : +6점");

            lastSelect = 4;

            if (Profile.GetComponent<Profile>().furniture_state[4] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                if (Profile.GetComponent<Profile>().mission_state >= 6) {
                    BuyButton1.gameObject.SetActive(true);
                    soldImage.SetActive(false);
                    lockImage.SetActive(false);
                }
                else {
                    BuyButton1.gameObject.SetActive(false);
                    soldImage.SetActive(false);
                    lockImage.SetActive(true);
                }
            }
        }

        // ME004 풍력발전기
        else if (item_code.Equals("ME004")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("ME004"));
            ItemTitle.text = StringDecode("마당용 풍력발전기");
            ItemContent.text = StringDecode("마당에 설치되는 풍력발전기로, 풍력을 통해 전기를 생산할 수 있다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 470 coin\n에코마일리지 : +7점");

            lastSelect = 5;

            if (Profile.GetComponent<Profile>().furniture_state[5] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                if (Profile.GetComponent<Profile>().mission_state >= 6) {
                    BuyButton1.gameObject.SetActive(true);
                    soldImage.SetActive(false);
                    lockImage.SetActive(false);
                }
                else {
                    BuyButton1.gameObject.SetActive(false);
                    soldImage.SetActive(false);
                    lockImage.SetActive(true);
                }
            }
        }

        // 가구

        // FT001 의자
        else if (item_code.Equals("FT001")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT001"));
            ItemTitle.text = StringDecode("의자");
            ItemContent.text = StringDecode("책상 앞에 위치하는 의자이다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 140 coin");

            lastSelect = 6;

            if (Profile.GetComponent<Profile>().furniture_state[6] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
        }

        // FT002 침대
        else if (item_code.Equals("FT002")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT002"));
            ItemTitle.text = StringDecode("침대");
            ItemContent.text = StringDecode("친환경 원목으로 제작된 침대이다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 320 coin\n에코마일리지 : +2점");

            lastSelect = 7;

            if (Profile.GetComponent<Profile>().furniture_state[7] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
        }

        // FT003 쇼파
        else if (item_code.Equals("FT003")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT003"));
            ItemTitle.text = StringDecode("쇼파");
            ItemContent.text = StringDecode("구름 같이 폭신한 것이 매력적이다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 270 coin");

            lastSelect = 8;

            if (Profile.GetComponent<Profile>().furniture_state[8] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
        }

        // FT004 책상
        else if (item_code.Equals("FT004")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT004"));
            ItemTitle.text = StringDecode("책상");
            ItemContent.text = StringDecode("친환경 원목으로 제작된 책상이다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 190 coin\n에코마일리지 : +1점");

            lastSelect = 9;

            if (Profile.GetComponent<Profile>().furniture_state[9] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
        }

        // FT005 액자
        else if (item_code.Equals("FT005")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT005"));
            ItemTitle.text = StringDecode("액자");
            ItemContent.text = StringDecode("액자에 담긴 풍경을 보며 힐링할 수 있으며 벽 장식 효과도 있다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 105 coin\n에코마일리지 : +1점");

            lastSelect = 10;

            if (Profile.GetComponent<Profile>().furniture_state[10] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
        }

        // FT006 카펫
        else if (item_code.Equals("FT006")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT006"));
            ItemTitle.text = StringDecode("카펫");
            ItemContent.text = StringDecode("집안 중앙 바닥에 깔린다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 100 coin");

            lastSelect = 11;

            if (Profile.GetComponent<Profile>().furniture_state[11] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
        }

        // FT007 스탠드
        else if (item_code.Equals("FT007")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT007"));
            ItemTitle.text = StringDecode("스탠드");
            ItemContent.text = StringDecode("전기효율이 높은 스탠드로 방안을 밝게 해준다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 170 coin\n에코마일리지 : +3점");

            lastSelect = 12;

            if (Profile.GetComponent<Profile>().furniture_state[12] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
        }

        // FT008 탁자
        else if (item_code.Equals("FT008")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT008"));
            ItemTitle.text = StringDecode("탁자");
            ItemContent.text = StringDecode("친환경 원목으로 제작된 탁자이다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 110 coin\n에코마일리지 : +1점");

            lastSelect = 13;

            if (Profile.GetComponent<Profile>().furniture_state[13] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
        }

        // FT009 해먹
        else if (item_code.Equals("FT009")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT009"));
            ItemTitle.text = StringDecode("스마트팜 영양제");
            ItemContent.text = StringDecode("나무 두 그루와 함께 야외에 설치된다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 370 coin\n에코마일리지 : +5점");

            lastSelect = 14;

            if (Profile.GetComponent<Profile>().furniture_state[14] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
        }

        // FT010 단열 유리창
        else if (item_code.Equals("FT010")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT010"));
            ItemTitle.text = StringDecode("단열 유리창");
            ItemContent.text = StringDecode("단열유리로 제작된 창문으로 에너지 손실이 적다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 120 coin\n에코마일리지 : +3점");

            lastSelect = 15;

            if (Profile.GetComponent<Profile>().furniture_state[15] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
        }

        // FT011 재활용 분리수거 장비
        else if (item_code.Equals("FT011")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT011"));
            ItemTitle.text = StringDecode("재활용 분리수거 장비");
            ItemContent.text = StringDecode("종이, 플라스틱, 일반쓰레기를 분류할 수 있는 분리수거 장비이다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 170 coin\n에코마일리지 : +3점");

            lastSelect = 16;

            if (Profile.GetComponent<Profile>().furniture_state[16] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
        }

        // FT012 옷장
        else if (item_code.Equals("FT012")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT012"));
            ItemTitle.text = StringDecode("옷장");
            ItemContent.text = StringDecode("친환경 원목으로 제작된 옷장이다.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("가격 : 260 coin\n에코마일리지 : +3점");

            lastSelect = 17;

            if (Profile.GetComponent<Profile>().furniture_state[17] == '1') {
                BuyButton1.gameObject.SetActive(false);
                soldImage.SetActive(true);
                lockImage.SetActive(false);
            }
            else {
                BuyButton1.gameObject.SetActive(true);
                soldImage.SetActive(false);
                lockImage.SetActive(false);
            }
        }
    }

    public void PopupClose() {
        step = 1;
        ShopPopupUI.SetActive(false);
        ShopSeedPopupUI.SetActive(false);
        Map.GetComponent<MapController>().FlagOff();
    }

    public void BuyButton() {
        
        int type = lastSelect;

        // 책상 화분
        if (type == 0) {
            if (Profile.GetComponent<Profile>().coin < 110) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-110);
                Profile.GetComponent<Profile>().furniture_state[0] = '1';
                PopupClose();
            }
        }

        // 실외 화분
        if (type == 1) {
            if (Profile.GetComponent<Profile>().coin < 120) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-120);
                Profile.GetComponent<Profile>().furniture_state[1] = '1';
                PopupClose();
            }
        }

        // 지붕용 태양광 전지판
        if (type == 2) {
            if (Profile.GetComponent<Profile>().coin < 520) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-520);
                Profile.GetComponent<Profile>().furniture_state[2] = '1';
                PopupClose();
            }
        }

        // 야외 태양광 조명
        if (type == 3) {
            if (Profile.GetComponent<Profile>().coin < 220) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-220);
                Profile.GetComponent<Profile>().furniture_state[3] = '1';
                PopupClose();
            }
        }

        // 에어컨
        if (type == 4) {
            if (Profile.GetComponent<Profile>().coin < 420) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-420);
                Profile.GetComponent<Profile>().furniture_state[4] = '1';
                PopupClose();
            }
        }

        // 풍력 발전기
        if (type == 5) {
            if (Profile.GetComponent<Profile>().coin < 470) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-470);
                Profile.GetComponent<Profile>().furniture_state[5] = '1';
                PopupClose();
            }
        }

        // 의자 
        if (type == 6) {
            if (Profile.GetComponent<Profile>().coin < 140) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-140);
                Profile.GetComponent<Profile>().furniture_state[6] = '1';
                PopupClose();
            }
        }

        // 침대 
        if (type == 7) {
            if (Profile.GetComponent<Profile>().coin < 320) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-320);
                Profile.GetComponent<Profile>().furniture_state[7] = '1';
                PopupClose();
            }
        }

        // 쇼파
        if (type == 8) {
            if (Profile.GetComponent<Profile>().coin < 270) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-270);
                Profile.GetComponent<Profile>().furniture_state[8] = '1';
                PopupClose();
            }
        }

        // 책상
        if (type == 9) {
            if (Profile.GetComponent<Profile>().coin < 190) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-190);
                Profile.GetComponent<Profile>().furniture_state[9] = '1';
                PopupClose();
            }
        }

        // 액자
        if (type == 10) {
            if (Profile.GetComponent<Profile>().coin < 105) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-105);
                Profile.GetComponent<Profile>().furniture_state[10] = '1';
                PopupClose();
            }
        }

        // 카펫
        if (type == 11) {
            if (Profile.GetComponent<Profile>().coin < 100) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-100);
                Profile.GetComponent<Profile>().furniture_state[11] = '1';
                PopupClose();
            }
        }

        // 스탠드
        if (type == 12) {
            if (Profile.GetComponent<Profile>().coin < 170) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-170);
                Profile.GetComponent<Profile>().furniture_state[12] = '1';
                PopupClose();
            }
        }

        // 탁자
        if (type == 13) {
            if (Profile.GetComponent<Profile>().coin < 110) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-110);
                Profile.GetComponent<Profile>().furniture_state[13] = '1';
                PopupClose();
            }
        }

        // 해먹
        if (type == 14) {
            if (Profile.GetComponent<Profile>().coin < 370) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-370);
                Profile.GetComponent<Profile>().furniture_state[14] = '1';
                PopupClose();
            }
        }

        // 유리창
        if (type == 15) {
            if (Profile.GetComponent<Profile>().coin < 130) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-130);
                Profile.GetComponent<Profile>().furniture_state[15] = '1';
                PopupClose();
            }
        }

        // 분리수거장비
        if (type == 16) {
            if (Profile.GetComponent<Profile>().coin < 170) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-170);
                Profile.GetComponent<Profile>().furniture_state[16] = '1';
                PopupClose();
            }
        }
        
        // 옷장
        if (type == 17) {
            if (Profile.GetComponent<Profile>().coin < 260) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-260);
                Profile.GetComponent<Profile>().furniture_state[17] = '1';
                PopupClose();
            }
        }

        // 스마트팜 영양제
        if (type == 18) {
            if (Profile.GetComponent<Profile>().coin < 20) {
                coinwarning1.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-20);
                Profile.GetComponent<Profile>().AddToInventory("MS001", 1);
                PopupClose();
            }
        }

        // 스마트팜
        if (type == 19) {
            if (Profile.GetComponent<Profile>().nsmartfarm == 0) {
                if (Profile.GetComponent<Profile>().coin < 200) {
                    coinwarning1.SetActive(true);
                    Invoke("CloseCoinWarning", 2f);
                }
                else {
                    Profile.GetComponent<Profile>().Coin(-200);
                    Profile.GetComponent<Profile>().nsmartfarm++;
                    Profile.GetComponent<MissionManager>().MissionFlagOn(4, 1);
                    PopupClose();
                }
            }
            else if (Profile.GetComponent<Profile>().nsmartfarm == 1) {
                if (Profile.GetComponent<Profile>().coin < 620) {
                    coinwarning1.SetActive(true);
                    Invoke("CloseCoinWarning", 2f);
                }
                else {
                    Profile.GetComponent<Profile>().Coin(-620);
                    Profile.GetComponent<Profile>().nsmartfarm++;
                    PopupClose();
                }
            }
        }
    }

    public void CloseCoinWarning() {
        coinwarning1.SetActive(false);
        coinwarning2.SetActive(false);
    }

    public void BuySeeds(int type) {
        string item_code = "";

        // 상추 MS003
        if (type == 0) {
            item_code = "MS003";

            if (Profile.GetComponent<Profile>().coin < 70) {
                coinwarning2.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-70);
                Profile.GetComponent<Profile>().AddToInventory(item_code, 1);
                PopupClose();
            }
        }

        // 비타민 MS004
        else if (type == 1) {
            item_code = "MS004";
            if (Profile.GetComponent<Profile>().coin < 80) {
                coinwarning2.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-80);
                Profile.GetComponent<Profile>().AddToInventory(item_code, 1);
                PopupClose();
            }
        }

        // 바질 MS005
        else if (type == 2) {
            item_code = "MS005";
            if (Profile.GetComponent<Profile>().coin < 80) {
                coinwarning2.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-80);
                Profile.GetComponent<Profile>().AddToInventory(item_code, 1);
                PopupClose();
            }
        }

        // 토마토 MS006
        else if (type == 3) {
            item_code = "MS006";
            if (Profile.GetComponent<Profile>().coin < 100) {
                coinwarning2.SetActive(true);
                Invoke("CloseCoinWarning", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-100);
                Profile.GetComponent<Profile>().AddToInventory(item_code, 1);
                PopupClose();
            }
        }
    }
}
