using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy_door : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject mainIsland;
    public GameObject building;

    public GameObject minimap, ingame;

    public GameObject mainLight;

    public GameObject Profile, MissionManager;

    void Start() 
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("player")) {
            //mainLight.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            // mainLight.transform.Rotate(new Vector3(90f, 0f, 0f));

            if (Profile.GetComponent<Profile>().museum_unlock >= 2) {
                building.SetActive(true);
                minimap.SetActive(false);
                ingame.SetActive(false);
                
                mainIsland.SetActive(false);
                mainCamera.GetComponent<CameraRotate>().enabled = false;
                mainCamera.GetComponent<ThirdCamera>().enabled = true;
                GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = false;
                GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = true;
                other.transform.position = new Vector3(516.17f, 1.5f, 640f);
                mainCamera.transform.position = new Vector3(516.17f, 1.5f + 4f, 640f - 8f);
                mainCamera.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

                MissionManager.GetComponent<MissionManager>().MissionFlagOn(5, 1);
            }
        }
    }
}
