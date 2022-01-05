using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPIsland : MonoBehaviour
{
    public GameObject Chat1, Chat2, EcoMileageUI;

    public GameObject ShipUI, Bubble, PayButton;

    public GameObject MapController;

    public GameObject Multi, Furniture, Profile;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void Go() {
        GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(699.8f, 2.1f, -422.2f);
        GameObject.FindGameObjectWithTag("player").transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        Chat1.SetActive(false);
        Chat2.SetActive(false);
        EcoMileageUI.SetActive(true);
        Bubble.SetActive(false);
        Profile.GetComponent<Profile>().cal_ecomileage();

        Multi.GetComponent<Multi>().StopMultiPersonalIsland();
        Furniture.GetComponent<Furniture>().UpdateState();
    }

    public void PayButtonOn() {
        Bubble.SetActive(true);
    }

    public void ButtonOff() {
        Bubble.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("player")) {
            // MapController.GetComponent<MapController>().FlagOn("SHIP");
            PayButton.SetActive(true);
            ShipUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("player")) {
            // MapController.GetComponent<MapController>().FlagOff();
            PayButton.SetActive(false);
            ShipUI.SetActive(false);
        }
    }
}
