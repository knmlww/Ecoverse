using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smartfarm_trigger : MonoBehaviour
{
    public GameObject SmartfarmManager;
    public GameObject SmartfarmUI;

    public GameObject IngameUI, MinimapUI;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("player")) {
            if (gameObject.name.Equals("trigger1in")) {
                GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = false;
                GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = true;
                GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(691f, -68.9f, -403.9f);
                Camera.main.GetComponent<CameraRotate>().enabled = false;
                Camera.main.transform.position = new Vector3(691.2f, -64.72f, -409.54f);
                Camera.main.transform.rotation = Quaternion.Euler(18.0f, 0f, 0f);
                SmartfarmManager.GetComponent<SmartFarm>().FarmStartPage(1);
                MinimapUI.SetActive(false);
                IngameUI.SetActive(false);
            }

            else if (gameObject.name.Equals("trigger2in")) {
                GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = false;
                GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = true;
                GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(712.4f, -68.7f, -403.95f);
                Camera.main.GetComponent<CameraRotate>().enabled = false;
                Camera.main.transform.position = new Vector3(712.3f, -64.9f, -409.67f);
                Camera.main.transform.rotation = Quaternion.Euler(18.0f, 0f, 0f);
                SmartfarmManager.GetComponent<SmartFarm>().FarmStartPage(2);
                MinimapUI.SetActive(false);
                IngameUI.SetActive(false);
            }

            else if (gameObject.name.Equals("trigger1out")) {
                GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = true;
                GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = false;
                GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(711.58f, 1.8f, -417.1f);
                Camera.main.GetComponent<CameraRotate>().enabled = true;
                SmartfarmManager.GetComponent<SmartFarm>().ClosePage();
                SmartfarmUI.SetActive(false);
                MinimapUI.SetActive(true);
                IngameUI.SetActive(true);
            }

            else if (gameObject.name.Equals("trigger2out")) {
                GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = true;
                GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = false;
                GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(718.9f, 1.8f, -399.67f);
                Camera.main.GetComponent<CameraRotate>().enabled = true;
                SmartfarmManager.GetComponent<SmartFarm>().ClosePage();
                SmartfarmUI.SetActive(false);
                MinimapUI.SetActive(true);
                IngameUI.SetActive(true);
            }
        }
    }
}
