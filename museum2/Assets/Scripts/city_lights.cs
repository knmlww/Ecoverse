using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class city_lights : MonoBehaviour
{
    public List<GameObject> buildingLights = new List<GameObject>();

    void Start()
    {
        Invoke("turnoff", 3f);
    }
    void Update()
    {
        
    }

    public void turnon() {
        for (int i = 0; i < buildingLights.Count; i++) {
            buildingLights[i].SetActive(true);
            Invoke("turnoff", 3f);
        }
    }

    public void turnoff() {
        for (int i = 0; i < buildingLights.Count; i++) {
            buildingLights[i].SetActive(false);
            Invoke("turnon", 3f);
        }
    }
}
