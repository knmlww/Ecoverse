using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy_mg_ox_trigger : MonoBehaviour
{
    public GameObject manager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (gameObject.name.Equals("trigger_x")) {
            manager.GetComponent<energy_minigame>().CheckAns(0);
        }   
        else if (gameObject.name.Equals("trigger_o")) {
            manager.GetComponent<energy_minigame>().CheckAns(1);
        } 
    }
}
