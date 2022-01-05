using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Text;

public class TradeShop : MonoBehaviour
{
    public GameObject Profile, Map;

    public List<string> saleList;
    public List<GameObject> furPrefabList;
    public List<GameObject> instanceList;

    /* Buy UI */
    public GameObject tradeBuyUI;
    public GameObject coin_warning;
    public GameObject soldwarning;
    public RawImage itemImage;
    public Text itemText, itemPriceText, itemExpText;
    public Button BuyButton;

    public List<Texture> itemImages;
    public List<GameObject> baisList;

    public int buylastselect;
    public int buylastselect_itemidx;

    /* Sell UI */
    public GameObject tradeSellUI, selectPageUI;
    public List<GameObject> sectionList;
    public List<Text> sectionItemTextList;
    public List<RawImage> sectionCheckboxList;

    public List<string> itemNameList, itemCodeList, itemExpList;

    public InputField priceInputField;
    public Button SellStartButton;

    public int lastselect;
    public string lastselect_itemcode;
    public int last_select_itemIndex;

    public List<string> canSellCodeList;
    public List<int> canSellNumList;

    public int step = 0;

    void Start()
    {
        step = 0;
    }

    void Update()
    {
        if (step == 1) {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);

                if (hit.collider != null) {
                    if (hit.collider.name.Contains("EX-")) {
                        ItemSelected(int.Parse(hit.transform.name.Split('-')[1]));
                    }
                }
            }
        }

        if (step == 2 || step == 3) {
            if (Input.GetKey(KeyCode.Escape)) {
                Map.GetComponent<MapController>().FlagOff();
                CloseBuyPage();
                CloseSellPage();
            }
        }

        if (step == 3) {
            if (!priceInputField.text.Equals("")) {
                if (int.Parse(priceInputField.text) > 0 && lastselect != -1) {
                SellStartButton.gameObject.SetActive(true);
                }
                else SellStartButton.gameObject.SetActive(false);
            }
            else SellStartButton.gameObject.SetActive(false);
        }
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }


    // 판매 페이지
    public void SellPageOn() {
        selectPageUI.SetActive(true);
        Map.GetComponent<MapController>().FlagOn("TRADE_SELL");
        step = 3;

        lastselect = -1;

        // 가구 개수 세기

        char[] furniture_state = Profile.GetComponent<Profile>().furniture_state;

        int sectionPointer = 0;

        // 섹션 초기화
        for (int j = 0; j < 12; j++) {
            sectionList[j].gameObject.SetActive(false);
        }

        int i = 6;
        for (; i < furniture_state.Length; i++) {
            if (furniture_state[i] == '1') {
                sectionList[sectionPointer].gameObject.SetActive(true);
                sectionItemTextList[sectionPointer].text = StringDecode(itemNameList[i]);
                sectionCheckboxList[sectionPointer].gameObject.SetActive(false);
                sectionPointer++;

                canSellCodeList.Add(itemCodeList[i - 6]);
                canSellNumList.Add(i);
            }
        }
    }

    // 판매할 체크박스
    public void SellItemSelect(int s) {
        lastselect = s;

        for (int i = 0; i < sectionCheckboxList.Count; i++) {
            if (i == s) sectionCheckboxList[i].gameObject.SetActive(true);
            else sectionCheckboxList[i].gameObject.SetActive(false);
        }

        lastselect_itemcode = canSellCodeList[s];
        last_select_itemIndex = canSellNumList[s];
    }


    // 구매 - 아이템 선택 시 뜨는 창
    public void ItemSelected(int section_number) {
        if (section_number >= saleList.Count) return;

        tradeBuyUI.SetActive(true);
        Map.GetComponent<MapController>().FlagOn("TRADE1");
        step = 2;

        string temp = saleList[section_number];
        string[] temparr = temp.Split('&');

        itemImage.GetComponent<RawImage>().texture = itemImages.Find(x => x.name.Equals(temparr[0]));
        itemText.text = StringDecode(itemNameList[itemCodeList.FindIndex(x => x.Equals(temparr[0])) + 6]);
        itemPriceText.text = StringDecode("거래소 가격 : " + temparr[1]);
        itemExpText.text = StringDecode(itemExpList[itemCodeList.FindIndex(x => x.Equals(temparr[0]))] + "\n\n판매자 : " + temparr[2]);

        if (Profile.GetComponent<Profile>().furniture_state[itemCodeList.FindIndex(x => x.Equals(temparr[0])) + 6] == '1') {
            BuyButton.gameObject.SetActive(false);
            soldwarning.SetActive(true);
        }
        else {
            BuyButton.gameObject.SetActive(true);
            soldwarning.SetActive(false);
        }

        buylastselect = section_number;
        buylastselect_itemidx = itemCodeList.FindIndex(x => x.Equals(temparr[0])) + 6;
    }

    public void BuyPayButton() {
        string temp = saleList[buylastselect];
        string[] temparr = temp.Split('&');

        int leftmoney = Profile.GetComponent<Profile>().coin;

        if (leftmoney >= int.Parse(temparr[1])) {
            Profile.GetComponent<Profile>().furniture_state[buylastselect_itemidx] = '1';
            Profile.GetComponent<Profile>().Coin(-1 * int.Parse(temparr[1]));
            StartCoroutine(BuyProcess("trade/buy?item_code=" + temparr[0] + "&name=" + temparr[2] + "&price=" + temparr[1], ""));
            CloseBuyPage();
        }
        else {
            coin_warning.SetActive(true);
            Invoke("closeCoinWarning", 2f);
            // CloseBuyPage();
        }
    }

    public void closeCoinWarning() {
        coin_warning.SetActive(false);
    }

    // 구매
    IEnumerator BuyProcess(string to, string query) {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        if (!query.Equals("")) {
            formData.Add(new MultipartFormDataSection(query));
        }

        UnityWebRequest www = UnityWebRequest.Post("http://158.247.221.17:8000/" + to, formData);
        yield return www.SendWebRequest();

        if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError)) {
            Debug.Log(www.error);
        }
        else {
            UpdateItem();
            DrawModel();
        }
    }

    // 거래소 아이템 가져오기
    public void UpdateItem() {
        StartCoroutine(UpdateProcess("trade/update", ""));
    }

    IEnumerator UpdateProcess(string to, string query) {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        if (!query.Equals("")) {
            formData.Add(new MultipartFormDataSection(query));
        }

        UnityWebRequest www = UnityWebRequest.Post("http://158.247.221.17:8000/" + to, formData);
        yield return www.SendWebRequest();

        if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError)) {
            Debug.Log(www.error);
        }
        else {
            string[] result = www.downloadHandler.text.Split('?');

            saleList.Clear();
            saleList = new List<string>();

            for (int i = 0; i < result.Length; i++) {
                saleList.Add(result[i]);
            }

            DrawModel();
        }
    }

    // 모델 배치
    public void DrawModel() {
        
        buylastselect = -1;

        if (instanceList.Count > 0) {
            for (int i = 0; i < instanceList.Count; i++) {
                Destroy(instanceList[i]);
            }
        }

        instanceList = new List<GameObject>();

        for (int i = 0; i < saleList.Count; i++) {
            string[] temparr = saleList[i].Split('&');

            if (saleList.Equals("")) continue;

            GameObject instance = Instantiate(furPrefabList.Find(x => x.name.Equals(temparr[0])));
            Vector3 tempvec = baisList[i].transform.position;
            if (temparr[0].Equals("FT003") || temparr[0].Equals("FT005") || temparr[0].Equals("FT006")) tempvec.y += 0.5f;
            else if (temparr[0].Equals("FT008")) tempvec.y += 1f;
            instance.transform.position = tempvec;
            instanceList.Add(instance);
        }
    }

    // 판매 업로드
    public void SellUpload() {
        Profile.GetComponent<Profile>().furniture_state[last_select_itemIndex] = '0';
        StartCoroutine(SellUpload("trade/upload?item_code=" + lastselect_itemcode + "&name=" + Profile.GetComponent<Profile>().nickname + "&price=" + priceInputField.text, ""));
        priceInputField.text = "";
    }

    IEnumerator SellUpload(string to, string query) {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        if (!query.Equals("")) {
            formData.Add(new MultipartFormDataSection(query));
        }

        UnityWebRequest www = UnityWebRequest.Post("http://158.247.221.17:8000/" + to, formData);
        yield return www.SendWebRequest();

        if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError)) {
            Debug.Log(www.error);
        }
        else {
            // string result = www.downloadHandler.text;
            CloseSellPage();
        }
    }

    public void CloseSellPage() {
        selectPageUI.SetActive(false);
        Map.GetComponent<MapController>().FlagOff();
        step = 1;
        lastselect = -1;
    }

    public void CloseBuyPage() {
        tradeBuyUI.SetActive(false);
        Map.GetComponent<MapController>().FlagOff();
        step = 1;
    }
}
