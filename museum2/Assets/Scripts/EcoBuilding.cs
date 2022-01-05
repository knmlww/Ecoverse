using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoBuilding : MonoBehaviour
{
    public GameObject popup, b1, b2, b3;
    public GameObject b1ds, b2ds;

    public GameObject mainCamera;
    public Vector3 b1campos = new Vector3(-40.7f, 63.85f, 61.56f), b2campos = new Vector3(-61.6f, 70.8f, 72.8f);
    public Vector3 b1camrot = new Vector3(22.6f, -93f, -1.8f), b2camrot = new Vector3(27f, 55f, 2.07f);

    public GameObject text1, text2;

    public GameObject ingameUI, minimapUI;

    public GameObject Profile;

    public int check;
    public GameObject otherTrigger;

    public int step = 0;

    void Start()
    {
        check = 0;
    }

    void Update()
    {
        if (step == 1) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, b1.transform.position, Time.deltaTime * 2f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, b1.transform.rotation, Time.deltaTime * 2f);
        }
        else if (step == 2) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, b2.transform.position, Time.deltaTime * 2f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, b2.transform.rotation, Time.deltaTime * 2f);
        }

        if (step == -1) {
            if (Input.GetKey(KeyCode.G)) {
                step = 1;
                mainCamera.GetComponent<CameraRotate>().enabled = false;
                GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = false;
                popup.SetActive(true);
                b1ds.SetActive(true);
                b2ds.SetActive(false);
                GameObject.FindGameObjectWithTag("player").transform.position = b3.transform.position;
                ingameUI.SetActive(false);
                minimapUI.SetActive(false);

                if (check == 0) check = 1;

                if (otherTrigger.GetComponent<EcoBuilding>().check == 1 && check == 1) {
                    Profile.GetComponent<MissionManager>().MissionFlagOn(6, 3);
                    check = -1;
                    otherTrigger.GetComponent<EcoBuilding>().check = -1;
                }   
            }
        }
        else if (step == -2) {
            if (Input.GetKey(KeyCode.G)) {
                step = 2;
                mainCamera.GetComponent<CameraRotate>().enabled = false;
                GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = false;
                popup.SetActive(true);
                b1ds.SetActive(false);
                b2ds.SetActive(true);
                GameObject.FindGameObjectWithTag("player").transform.position = b3.transform.position;
                ingameUI.SetActive(false);
                minimapUI.SetActive(false);

                if (check == 0) check = 1;

                if (otherTrigger.GetComponent<EcoBuilding>().check == 1 && check == 1) {
                    Profile.GetComponent<MissionManager>().MissionFlagOn(6, 3);
                    check = -1;
                    otherTrigger.GetComponent<EcoBuilding>().check = -1;
                }   
            }
        }
    }

    public void Back() {
        if (step != 0) {
            step = 0;
            mainCamera.GetComponent<CameraRotate>().enabled = true;
            GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = true;
            popup.SetActive(false);
            b1ds.SetActive(false);
            b2ds.SetActive(false);
            ingameUI.SetActive(true);
            minimapUI.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("player")) {
            if (gameObject.name.Equals("trigger1")) {
                step = -1;
                text1.SetActive(true);
            }

            else if (gameObject.name.Equals("trigger2")) {
                step = -2;
                text2.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("player")) {
            text1.SetActive(false);
            text2.SetActive(false);
        }
    }
}
