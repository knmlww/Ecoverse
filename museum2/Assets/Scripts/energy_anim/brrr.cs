using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brrr : MonoBehaviour
{
    public GameObject con;

    void Start()
    {
        InvokeRepeating("conn", 1f, 1f);
    }

    void conn() {
        con.transform.position = new Vector3(677.54f, 7.708f, 649.933f);
    }
}
