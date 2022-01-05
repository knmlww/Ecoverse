using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccer_door : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject islandSound, soccerSound;

    public GameObject kickSound, goalSound;

    void Start() 
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("player")) {
            if (gameObject.name.Equals("in")) {
                kickSound.SetActive(true);
                goalSound.SetActive(true);
                islandSound.SetActive(false);
                soccerSound.SetActive(true);
                other.transform.position = new Vector3(42.54f, 4.5f, 74.01f);
                mainCamera.GetComponent<CameraRotate>().enabled = false;
                mainCamera.GetComponent<SoccerCamera>().enabled = true;
                mainCamera.transform.position = new Vector3(42.98f, 17.16f, 59.03f);
                mainCamera.transform.rotation = Quaternion.Euler(30f, 0f, 0f);
                GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = true;
                GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = false;
            }
            else if (gameObject.name.Equals("out")) {
                kickSound.SetActive(false);
                goalSound.SetActive(false);
                soccerSound.SetActive(false);
                islandSound.SetActive(true);
                other.transform.position = new Vector3(39.84f, 4.5f, 33.10f);
                mainCamera.GetComponent<SoccerCamera>().enabled = false;
                mainCamera.GetComponent<CameraRotate>().enabled = true;
                mainCamera.transform.position = new Vector3(39.84f, 4.5f + 4f, 33.10f - 8f);
                mainCamera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = false;
                GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = true;
            }
        }
    }
}
