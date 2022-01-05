using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalHomeTrigger : MonoBehaviour
{
    public int step;

    public int triggerstep = 0;

    public GameObject inText, outText;

    public GameObject FurnitureManager;

    void Start()
    {
        step = -1; // out
    }

    void Update()
    {
        // out to in
        if (step == -1 && triggerstep == 1) {
            if (Input.GetKey(KeyCode.G)) {
                FurnitureManager.GetComponent<Furniture>().GoIn();
                triggerstep = 0;
                flip();
                outText.SetActive(false);
                inText.SetActive(false);
            }
        }
        // in to out
        else if (step == 1 && triggerstep == 1) {
            if (Input.GetKey(KeyCode.G)) {
                triggerstep = 0;
                FurnitureManager.GetComponent<Furniture>().GoOut();
                flip();
                outText.SetActive(false);
                inText.SetActive(false);
            }
        }
    }

    void flip() {
        if (step == -1) {
            Invoke("MinusToOne", 0.5f);
            step = 0;
        }
        else if (step == 1) {
            Invoke("oneToMinus", 0.5f);
            step = 0;
        }
    }

    public void oneToMinus() {
        step = -1;
    }

    public void MinusToOne() {
        step = 1;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("player")) {
            // in to out
            if (step == 1) {
                outText.SetActive(true);
                triggerstep = 1;
            }

            // out to in
            else if (step == -1) {
                inText.SetActive(true);
                triggerstep = 1;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        inText.SetActive(false);
        outText.SetActive(false);
        triggerstep = 0;
    }
}
