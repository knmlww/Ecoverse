using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy_mg_doors : MonoBehaviour
{
    public GameObject mgox, mgpz, mgbk, exp;
    public GameObject building;

    public GameObject Profile;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("player")) {
            if (gameObject.name.Equals("door_mg_ox")) {
                mgox.SetActive(true);
                mgox.GetComponent<energy_minigame>().StartGame();
                building.SetActive(false);
                Camera.main.GetComponent<ThirdCamera>().enabled = false;
                Profile.GetComponent<MissionManager>().MissionFlagOn(5, 3);
            }

            else if (gameObject.name.Equals("door_mg_pz")) {
                mgpz.SetActive(true);
                mgpz.GetComponent<puzzle>().StartGame();
                Camera.main.GetComponent<ThirdCamera>().enabled = false;
                GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = false;
                Profile.GetComponent<MissionManager>().MissionFlagOn(5, 4);
            }

            else if (gameObject.name.Equals("door_mg_bk")) {
                mgbk.SetActive(true);
                mgbk.GetComponent<energy_minigame_bucket>().StartGame();
                Camera.main.GetComponent<ThirdCamera>().enabled = false;
                GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = false;
                Profile.GetComponent<MissionManager>().MissionFlagOn(5, 2);
            }

            else if (gameObject.name.Equals("door_exp")) {
                exp.SetActive(true);
                exp.GetComponent<beddington>().StartGame();
                building.SetActive(false);
                Camera.main.GetComponent<ThirdCamera>().enabled = false;
                GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = false;
                Profile.GetComponent<MissionManager>().MissionFlagOn(5, 5);
            }   
        }    
    }
}
