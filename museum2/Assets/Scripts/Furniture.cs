using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    public List<GameObject> furnitures;
    public GameObject Profile;

    /* UIs */
    public GameObject MinimapUI, IngameUI;

    public GameObject insideFurniture, outsideFurniture;

    public GameObject no_window, no_solar_light, yes_window;

    public GameObject smartfarm1, smartfarm2;

    public GameObject HomeIn, HomeOut;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateState() {
        char[] furniture_state = Profile.GetComponent<Profile>().furniture_state;

        for (int i = 0; i < furniture_state.Length; i++) {
            if (furniture_state[i] == '1') {
                furnitures[i].SetActive(true);

                if (i == 3) {
                    no_solar_light.SetActive(false);
                }
                if (i == 15) {
                    no_window.SetActive(false);
                    yes_window.SetActive(true);
                }
            }
            else {
                furnitures[i].SetActive(false);

                if (i == 3) {
                    no_solar_light.SetActive(true);
                }
                if (i == 15) {
                    no_window.SetActive(true);
                    yes_window.SetActive(false);
                }
            }
        }

        // smartfarm
        int nsf = Profile.GetComponent<Profile>().nsmartfarm;

        if (nsf == 0) {
            smartfarm1.SetActive(false); smartfarm2.SetActive(false);
        }
        else if (nsf == 1) {
            smartfarm1.SetActive(true); smartfarm2.SetActive(false);
        }
        else {
            smartfarm1.SetActive(true); smartfarm2.SetActive(true);
        }
    }

    public void GoIn() {
        MinimapUI.SetActive(false);
        IngameUI.SetActive(false);
        UpdateState();
        outsideFurniture.SetActive(false);
        insideFurniture.SetActive(true);

        HomeIn.SetActive(true);
        HomeOut.SetActive(false);

        Camera.main.GetComponent<CameraRotate>().enabled = false;
        Camera.main.transform.position = new Vector3(698.8f, 6.7f, -413.0f);
        Camera.main.transform.rotation = Quaternion.Euler(7.43f, 0f, 0f);
        GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = false;
        GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = true;
        GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(698.8f, 2.3f, -403.0f);

        no_window.SetActive(false);
        no_solar_light.SetActive(false);
        yes_window.SetActive(false);
    }

    public void GoOut() {
        MinimapUI.SetActive(true);
        IngameUI.SetActive(true);
        UpdateState();
        insideFurniture.SetActive(false);
        outsideFurniture.SetActive(true);

        HomeIn.SetActive(false);
        HomeOut.SetActive(true);

        Camera.main.GetComponent<CameraRotate>().enabled = true;
        GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = true;
        GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = false;
        GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(699.7f, 2.3f, -417f);
        GameObject.FindGameObjectWithTag("player").transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    public void TutorialGoOut() {
        UpdateState();
        insideFurniture.SetActive(false);
        outsideFurniture.SetActive(true);

        HomeIn.SetActive(false);
        HomeOut.SetActive(true);
    }
}
