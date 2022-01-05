using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ferris_roll : MonoBehaviour
{
    void Start()
    {
       
    }

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0f, 0.3f, 0f));
    }
}
