using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy_out : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject mainIsland;
    public GameObject building;

    public GameObject minimap, ingame;

    public GameObject mainLight;

    void Start() 
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("player")) {
            //mainLight.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            //mainLight.transform.Rotate(new Vector3(-90f, 0f, 0f));

            mainIsland.SetActive(true);
            minimap.SetActive(true);
            ingame.SetActive(true);
            other.transform.position = new Vector3(-19.98f, 4.5f, 6.72f);
            // mainCamera.transform.position = new Vector3(-19.98f, 4.5f + 4f, 6.72f - 8f);
            building.SetActive(false);
            mainCamera.GetComponent<ThirdCamera>().enabled = false;
            mainCamera.GetComponent<CameraRotate>().enabled = true;
            GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = false;
            GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = true;

            
        }
    }
}
