using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windroll1 : MonoBehaviour
{
    void Start()
    {
        float r = Random.Range(0f, 360f);
        gameObject.transform.Rotate(new Vector3(0f, r, 0f));
    }

    void Update()
    {
        float r = Random.Range(1f, 2f);
        gameObject.transform.Rotate(new Vector3(0f, r, 0f));
    }
}
