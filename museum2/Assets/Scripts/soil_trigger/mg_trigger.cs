using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mg_trigger : MonoBehaviour
{
    public GameObject manager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (gameObject.name.Equals("trigger1")) {
            manager.GetComponent<soil_minigame>().CheckAns(1);
        }   

        else if (gameObject.name.Equals("trigger2")) {
            manager.GetComponent<soil_minigame>().CheckAns(2);
        } 

        else if (gameObject.name.Equals("trigger3")) {  
            manager.GetComponent<soil_minigame>().CheckAns(3);
        }
    }
}
