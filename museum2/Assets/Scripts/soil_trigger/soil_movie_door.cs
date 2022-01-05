using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soil_movie_door : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject building, exp2, step1;

    public GameObject Profile;

    void Start() 
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("player")) {
            Profile.GetComponent<MissionManager>().MissionFlagOn(3, 4);
            exp2.SetActive(true);
            step1.SetActive(true);
            other.transform.position = new Vector3(300f, 10f, 630f);
            mainCamera.transform.position = new Vector3(300f, 10f + 4f, 630f - 8f);
            building.SetActive(false);
            exp2.GetComponent<soil_love>().StartStep();
        }
    }
}
