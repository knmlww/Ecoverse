using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soil_minigame_door : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject exp, building;

    public GameObject MissionManager;

    void Start() 
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("player")) {
            MissionManager.GetComponent<MissionManager>().MissionFlagOn(3, 3);
            exp.SetActive(true);
            exp.GetComponent<soil_minigame>().StartGame();
            building.SetActive(false);
        }
    }
}
