using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Text;

public class Profile : MonoBehaviour
{
    int step = 0;
    Camera mainCamera;
    private Vector3 titleCamPos = new Vector3(144.0966f, 17.78041f, -215.2413f), titleCamRot = new Vector3(-13.716f, -33.864f, 0f);
    private Vector3 loginCamPos = new Vector3(144.0966f, 17.78041f, -215.2413f), loginCamRot = new Vector3(-30f, -33.864f, 0f);

    /* Personal Information */
    private string email;
    public string nickname;
    public int player;
    public int mission_state;
    public char[] submission_state;
    public int museum_unlock;
    public int soil_item_unlock;
    public int energy_item_unlock;
    public int coin;
    public char[] furniture_state;
    public string[] smartfarm_state;

    public int nsmartfarm, sf_type1, sf_type2;
    public DateTime sf1time, sf2time;

    public List<string> inventory_state;
    public int ecomileage;

    public char[] badge_state;

    // soccer, egg
    public int badge_subinfo1, badge_subinfo2;

    // energy museum minigame success info
    public char[] badge_subinfo3;

    public char[] character_unlock;

    /* Scene UI */
    public Text coinText;
    
    /* Title UI */
    public GameObject TitleUI;

    /* Pause UI */
    public GameObject PauseUI;


    /* Login UI */
    public GameObject LoginUI;
    public InputField login_emailInput;
    public InputField login_passwordInput;
    public RawImage login_warning;

    /* Register UI */
    public GameObject RegisterUI;
    public InputField reg_emailInput, reg_passwordInput, reg_nicknameInput;
    public RawImage nick_warning, email_warning;

    /* First Select Character UI */
    public GameObject FirstSelectUI;

    /* Ingame UI */
    public GameObject ingameUI, minimapUI;

    /* Ecomileage UI */
    public GameObject EcomileageUI;
    public Image ecoBar;

    // Multi Manager
    public GameObject Multi, Chat, Map;

    /* Badge Popup */
    public GameObject BadgePopupUI;
    public Text badgeText;
    public List<RawImage> badgeImages;
    public List<string> badgeExpTexts;

    /* shop UI */
    public GameObject ShopSellUI;
    public GameObject notosellWarning, sellcompleteWarning;

    // coin
    int coin_target;

    int[] mileages = new int[]{2, 2, 8, 3, 6, 7, 0, 2, 0, 1, 1, 0, 3, 1, 5, 3, 3, 3};


    void Awake() {
        mainCamera = Camera.main;
        step = 0;

        Map = GameObject.Find("MAP");
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }

    void Update() {
        // coin text
        coinText.text = coin.ToString();

        if (step == 0) {
            if (Input.GetMouseButtonDown(0)) {
                step = 1;
                TitleUI.SetActive(false);
                LoginUI.SetActive(true);
            }
        }
        else if (step == 1) {
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, Quaternion.Euler(-30f, -33.864f, 0f), Time.deltaTime);
        }

        if (step == 1) {
            if(Input.GetKey(KeyCode.Return)) {
                Login();
            }
        }

        if (step == 2) {
            if (Input.GetKey(KeyCode.Return)) {
                Register();
            }
            else if (Input.GetKey(KeyCode.Escape)) {
                step = 1;
                RegToLogin();
            }
        }

        // coin
        if (coin > coin_target) {
            if (Mathf.Abs(coin - coin_target) > 100) coin -= 100;
            else coin--;
        }
        else if (coin < coin_target) {
            if (Mathf.Abs(coin - coin_target) > 100) coin += 100;
            else coin++;
        }
        coinText.text = coin.ToString();

        // ecomileage

        ecoBar.fillAmount = ecomileage / 100f;
    }

    public void cal_ecomileage() {
        int rt = 0;

        // ½º¸¶Æ®ÆÊ
        rt += nsmartfarm * 5;

        for (int i = 0; i < 18; i++) {
            if (furniture_state[i] == '1') rt += mileages[i];
        }

        if (rt >= 20) {
            gameObject.GetComponent<MissionManager>().MissionFlagOn(6, 5);
        }

        ecomileage = rt;
    }

    public void Logout() {
        TitleUI.SetActive(true);
        ingameUI.SetActive(false);
        minimapUI.SetActive(false);
        PauseUI.SetActive(false);

        Multi.GetComponent<Multi>().StopMulti();

        ShopSellUI.SetActive(false);

        Invoke("ToStep0", 0.5f);
    }

    public void ToStep0() {
        step = 0;
    }

    public void Login() {
        string emailtext = login_emailInput.text;
        string passwordtext = login_passwordInput.text;
        
        if (emailtext.Equals("") || passwordtext.Equals("")) 
        {
            //
        }
        else {
            StartCoroutine(LoginProcess("login?email=" + emailtext + "&password=" + passwordtext, ""));
        }

        login_emailInput.text = "";
        login_passwordInput.text = "";
    }
            

    IEnumerator LoginProcess(string to, string query) {
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
            string result = www.downloadHandler.text;
            if (result.Equals("0")) {
                // Fail to Login
                login_warning.gameObject.SetActive(true);
            }
            else {
                // In to the game
                StartCoroutine(LoadProcess("load?name=" + result, "", true));
                login_warning.gameObject.SetActive(false);
            }   
        }
    }

    IEnumerator LoadProcess(string to, string query, bool lg) {
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
            // 0              1         2  3  4  5  6  7  8  9                   10                                     11  12  13       14   15
            // test@test.com  testuser  0  0  0  0  0  0  0  000000000000000000  0/0/00-00-00-00-00/0/0/00-00-00-00-00  -   0   0000000  0/0  000000
            string[] result = www.downloadHandler.text.Split('&');
            email = result[0];
            nickname = result[1];
            player = int.Parse(result[2]);
            mission_state = int.Parse(result[3]);
            submission_state = result[4].ToCharArray();
            museum_unlock = int.Parse(result[5]);
            soil_item_unlock = int.Parse(result[6]);
            energy_item_unlock = int.Parse(result[7]);
            coin = int.Parse(result[8]);

            furniture_state = result[9].ToCharArray();
            smartfarm_state = result[10].Split('?');

            nsmartfarm = int.Parse(smartfarm_state[0]);
            sf_type1 = int.Parse(smartfarm_state[1]);
            sf1time = DateTime.Parse(smartfarm_state[2]);
            sf_type2 = int.Parse(smartfarm_state[3]);
            sf2time = DateTime.Parse(smartfarm_state[4]);

            string[] temp = result[11].Split('/');
            inventory_state = new List<string>();

            foreach (string t in temp) {
                inventory_state.Add(t);
            }

            ecomileage = int.Parse(result[12]);
            badge_state = result[13].ToCharArray();
            badge_subinfo1 = int.Parse(result[14].Split('/')[0]);
            badge_subinfo2 = int.Parse(result[14].Split('/')[1]);
            badge_subinfo3 = result[14].Split('/')[2].ToCharArray();

            character_unlock = result[15].ToCharArray();
            coin_target = coin;

            if (lg) {
                LoginUI.SetActive(false);
                ingameUI.SetActive(true);
                minimapUI.SetActive(true);
                GameObject.Find("MAP").GetComponent<MapController>().enabled = true;
                Multi.GetComponent<Multi>().StartMulti();
                Chat.GetComponent<Chat>().Init();
                step = 4;
            }   
        }
    }

    public void LoginToReg() {
        step = 2;
        LoginUI.SetActive(false);
        RegisterUI.SetActive(true);
        nick_warning.gameObject.SetActive(false);
        email_warning.gameObject.SetActive(false);
    }

    public void RegToLogin() {
        step = 1;
        LoginUI.SetActive(true);
        RegisterUI.SetActive(false);
        login_warning.gameObject.SetActive(false);
    }

    public void Register() {
        string emailtext = reg_emailInput.text;
        string nametext = reg_nicknameInput.text;
        string passwordtext = reg_passwordInput.text;

        email = emailtext;
        nickname = nametext;

        if (emailtext.Equals("") || nametext.Equals("") || passwordtext.Equals("")) {
            //
        }
        else {
            StartCoroutine(RegisterProcess("register?email=" + emailtext + "&password=" + passwordtext + "&name=" + nametext, ""));
        }

        reg_emailInput.text = "";
        reg_nicknameInput.text = "";
        reg_passwordInput.text = "";
    }

    IEnumerator RegisterProcess(string to, string query) {
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
            string result = www.downloadHandler.text;
            if (result.Equals("-1")) 
            {
                // already logined
                email_warning.gameObject.SetActive(true);
                nick_warning.gameObject.SetActive(false);
            }
            else if (result.Equals("-2")) 
            {
                // same nickname
                email_warning.gameObject.SetActive(false);
                nick_warning.gameObject.SetActive(true);

            } else if (result.Equals("1")) 
            {
                // success
                step = 3;
                StartCoroutine(LoadProcess("load?name=" + nickname, "", false));
                email_warning.gameObject.SetActive(false);
                nick_warning.gameObject.SetActive(false);
                // select player
                RegisterUI.SetActive(false);
                FirstSelectUI.SetActive(true);
            }
            else 
            {
                // fail
            }
        }
    }

    public void selectCharButton(int t) {
        step = 4;
        player = t;
        character_unlock[t] = '1';

        FirstSelectUI.SetActive(false);
        ingameUI.SetActive(false);
        minimapUI.SetActive(false);
        GameObject.Find("MAP").GetComponent<MapController>().enabled = true;
        Multi.GetComponent<Multi>().StartMulti();
        Chat.GetComponent<Chat>().Init();

        GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(699.7f, 2.6f, -421.4f);
        Camera.main.transform.position = new Vector3(714f, 3.4f, -428f);
        Camera.main.transform.rotation = Quaternion.Euler(0f, -47.9f, 0f);
        Multi.GetComponent<Multi>().StopMultiPersonalIsland();
        gameObject.GetComponent<Tutorial>().StartTutorial();
    }

    public void init() {
        
    }

    void OnApplicationQuit()
    {
        save();
    }

    public void save() {
        string q = "save?name=" + nickname + "&player=" + player.ToString() + "&mission_state=" + mission_state.ToString()
                 + "&submission_state=" + string.Concat(submission_state) + "&museum_unlock=" + museum_unlock.ToString() 
                 + "&soil_item_unlock=" + soil_item_unlock.ToString() + "&energy_item_unlock=" + energy_item_unlock.ToString()
                 + "&coin=" + coin.ToString() + "&furniture_state=" + string.Concat(furniture_state) + "&smartfarm_state=" + nsmartfarm.ToString() + "?" + sf_type1.ToString() + "?" + sf1time.ToString("yyyy-MM-dd HH:mm:ss")
                 + "?" + sf_type2.ToString() + "?" + sf2time.ToString("yyyy-MM-dd HH:mm:ss")
                 + "&inventory_state=" + string.Join("/", inventory_state.ToArray()) + "&ecomileage=" + ecomileage.ToString() + "&badge_state=" + string.Concat(badge_state)
                 + "&badge_subinfo=" + badge_subinfo1.ToString() + "/" + badge_subinfo2.ToString() + "/" + string.Concat(badge_subinfo3) + "&character_unlock=" + string.Concat(character_unlock);

        StartCoroutine(SaveProcess(q, ""));
    }

    IEnumerator SaveProcess(string to, string query) {
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
            // done
        }
    }

    // add coin
    public void Coin(int p) {
        coin_target = (coin + p);
    }

    /* Quit Application */ 
    public void QuitGame() {
        Application.Quit();
    }

    public void CheckBadge() {
        // 2. energy minigame
        if (badge_state[1] == '0' && badge_subinfo3[0] == '1' && badge_subinfo3[1] == '1' && badge_subinfo3[2] == '1') {
            badge_state[1] = '1';
            BadgePopup(1);
        }

        // 4. all character 
        if (badge_state[4] == '0' && character_unlock[0] == '1' && character_unlock[1] == '1' && character_unlock[2] == '1' && character_unlock[3] == '1' && 
                character_unlock[4] == '1' && character_unlock[5] == '1') {
            badge_state[4] = '1';
            BadgePopup(4);
        } 

        // 5. soccer
        if (badge_state[5] == '0' && badge_subinfo1 == 20) {
            badge_state[5] = '1';
            BadgePopup(5);
        }

        // 6. coin eggs
        if (badge_state[6] == '0' && badge_subinfo2 == 50) {
            badge_state[6] = '1';
            BadgePopup(6);
        }
    }

    // Badge Popup
    public void BadgePopup(int t) {
        BadgePopupUI.SetActive(true);

        Map.GetComponent<MapController>().FlagOn("BADGE_POPUP");
        Coin(100);

        for (int i = 0; i < badgeImages.Count; i++) {
            if (t == i) {
                badgeImages[i].gameObject.SetActive(true);
                badgeText.text = StringDecode(badgeExpTexts[i]);
            }
            else badgeImages[i].gameObject.SetActive(false);
        }
    }

    public int AddToInventory(string item_code, int number) {
        int idx = inventory_state.FindIndex(x => x.Contains(item_code));

        if (idx == -1) {
            string temp = item_code + "-" + number.ToString();
            inventory_state.Add(temp);
            return 0;
        }
        else {
            string temp = inventory_state[idx];
            string[] temparr = temp.Split('-');

            if (int.Parse(temparr[1]) + number < 0) {
                return -1;
            }
            string newnum = (int.Parse(temparr[1]) + number).ToString();
            inventory_state[idx] = temparr[0] + "-" + newnum;

            return 0;
        }
    }

    public void RemoveFromInventory(string item_code) {
        int idx = inventory_state.FindIndex(x => x.Contains(item_code));

        string temp = inventory_state[idx];
        string[] temparr = temp.Split('-');

        int newnum = (int.Parse(temparr[1]) - 1);
        if (newnum == 0) {
            inventory_state.Remove(temp);
        }
        else {
            inventory_state[idx] = temparr[0] + "-" + newnum.ToString();
        }
    }

    public void SellAll() {
        List<string> tosell = new List<string>();
        int sellcoin = 0;

        for (int i = 1; i < inventory_state.Count; i++) {
            string[] temparr = inventory_state[i].Split('-');

            if (temparr[0].Equals("VT001")) {
                sellcoin += (int.Parse(temparr[1]) * 100);
                tosell.Add(inventory_state[i]);
                gameObject.GetComponent<MissionManager>().MissionFlagOn(4, 4);
            }
            else if (temparr[0].Equals("VT002")) {
                sellcoin += (int.Parse(temparr[1]) * 115);
                tosell.Add(inventory_state[i]);
            }
            else if (temparr[0].Equals("VT003")) {
                sellcoin += (int.Parse(temparr[1]) * 120);
                tosell.Add(inventory_state[i]);
            }
            else if (temparr[0].Equals("VT004")) {
                sellcoin += (int.Parse(temparr[1]) * 145);
                tosell.Add(inventory_state[i]);
            }
            else if (temparr[0].Equals("VT005")) {
                sellcoin += (int.Parse(temparr[1]) * 160);
                tosell.Add(inventory_state[i]);
            }
            else if (temparr[0].Equals("VT006")) {
                sellcoin += (int.Parse(temparr[1]) * 195);
                tosell.Add(inventory_state[i]);
            }
        }

        // nothing to sell
        if (sellcoin == 0) {
            notosellWarning.SetActive(true);
            Invoke("CloseShopWarning", 2f);
        }
        else {
            foreach (string toremove in tosell) {
                inventory_state.Remove(toremove);
            }

            Coin(sellcoin);

            // sell complete
            sellcompleteWarning.SetActive(true);
        }
    }

    public void CloseShopWarning() {
        notosellWarning.SetActive(false);
        sellcompleteWarning.SetActive(false);
    }



    public void CloseBadgePopup() {
        BadgePopupUI.SetActive(false);
        Map.GetComponent<MapController>().FlagOff();
    }
}
