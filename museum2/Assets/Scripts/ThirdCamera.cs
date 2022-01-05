using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour
{
    public GameObject target;

    public float offsetX = 0f, offsetY = 4f, offsetZ = -8f;
    float DelayTime = 2f;

    void Update()
    {
        gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        if (target) {
            //
        }
        else {
            target = GameObject.FindGameObjectWithTag("player");
        }
        Vector3 FixedPos = new Vector3(
            target.transform.position.x + offsetX,
            target.transform.position.y + offsetY,
            target.transform.position.z + offsetZ
        );
        transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * DelayTime);
    }
}
