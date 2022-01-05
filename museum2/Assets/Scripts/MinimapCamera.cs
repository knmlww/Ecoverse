using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public GameObject target;

    public float offsetX = 0f, offsetY = 120f, offsetZ = 0f;
    float DelayTime = 1f;

    public bool flag;

    void Start() {
        flag = true;
    }

    void Update()
    {
        if (flag) {
            target = GameObject.FindGameObjectWithTag("player");

            if (target) {
                Vector3 FixedPos = new Vector3(
                    target.transform.position.x + offsetX,
                    target.transform.position.y + offsetY,
                    target.transform.position.z + offsetZ
                );

                if (Vector3.Distance(transform.position, FixedPos) > 30f) {
                    transform.position = FixedPos;
                }
                else {
                    transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * DelayTime);
                }
            }
        }
        
    }
}
