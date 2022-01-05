using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccer_out : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name.Equals("ball")) {
            other.transform.position = new Vector3(42.66f, 7.19f, 86.23f);
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
