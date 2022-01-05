using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windroll : MonoBehaviour
{
    public GameObject light;
    bool flag;
    void Start()
    {
        flag = false;
        InvokeRepeating("flip", 3f, 3f);
    }

    void Update()
    {
        if (!flag) {
            gameObject.transform.Rotate(new Vector3(0f, 0f, -10f));
        }
    }

    void flip() {
        light.SetActive(flag);
        flag = !flag;
    }
}
