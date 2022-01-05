using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundheat : MonoBehaviour
{
    bool flag;
    public GameObject winter, summer;

    void Start()
    {
        flag = false;   
        InvokeRepeating("flip", 3f, 3f); 
    }

    void Update()
    {
        
    }

    void flip() {
        flag = !flag;
        if (flag) { 
            summer.SetActive(false);
            winter.SetActive(true);
        }   
        else { 
            winter.SetActive(false);
            summer.SetActive(true);
        }  
    }
}
