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
        // ���

        // MS001 ����Ʈ�� ������
        if (item_code.Equals("MS001")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("MS001"));
            ItemTitle.text = StringDecode("����Ʈ�� ������");
            ItemContent.text = StringDecode("�۹��� ��Ȯ�ϴ� �ð��� �������� ��������ش�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 20 coin");

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

        // MS002 ����Ʈ��
        else if (item_code.Equals("MS002")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("MS002"));
            ItemTitle.text = StringDecode("����Ʈ��");
            ItemContent.text = StringDecode("���� ���� ��ġ�� �� ������, �۹��� �ɾ� ������ â���� �� �ִ�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            
            if (Profile.GetComponent<Profile>().nsmartfarm == 0) ItemPrice.text = StringDecode("���� : 200 coin\n���ڸ��ϸ��� : +5��");
            else ItemPrice.text = StringDecode("���� : 620 coin\n���ڸ��ϸ��� : +5��");

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

        // SEED ����
        else if (item_code.Equals("SEED")) {
            step = 3;
            ShopSeedPopupUI.SetActive(true);

            int mission_state = Profile.GetComponent<Profile>().mission_state;

            // ���� �̼� 2 �Ϸ� (���߸� ����)
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
            // ���� �̼� 3 �Ϸ� (����, ��Ÿ��, �丶��, ���� ����)
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

        // MS009 �ǳ��� ȭ��
        else if (item_code.Equals("MS009")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("MS009"));
            ItemTitle.text = StringDecode("�ǳ��� ȭ��");
            ItemContent.text = StringDecode("���� �����⸦ ���� ������ش�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 110 coin\n���ڸ��ϸ��� : +2��");

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

        // MS010 �ǿܿ� ȭ��
        else if (item_code.Equals("MS010")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("MS010"));
            ItemTitle.text = StringDecode("�ǿܿ� ȭ��");
            ItemContent.text = StringDecode("�ǿܿ� ��ġ�Ǵ� ȭ������ ������ ȭ���ϰ� ������ش�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 120 coin\n���ڸ��ϸ��� : +2��");

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

        // �����

        // ME001 �¾籤 ������
        else if (item_code.Equals("ME001")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("ME001"));
            ItemTitle.text = StringDecode("���ؿ� �¾籤 ������");
            ItemContent.text = StringDecode("���� ���� ��ġ�Ǵ� �¾籤 ����������, �¾��� �� �������� ���� ���⸦ ������ �� �ִ�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 520 coin\n���ڸ��ϸ��� : +8��");

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

        // ME002 �߿� �¾籤 ����
        else if (item_code.Equals("ME002")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("ME002"));
            ItemTitle.text = StringDecode("�߿� �¾籤 ����");
            ItemContent.text = StringDecode("�ǿܿ� ��ġ�ϴ� ��������, �¾��� �� �������� ���� ���⸦ ������ �� �ִ�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 220 coin\n���ڸ��ϸ��� : +3��");

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

        // ME003 ���������� ������
        else if (item_code.Equals("ME003")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("ME003"));
            ItemTitle.text = StringDecode("������������ ������");
            ItemContent.text = StringDecode("������������ �̿��� �������� ����������, ģȯ�����̴�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 420 coin\n���ڸ��ϸ��� : +6��");

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

        // ME004 ǳ�¹�����
        else if (item_code.Equals("ME004")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("ME004"));
            ItemTitle.text = StringDecode("����� ǳ�¹�����");
            ItemContent.text = StringDecode("���翡 ��ġ�Ǵ� ǳ�¹������, ǳ���� ���� ���⸦ ������ �� �ִ�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 470 coin\n���ڸ��ϸ��� : +7��");

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

        // ����

        // FT001 ����
        else if (item_code.Equals("FT001")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT001"));
            ItemTitle.text = StringDecode("����");
            ItemContent.text = StringDecode("å�� �տ� ��ġ�ϴ� �����̴�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 140 coin");

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

        // FT002 ħ��
        else if (item_code.Equals("FT002")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT002"));
            ItemTitle.text = StringDecode("ħ��");
            ItemContent.text = StringDecode("ģȯ�� �������� ���۵� ħ���̴�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 320 coin\n���ڸ��ϸ��� : +2��");

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

        // FT003 ����
        else if (item_code.Equals("FT003")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT003"));
            ItemTitle.text = StringDecode("����");
            ItemContent.text = StringDecode("���� ���� ������ ���� �ŷ����̴�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 270 coin");

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

        // FT004 å��
        else if (item_code.Equals("FT004")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT004"));
            ItemTitle.text = StringDecode("å��");
            ItemContent.text = StringDecode("ģȯ�� �������� ���۵� å���̴�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 190 coin\n���ڸ��ϸ��� : +1��");

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

        // FT005 ����
        else if (item_code.Equals("FT005")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT005"));
            ItemTitle.text = StringDecode("����");
            ItemContent.text = StringDecode("���ڿ� ��� ǳ���� ���� ������ �� ������ �� ��� ȿ���� �ִ�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 105 coin\n���ڸ��ϸ��� : +1��");

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

        // FT006 ī��
        else if (item_code.Equals("FT006")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT006"));
            ItemTitle.text = StringDecode("ī��");
            ItemContent.text = StringDecode("���� �߾� �ٴڿ� �򸰴�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 100 coin");

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

        // FT007 ���ĵ�
        else if (item_code.Equals("FT007")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT007"));
            ItemTitle.text = StringDecode("���ĵ�");
            ItemContent.text = StringDecode("����ȿ���� ���� ���ĵ�� ����� ��� ���ش�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 170 coin\n���ڸ��ϸ��� : +3��");

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

        // FT008 Ź��
        else if (item_code.Equals("FT008")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT008"));
            ItemTitle.text = StringDecode("Ź��");
            ItemContent.text = StringDecode("ģȯ�� �������� ���۵� Ź���̴�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 110 coin\n���ڸ��ϸ��� : +1��");

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

        // FT009 �ظ�
        else if (item_code.Equals("FT009")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT009"));
            ItemTitle.text = StringDecode("����Ʈ�� ������");
            ItemContent.text = StringDecode("���� �� �׷�� �Բ� �߿ܿ� ��ġ�ȴ�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 370 coin\n���ڸ��ϸ��� : +5��");

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

        // FT010 �ܿ� ����â
        else if (item_code.Equals("FT010")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT010"));
            ItemTitle.text = StringDecode("�ܿ� ����â");
            ItemContent.text = StringDecode("�ܿ������� ���۵� â������ ������ �ս��� ����.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 120 coin\n���ڸ��ϸ��� : +3��");

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

        // FT011 ��Ȱ�� �и����� ���
        else if (item_code.Equals("FT011")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT011"));
            ItemTitle.text = StringDecode("��Ȱ�� �и����� ���");
            ItemContent.text = StringDecode("����, �ö�ƽ, �Ϲݾ����⸦ �з��� �� �ִ� �и����� ����̴�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 170 coin\n���ڸ��ϸ��� : +3��");

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

        // FT012 ����
        else if (item_code.Equals("FT012")) {
            step = 2;
            ShopPopupUI.SetActive(true);
            itemIamge.GetComponent<RawImage>().texture = images.Find(x => x.name.Equals("FT012"));
            ItemTitle.text = StringDecode("����");
            ItemContent.text = StringDecode("ģȯ�� �������� ���۵� �����̴�.");
            Map.GetComponent<MapController>().FlagOn("SHOP_POPUP");
            ItemPrice.text = StringDecode("���� : 260 coin\n���ڸ��ϸ��� : +3��");

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

        // å�� ȭ��
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

        // �ǿ� ȭ��
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

        // ���ؿ� �¾籤 ������
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

        // �߿� �¾籤 ����
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

        // ������
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

        // ǳ�� ������
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

        // ���� 
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

        // ħ�� 
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

        // ����
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

        // å��
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

        // ����
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

        // ī��
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

        // ���ĵ�
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

        // Ź��
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

        // �ظ�
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

        // ����â
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

        // �и��������
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
        
        // ����
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

        // ����Ʈ�� ������
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

        // ����Ʈ��
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

        // ���� MS003
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

        // ��Ÿ�� MS004
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

        // ���� MS005
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

        // �丶�� MS006
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
