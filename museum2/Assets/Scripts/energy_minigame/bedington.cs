using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedington : MonoBehaviour
{
    public GameObject mainCamera;

    Vector3 camerapos = new Vector3(1393.876f, 32.44197f, 1042.802f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void exp() {
        mainCamera.transform.position = camerapos;
    }
}
