using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public GameObject Profile;
    public GameObject MultiManager;

    /* Pause Menu UI */
    public GameObject PauseUI;

    /* Character UI */
    public GameObject CharacterUI;

    /* Badge UI */
    public GameObject BadgeUI;
    public RawImage badge1, badge2, badge3, badge4, badge5, badge6, badge7;

    /* Inventory UI */
    public GameObject InventoryUI;
    public List<RawImage> inventoryCharactersImages;
    public Text nameText;

    public List<RawImage> slots;
    public List<Text> itemnumsTexts;
    public List<Texture> itemImages;


    /* Mission Popup UI */
    public GameObject MissionPopupUI;
    public GameObject MissionManager;

    /* Store UI */
    public GameObject ShopSeelUI;

    /* Chat UI */
    public InputField ChatInput;

    /* Smartfarm UI */
    public GameObject Smartfarm;

    /* lock flag (using 2, not using 0) */
    public int lockflag = 0;
    /* information of locker */
    // ESC : 1
    public string locker = "";

    public string beforeLocker;

    // test
    public Text testText;

    // shop chat
    public bool shopinflag;

    private void Update() {
        // testText.text = "state : " + lockflag.ToString() + " / locker : " + locker;

        if (lockflag == 0){
            ChatInput.DeactivateInputField();
            ChatInput.gameObject.SetActive(false);
        }

        // pause menu
        if (Input.GetKey(KeyCode.Escape) && lockflag == 0) {
            lockflag = 1;
            FlagOn("PAUSE");
            PauseUI.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Escape) && lockflag == 2 && locker.Equals("PAUSE")) {
            lockflag = 1;
            FlagOff();
            PauseUI.SetActive(false);
            BadgeUI.SetActive(false);
            CharacterUI.SetActive(false);
        }


        // Inventory Page
        if (Input.GetKey(KeyCode.I) && lockflag == 0) {
            lockflag = 1;
            FlagOn("Inventory");
            InventoryPage();
        }

        if (Input.GetKey(KeyCode.Escape) && lockflag == 2 && locker.Equals("Inventory")) {
            lockflag = 1;
            FlagOff();
            InventoryUI.SetActive(false);
        }

        // close badge page
        if (Input.GetKey(KeyCode.Escape) && lockflag == 2 && locker.Equals("BADGE")) {
            lockflag = 1;
            FlagOn("PAUSE");
            BadgeUI.SetActive(false);
            PauseUI.SetActive(true);
        }

        // close character page
        if (Input.GetKey(KeyCode.Escape) && lockflag == 2 && locker.Equals("CHARACTER")) {
            lockflag = 1;
            FlagOn("PAUSE");
            CharacterUI.SetActive(false);
            PauseUI.SetActive(true);
        }

        // close badge popup
        if (Input.GetKey(KeyCode.Escape) && lockflag == 2 && locker.Equals("BADGE_POPUP")) {
            Profile.GetComponent<Profile>().CloseBadgePopup();
            FlagOff();
        }

        // close mission popup
        if (Input.GetKey(KeyCode.Escape) && lockflag == 2 && locker.Equals("MISSION_POPUP")) {
            MissionPopupUI.SetActive(false);
            FlagOff();
        }

        // Chat
        if (!shopinflag && Input.GetKey(KeyCode.T) && lockflag == 0) {
            lockflag = 1;
            FlagOn("CHAT");
            ChatInput.gameObject.SetActive(true);
            ChatInput.ActivateInputField();
        }

        if (Input.GetKey(KeyCode.Escape) && lockflag == 2 && locker.Equals("CHAT")) {
            ChatInput.gameObject.SetActive(false);
            FlagOff();
        }

        // Smartfarm
        if (Input.GetKey(KeyCode.Escape) && lockflag == 2 && locker.Equals("SMARTFARM1")) {
            Smartfarm.GetComponent<SmartFarm>().ClosePage();
            FlagOff();
        }
    }

    public void FlagOn(string lockername) {
        Invoke("turnFlagOn", 0.3f);
        locker = lockername;
    }

    public void FlagOff() {
        Invoke("turnFlagOff", 0.3f);
        locker = "";
    }

    private void turnFlagOff() {
        lockflag = 0;
    }

    private void turnFlagOn() {
        lockflag = 2;
    }

    public void BadgePage() {
        lockflag = 1;
        FlagOn("BADGE");
        PauseUI.SetActive(false);
        BadgeUI.SetActive(true);

        char[] badge_state = Profile.GetComponent<Profile>().badge_state;

        if (badge_state[0] == '1') {
            badge1.gameObject.SetActive(true);
        }
        if (badge_state[1] == '1') {
            badge2.gameObject.SetActive(true);
        }
        if (badge_state[2] == '1') {
            badge3.gameObject.SetActive(true);
        }
        if (badge_state[3] == '1') {
            badge4.gameObject.SetActive(true);
        }
        if (badge_state[4] == '1') {
            badge5.gameObject.SetActive(true);
        }
        if (badge_state[5] == '1') {
            badge6.gameObject.SetActive(true);
        }
        if (badge_state[6] == '1') {
            badge7.gameObject.SetActive(true);
        }
    }

    public void CharacterShopPage() {
        lockflag = 1;
        FlagOn("CHARACTER");
        PauseUI.SetActive(false);
        CharacterUI.SetActive(true);
        CharacterUI.GetComponent<CharacterShop>().CharacterShopPage();
    }

    public void InventoryPage() {
        InventoryUI.SetActive(true);
        int player = Profile.GetComponent<Profile>().player;

        int i;
        for (i = 0; i < inventoryCharactersImages.Count; i++) {
            if (i == player) {
                inventoryCharactersImages[i].gameObject.SetActive(true);
            }
            else {
                inventoryCharactersImages[i].gameObject.SetActive(false);
            }
        }

        nameText.text = Profile.GetComponent<Profile>().nickname;

        //draw items
        List<string> inventory_state = Profile.GetComponent<Profile>().inventory_state;
        
        for (i = 1; i < inventory_state.Count; i++) {
            string[] temparr = inventory_state[i].Split('-');
            slots[i - 1].gameObject.SetActive(true);
            itemnumsTexts[i - 1].gameObject.SetActive(true);
            slots[i - 1].GetComponent<RawImage>().texture = itemImages.Find(x => x.name.Equals(temparr[0]));
            itemnumsTexts[i - 1].text = temparr[1];
        }

        for (; i < 21; i++) {
            slots[i - 1].gameObject.SetActive(false);
            itemnumsTexts[i - 1].gameObject.SetActive(false);
        }
        
    }

    public void MissionPopupPage() {
        MissionPopupUI.SetActive(true);
        FlagOn("MISSION_POPUP");

        int mission_state = Profile.GetComponent<Profile>().mission_state;
        if (mission_state <= 1 && Profile.GetComponent<MissionManager>().completeFlag) {
            Profile.GetComponent<MissionManager>().NextTutorialMission();
        }

        MissionManager.GetComponent<MissionManager>().MissionUpdate();
        if (mission_state != 2) Profile.GetComponent<MissionManager>().completeFlag = false;
    }

    public void MissionPopupClose() {
        MissionPopupUI.SetActive(false);
        FlagOff();
    }
}
