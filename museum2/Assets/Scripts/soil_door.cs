using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soil_door : MonoBehaviour
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
            //mainLight.transform.Rotate(new Vector3(90f, 0f, 0f));

            if (Profile.GetComponent<Profile>().museum_unlock >= 1) {
                building.SetActive(true);
                minimap.SetActive(false);
                ingame.SetActive(false);
                GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(-191.31f, 1f, 640f);
                mainCamera.transform.position = new Vector3(-191.31f, 1f + 4f, 640f - 8f);
                mainCamera.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                mainIsland.SetActive(false);
                mainCamera.GetComponent<CameraRotate>().enabled = false;
                mainCamera.GetComponent<ThirdCamera>().enabled = true;
                GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = false;
                GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = true;

                MissionManager.GetComponent<MissionManager>().MissionFlagOn(3, 1);
            }
        }
    }
}
