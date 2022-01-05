using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoEcoIsland : MonoBehaviour
{
    public GameObject Chat1, Chat2, EcoMileageUI;

    public GameObject ShipUI, Bubble, PayButton;

    public GameObject MapController;

    public GameObject Multi;

    public int tutorialFlag = 0;

    void Start()
    {
        tutorialFlag = 0;
    }

    void Update()
    {
        
    }

    public void Go() {
        GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(126.4f, 4.6f, -96.49f);
        GameObject.FindGameObjectWithTag("player").transform.rotation = Quaternion.Euler(0f, -45f, 0f);
        Chat1.SetActive(true);
        Chat2.SetActive(true);
        EcoMileageUI.SetActive(false);
        Bubble.SetActive(false);

        // if (tutorialFlag == 0) {
        //     Multi.GetComponent<Multi>().StartMulti();
        //     tutorialFlag = 1;
        // }
        // else {
            
        // }
        tutorialFlag = 1;
        Multi.GetComponent<Multi>().RestartMultiPersonalIsland();
    }

    public void PayButtonOn() {
        Bubble.SetActive(true);
    }

    public void ButtonOff() {
        Bubble.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        // MapController.GetComponent<MapController>().FlagOn("SHIP");
        PayButton.SetActive(true);
        ShipUI.SetActive(true);
    }

    void OnTriggerExit(Collider other) {
        // MapController.GetComponent<MapController>().FlagOff();
        PayButton.SetActive(false);
        ShipUI.SetActive(false);
    }
}
