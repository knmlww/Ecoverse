using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traffic_light : MonoBehaviour
{
    public Material red_on, red_off, yellow_on, yellow_off, green_on, green_off;

    public GameObject l_p1_red, l_p1_yellow, l_p1_green, l_p2_red, l_p2_yellow, l_p2_green, l_c_red, l_c_yellow, l_c_green;
    public GameObject r_p1_red, r_p1_yellow, r_p1_green, r_p2_red, r_p2_yellow, r_p2_green, r_c_red, r_c_yellow, r_c_green;

    void Start()
    {
        Invoke("red", 0f);
    }

    void Update()
    {
        
    }

    void red() {
        l_p1_red.GetComponent<Renderer>().material = red_on;
        l_p1_yellow.GetComponent<Renderer>().material = yellow_off;
        l_p1_green.GetComponent<Renderer>().material = green_off;
        l_p2_red.GetComponent<Renderer>().material = red_on;
        l_p2_yellow.GetComponent<Renderer>().material = yellow_off;
        l_p2_green.GetComponent<Renderer>().material = green_off;
        l_c_red.GetComponent<Renderer>().material = red_off;
        l_c_yellow.GetComponent<Renderer>().material = yellow_off;
        l_c_green.GetComponent<Renderer>().material = green_on;

        r_p1_red.GetComponent<Renderer>().material = red_on;
        r_p1_yellow.GetComponent<Renderer>().material = yellow_off;
        r_p1_green.GetComponent<Renderer>().material = green_off;
        r_p2_red.GetComponent<Renderer>().material = red_on;
        r_p2_yellow.GetComponent<Renderer>().material = yellow_off;
        r_p2_green.GetComponent<Renderer>().material = green_off;
        r_c_red.GetComponent<Renderer>().material = red_off;
        r_c_yellow.GetComponent<Renderer>().material = yellow_off;
        r_c_green.GetComponent<Renderer>().material = green_on;

        Invoke("yellow_red", 10f);
    }

    void green() {
        l_p1_red.GetComponent<Renderer>().material = red_off;
        l_p1_yellow.GetComponent<Renderer>().material = yellow_off;
        l_p1_green.GetComponent<Renderer>().material = green_on;
        l_p2_red.GetComponent<Renderer>().material = red_off;
        l_p2_yellow.GetComponent<Renderer>().material = yellow_off;
        l_p2_green.GetComponent<Renderer>().material = green_on;
        l_c_red.GetComponent<Renderer>().material = red_on;
        l_c_yellow.GetComponent<Renderer>().material = yellow_off;
        l_c_green.GetComponent<Renderer>().material = green_off;

        r_p1_red.GetComponent<Renderer>().material = red_off;
        r_p1_yellow.GetComponent<Renderer>().material = yellow_off;
        r_p1_green.GetComponent<Renderer>().material = green_on;
        r_p2_red.GetComponent<Renderer>().material = red_off;
        r_p2_yellow.GetComponent<Renderer>().material = yellow_off;
        r_p2_green.GetComponent<Renderer>().material = green_on;
        r_c_red.GetComponent<Renderer>().material = red_on;
        r_c_yellow.GetComponent<Renderer>().material = yellow_off;
        r_c_green.GetComponent<Renderer>().material = green_off;

        Invoke("yellow_green", 5f);
    }

    void yellow_red() {
        l_p1_red.GetComponent<Renderer>().material = red_off;
        l_p1_yellow.GetComponent<Renderer>().material = yellow_on;
        l_p1_green.GetComponent<Renderer>().material = green_off;
        l_p2_red.GetComponent<Renderer>().material = red_off;
        l_p2_yellow.GetComponent<Renderer>().material = yellow_on;
        l_p2_green.GetComponent<Renderer>().material = green_off;
        l_c_red.GetComponent<Renderer>().material = red_off;
        l_c_yellow.GetComponent<Renderer>().material = yellow_on;
        l_c_green.GetComponent<Renderer>().material = green_off;

        r_p1_red.GetComponent<Renderer>().material = red_off;
        r_p1_yellow.GetComponent<Renderer>().material = yellow_on;
        r_p1_green.GetComponent<Renderer>().material = green_off;
        r_p2_red.GetComponent<Renderer>().material = red_off;
        r_p2_yellow.GetComponent<Renderer>().material = yellow_on;
        r_p2_green.GetComponent<Renderer>().material = green_off;
        r_c_red.GetComponent<Renderer>().material = red_off;
        r_c_yellow.GetComponent<Renderer>().material = yellow_on;
        r_c_green.GetComponent<Renderer>().material = green_off;

        Invoke("green", 1f);
    }

    void yellow_green() {
        l_p1_red.GetComponent<Renderer>().material = red_off;
        l_p1_yellow.GetComponent<Renderer>().material = yellow_on;
        l_p1_green.GetComponent<Renderer>().material = green_off;
        l_p2_red.GetComponent<Renderer>().material = red_off;
        l_p2_yellow.GetComponent<Renderer>().material = yellow_on;
        l_p2_green.GetComponent<Renderer>().material = green_off;
        l_c_red.GetComponent<Renderer>().material = red_off;
        l_c_yellow.GetComponent<Renderer>().material = yellow_on;
        l_c_green.GetComponent<Renderer>().material = green_off;

        r_p1_red.GetComponent<Renderer>().material = red_off;
        r_p1_yellow.GetComponent<Renderer>().material = yellow_on;
        r_p1_green.GetComponent<Renderer>().material = green_off;
        r_p2_red.GetComponent<Renderer>().material = red_off;
        r_p2_yellow.GetComponent<Renderer>().material = yellow_on;
        r_p2_green.GetComponent<Renderer>().material = green_off;
        r_c_red.GetComponent<Renderer>().material = red_off;
        r_c_yellow.GetComponent<Renderer>().material = yellow_on;
        r_c_green.GetComponent<Renderer>().material = green_off;

        Invoke("red", 1f);
    }
}
