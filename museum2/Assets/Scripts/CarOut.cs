using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarOut : MonoBehaviour
{
    public GameObject Car;
    public GameObject cartext;

    public GameObject Profile;

    int step = 0;

    void Start()
    {
        step = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.G) && step == 1) {
            Car.GetComponent<DriveCar>().step = 0;
            Car.GetComponent<DriveCar>().enabled = false;
            GameObject.FindGameObjectWithTag("player").GetComponent<FirstView>().enabled = true;
            GameObject.FindGameObjectWithTag("player").transform.position = new Vector3(0f, 5f, -95f);
            Camera.main.GetComponent<CameraRotate>().enabled = true;
            step = 0;
            cartext.SetActive(false);

            if (Car.GetComponent<DriveCar>().fillmout > 0.5f) {
                Profile.GetComponent<MissionManager>().MissionFlagOn(6, 4);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.Equals("CarOut") && Car.GetComponent<DriveCar>().step == 1) {
            step = 1;
            cartext.SetActive(true);
        }   
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name.Equals("CarOut") && Car.GetComponent<DriveCar>().step == 1) {
            step = 0;
            cartext.SetActive(false);
        }
    }
}
