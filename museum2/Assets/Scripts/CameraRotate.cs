using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject target;
    public float R = 8f;
    public float speed = 5f;

    void Start() {
        target = GameObject.FindGameObjectWithTag("player");
    }

    void Update() {
        if (Vector3.Distance(target.transform.position, gameObject.transform.position) > 30f) gameObject.transform.position = target.transform.position;
        Vector3 targetpos = target.transform.position;
        Vector3 targetrot = target.transform.rotation.eulerAngles;
        gameObject.transform.rotation = target.transform.rotation;
        // gameObject.transform.position = new Vector3(R * Mathf.Cos(DtoR(-targetrot.y - 90f)) + targetpos.x, targetpos.y + 4f, R * Mathf.Sin(DtoR(-targetrot.y - 90f)) + targetpos.z);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(R * Mathf.Cos(DtoR(-targetrot.y - 90f)) + targetpos.x, targetpos.y + 4f, R * Mathf.Sin(DtoR(-targetrot.y - 90f)) + targetpos.z), Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.V)) {
            if (R == 8f) {
                R = 10f;
            }
            else if (R == 10f) {
                R = 12f;
            }
            else if (R == 12f) {
                R = 8f;
            }
        }
    }

    public static float DtoR(float degree) { 
        return (Mathf.PI / 180.0f) * degree;
    }
}
