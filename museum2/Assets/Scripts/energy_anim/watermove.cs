using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watermove : MonoBehaviour
{
    public GameObject lefta, righta;
    public GameObject w1, w2;
    bool flag;

    void Start()
    {
        flag = false;
        InvokeRepeating("flip", 3f, 3f);
    }

    void Update()
    {
        if (flag) {
            gameObject.transform.Translate(new Vector3(0f, 0.01f, 0f));
            w1.gameObject.transform.Rotate(new Vector3(0f, 0f, -10f));       
            w2.gameObject.transform.Rotate(new Vector3(0f, 0f, -10f));   
        }
        else {
            gameObject.transform.Translate(new Vector3(0f, -0.01f, 0f));
            w1.gameObject.transform.Rotate(new Vector3(0f, 0f, 10f));       
            w2.gameObject.transform.Rotate(new Vector3(0f, 0f, 10f));   
        }

    }

    void flip() {
        flag = !flag;

        if (!flag) {
            righta.SetActive(false);
            lefta.SetActive(true);
        }
        else {
            lefta.SetActive(false);
            righta.SetActive(true);
        }
    }
}
