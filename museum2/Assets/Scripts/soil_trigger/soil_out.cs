using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soil_out : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject mainIsland;
    public GameObject building;

    public GameObject minimap, ingame;

    public GameObject mainLight;

    public GameObject Profile;

    void Start() 
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("player")) {
            Profile.GetComponent<MissionManager>().MissionFlagOn(3, 5);
            mainIsland.SetActive(true);
            minimap.SetActive(true);
            ingame.SetActive(true);
            other.transform.position = new Vector3(20.03f, 4.6f, 6.72f);
            building.SetActive(false);
            mainCamera.GetComponent<ThirdCamera>().enabled = false;
            mainCamera.GetComponent<CameraRotate>().enabled = true;
            GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = false;
            GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = true;
        }
    }
}
