using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnterOut : MonoBehaviour
{
    public GameObject Car;
    public GameObject infoText;

    public int step;


    void Start()
    {
        step = 0;
    }

    void Update()
    {
        if (step == 1 && Input.GetKey(KeyCode.G)) {
            SendRide();
        }
    }

    public void SendRide() {
        Car.GetComponent<DriveCar>().enabled = true;
        Car.GetComponent<DriveCar>().step = 1;
        Car.GetComponent<DriveCar>().Drive();
        GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = false;
        GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(0f, -15f, -105f);
        Camera.main.GetComponent<CameraRotate>().enabled = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("player")) {
            step = 1;
            infoText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("player")) {
            step = 0;
            infoText.SetActive(false);
        }
    }
}
