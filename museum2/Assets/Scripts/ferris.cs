using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ferris : MonoBehaviour
{
    public GameObject wheel;
    public GameObject mainCamera;
    public GameObject capsule;

    public GameObject player;

    public GameObject minimapUI, ingameUI;

    public GameObject FerrisUI, Bubble, PayButton;

    public GameObject MapController;

    public GameObject Profile;
    public GameObject coin_warning;

    public bool flag;

    void Start()
    {
        flag = false;
        //ride();
    }

    void Update()
    {
        if (flag) {
            Vector3 pos = capsule.transform.position;
            pos.x += 3f;
            pos.z += 3f;
            mainCamera.transform.position = pos;
        }
    }

    public void ride() {
        if (Profile.GetComponent<Profile>().coin >= 100) {
            Profile.GetComponent<Profile>().Coin(-100);

            FerrisUI.SetActive(false);
            Bubble.SetActive(false);
            PayButton.SetActive(false);
            minimapUI.SetActive(false);
            ingameUI.SetActive(false);
            player = GameObject.FindGameObjectWithTag("player");
            player.transform.position = new Vector3(-109.3f, -15f, -79.3f);
            player.GetComponent<FirstView>().enabled = false;
            mainCamera.GetComponent<CameraRotate>().enabled = false;
            wheel.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            mainCamera.transform.eulerAngles = new Vector3(0f, 45f, 0f);
            flag = true;

            Profile.GetComponent<MissionManager>().MissionFlagOn(6, 2);

            Invoke("StopRide", 120f);
        }
        else {
            coin_warning.SetActive(true);
            Invoke("ClosePopup", 2f);
        }
    }

    void ClosePopup() {
        coin_warning.SetActive(false);
    }

    public void StopRide() {
        minimapUI.SetActive(true);
        ingameUI.SetActive(true);
        player.transform.position = new Vector3(-109.3f, 4.5f, -79.3f);
        player.transform.rotation = Quaternion.Euler(0f, 45f, 0f);
        player.GetComponent<FirstView>().enabled = true;
        mainCamera.GetComponent<CameraRotate>().enabled = true;
        mainCamera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        flag = false;
    }

    public void PayButtonOn() {
        Bubble.SetActive(true);
    }

    public void ButtonOff() {
        Bubble.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("player")) {
            // MapController.GetComponent<MapController>().FlagOn("FERRIS");
            PayButton.SetActive(true);
            FerrisUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("player")) {
            // MapController.GetComponent<MapController>().FlagOff();
            PayButton.SetActive(false);
            FerrisUI.SetActive(false);
        }
    }
}
