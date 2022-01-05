using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] garos = GameObject.FindGameObjectsWithTag("garo");

        for (int i = 0; i < garos.Length; i++) {
            garos[i].transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
