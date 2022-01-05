using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class CharacterShop : MonoBehaviour
{ 
    public GameObject Profile, MultiManager;
    public GameObject ch1_unlock, ch2_unlock, ch3_unlock, ch4_unlock, ch5_unlock, ch6_unlock;
    public GameObject ch1_lock, ch2_lock, ch3_lock, ch4_lock, ch5_lock, ch6_lock;
    public Button ch1_button, ch2_button, ch3_button, ch4_button, ch5_button, ch6_button;

    public GameObject coin_warning;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterShopPage() {
        char[] unlockinfo = Profile.GetComponent<Profile>().character_unlock;
        int player = Profile.GetComponent<Profile>().player;

        // ch1 dog
        if (unlockinfo[0] == '1') {
            ch1_unlock.SetActive(true);
            ch1_lock.SetActive(false);
            if (player == 0) {
                ch1_button.gameObject.transform.Find("Using").gameObject.SetActive(true);
                ch1_button.gameObject.transform.Find("Select").gameObject.SetActive(false);
                ch1_button.gameObject.transform.Find("Buy").gameObject.SetActive(false);
            }
            else {
                ch1_button.gameObject.transform.Find("Using").gameObject.SetActive(false);
                ch1_button.gameObject.transform.Find("Select").gameObject.SetActive(true);
                ch1_button.gameObject.transform.Find("Buy").gameObject.SetActive(false);
            }
        }
        else {
            ch1_unlock.SetActive(false);
            ch1_lock.SetActive(true);
            ch1_button.gameObject.transform.Find("Using").gameObject.SetActive(false);
            ch1_button.gameObject.transform.Find("Select").gameObject.SetActive(false);
            ch1_button.gameObject.transform.Find("Buy").gameObject.SetActive(true);
        }

        // ch2 cat
        if (unlockinfo[1] == '1') {
            ch2_unlock.SetActive(true);
            ch2_lock.SetActive(false);
            if (player == 1) {
                ch2_button.gameObject.transform.Find("Using").gameObject.SetActive(true);
                ch2_button.gameObject.transform.Find("Select").gameObject.SetActive(false);
                ch2_button.gameObject.transform.Find("Buy").gameObject.SetActive(false);
            }
            else {
                ch2_button.gameObject.transform.Find("Using").gameObject.SetActive(false);
                ch2_button.gameObject.transform.Find("Select").gameObject.SetActive(true);
                ch2_button.gameObject.transform.Find("Buy").gameObject.SetActive(false);
            }
        }
        else {
            ch2_unlock.SetActive(false);
            ch2_lock.SetActive(true);
            ch2_button.gameObject.transform.Find("Using").gameObject.SetActive(false);
            ch2_button.gameObject.transform.Find("Select").gameObject.SetActive(false);
            ch2_button.gameObject.transform.Find("Buy").gameObject.SetActive(true);
        }

        // ch3 mouse
        if (unlockinfo[2] == '1') {
            ch3_unlock.SetActive(true);
            ch3_lock.SetActive(false);
            if (player == 2) {
                ch3_button.gameObject.transform.Find("Using").gameObject.SetActive(true);
                ch3_button.gameObject.transform.Find("Select").gameObject.SetActive(false);
                ch3_button.gameObject.transform.Find("Buy").gameObject.SetActive(false);
            }
            else {
                ch3_button.gameObject.transform.Find("Using").gameObject.SetActive(false);
                ch3_button.gameObject.transform.Find("Select").gameObject.SetActive(true);
                ch3_button.gameObject.transform.Find("Buy").gameObject.SetActive(false);
            }
        }
        else {
            ch3_unlock.SetActive(false);
            ch3_lock.SetActive(true);
            ch3_button.gameObject.transform.Find("Using").gameObject.SetActive(false);
            ch3_button.gameObject.transform.Find("Select").gameObject.SetActive(false);
            ch3_button.gameObject.transform.Find("Buy").gameObject.SetActive(true);
        }

        // ch4 rabbit
        if (unlockinfo[3] == '1') {
            ch4_unlock.SetActive(true);
            ch4_lock.SetActive(false);
            if (player == 3) {
                ch4_button.gameObject.transform.Find("Using").gameObject.SetActive(true);
                ch4_button.gameObject.transform.Find("Select").gameObject.SetActive(false);
                ch4_button.gameObject.transform.Find("Buy").gameObject.SetActive(false);
            }
            else {
                ch4_button.gameObject.transform.Find("Using").gameObject.SetActive(false);
                ch4_button.gameObject.transform.Find("Select").gameObject.SetActive(true);
                ch4_button.gameObject.transform.Find("Buy").gameObject.SetActive(false);
            }
        }
        else {
            ch4_unlock.SetActive(false);
            ch4_lock.SetActive(true);
            ch4_button.gameObject.transform.Find("Using").gameObject.SetActive(false);
            ch4_button.gameObject.transform.Find("Select").gameObject.SetActive(false);
            ch4_button.gameObject.transform.Find("Buy").gameObject.SetActive(true);
        }

        // ch5 parrot
        if (unlockinfo[4] == '1') {
            ch5_unlock.SetActive(true);
            ch5_lock.SetActive(false);
            if (player == 4) {
                ch5_button.gameObject.transform.Find("Using").gameObject.SetActive(true);
                ch5_button.gameObject.transform.Find("Select").gameObject.SetActive(false);
                ch5_button.gameObject.transform.Find("Buy").gameObject.SetActive(false);
            }
            else {
                ch5_button.gameObject.transform.Find("Using").gameObject.SetActive(false);
                ch5_button.gameObject.transform.Find("Select").gameObject.SetActive(true);
                ch5_button.gameObject.transform.Find("Buy").gameObject.SetActive(false);
            }
        }
        else {
            ch5_unlock.SetActive(false);
            ch5_lock.SetActive(true);
            ch5_button.gameObject.transform.Find("Using").gameObject.SetActive(false);
            ch5_button.gameObject.transform.Find("Select").gameObject.SetActive(false);
            ch5_button.gameObject.transform.Find("Buy").gameObject.SetActive(true);
        }

        // ch6 turtle
        if (unlockinfo[5] == '1') {
            ch6_unlock.SetActive(true);
            ch6_lock.SetActive(false);
            if (player == 5) {
                ch6_button.gameObject.transform.Find("Using").gameObject.SetActive(true);
                ch6_button.gameObject.transform.Find("Select").gameObject.SetActive(false);
                ch6_button.gameObject.transform.Find("Buy").gameObject.SetActive(false);
            }
            else {
                ch6_button.gameObject.transform.Find("Using").gameObject.SetActive(false);
                ch6_button.gameObject.transform.Find("Select").gameObject.SetActive(true);
                ch6_button.gameObject.transform.Find("Buy").gameObject.SetActive(false);
            }
        }
        else {
            ch6_unlock.SetActive(false);
            ch6_lock.SetActive(true);
            ch6_button.gameObject.transform.Find("Using").gameObject.SetActive(false);
            ch6_button.gameObject.transform.Find("Select").gameObject.SetActive(false);
            ch6_button.gameObject.transform.Find("Buy").gameObject.SetActive(true);
        }
    }

    public void PressButton(int s) {
        char[] unlockinfo = Profile.GetComponent<Profile>().character_unlock;
        int player = Profile.GetComponent<Profile>().player;
        int coin = Profile.GetComponent<Profile>().coin;

        if (unlockinfo[s] == '1') {
            if (player == s) {
                // equal
                
            }
            else {
                // 
                Profile.GetComponent<Profile>().player = s;
                CharacterShopPage();
                MultiManager.GetComponent<Multi>().RestartMulti();
            }
        } 
        else {
            // 
            if (coin < 1000) {
                coin_warning.SetActive(true);
                Invoke("popupoff", 2f);
            }
            else {
                Profile.GetComponent<Profile>().Coin(-1000);
                Profile.GetComponent<Profile>().character_unlock[s] = '1';
                CharacterShopPage();

                Profile.GetComponent<Profile>().CheckBadge();
            }
        }
    }

    public void popupoff() {
        coin_warning.SetActive(false);
    }
}
