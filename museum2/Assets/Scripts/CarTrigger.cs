using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarTrigger : MonoBehaviour
{
    public GameObject Car1, Car2, Car3;

    public GameObject CarUI;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        // Charge Station Trigger
        if (gameObject.name.Equals("Charge_Elec")) {
            if (other.CompareTag("car") && other.gameObject.name.Equals("car1")) {
                Car1.GetComponent<DriveCar>().StartCharge(1);
            }
            else if (other.CompareTag("car") && other.gameObject.name.Equals("car2")) {
                Car2.GetComponent<DriveCar>().StartCharge(1);
            }
            else if (other.CompareTag("car") && other.gameObject.name.Equals("car3")) {
                Car3.GetComponent<DriveCar>().StartCharge(1);
            }
        }
        else if (gameObject.name.Equals("Charge_Hidro")) {
            if (other.CompareTag("car") && other.gameObject.name.Equals("car1")) {
                Car1.GetComponent<DriveCar>().StartCharge(0);
            }
            else if (other.CompareTag("car") && other.gameObject.name.Equals("car2")) {
                Car2.GetComponent<DriveCar>().StartCharge(0);
            }
            else if (other.CompareTag("car") && other.gameObject.name.Equals("car3")) {
                Car3.GetComponent<DriveCar>().StartCharge(0);
            }
        }
    }
}
