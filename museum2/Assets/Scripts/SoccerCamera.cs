using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerCamera : MonoBehaviour
{
    public GameObject target;

    float DelayTime = 1f;

    void Update()
    {
        if (target) {

        }
        else {
            target = GameObject.FindGameObjectWithTag("player");
        }
        Vector3 FixedPos = new Vector3(target.transform.position.x, 17.17f, 59.03f);
        transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * DelayTime);
    }
}
