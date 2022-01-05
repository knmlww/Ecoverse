using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzle : MonoBehaviour
{
    public GameObject mainCamera;

    public int step = 0;

    public AudioSource pzslt;

    public GameObject info1, info2, info3;
    public GameObject s1, s2, s3;

    public Button startButton, explainButton;

    public AudioSource startSound, gameSound, endSound;

    public GameObject Building;

    int corr1, corr2, corr3;

    public RawImage o1, o2, o3, x1, x2, x3;

    public GameObject h1, h2, h3, h4, h5, h6, h7, h8;
    public GameObject g1, g2, g3, g4, g5, g6, g7, g8, g9, g10, g11, g12, g13, g14, g15, g16, g17;
    public GameObject p1, p2, p3, p4, p5, p6, p7, p8;

    bool hf1 = false, hf2 = false, hf3 = false, hf4 = false, hf5 = false, hf6 = false, hf7 = false, hf8 = false;
    bool gf1 = false, gf2 = false, gf3 = false, gf4 = false, gf5 = false, gf6 = false, gf7 = false, gf8 = false, gf9 = false;
    bool gf10 = false, gf11 = false, gf12 = false, gf13 = false, gf14 = false, gf15 = false, gf16 = false, gf17 = false;
    bool pf1 = false, pf2 = false, pf3 = false, pf4 = false, pf5 = false, pf6 = false, pf7 = false, pf8 = false;

    public GameObject Profile;

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        Debug.Log(h1.transform.position);
        if (step == 1) {
            if (Input.GetKey(KeyCode.Escape)) {
                step0();
            }
        }

        if (step == 3) {
            if (Vector3.Distance(h1.transform.localPosition, new Vector3(224.2f, 224f, 0f)) < 40f) {
                h1.transform.localPosition = new Vector3(224.2f, 224f, 0f);
                hf1 = true;
                // pzslt.Play();
            }
            else {
                hf1 = false;
            }

            if (Vector3.Distance(h2.transform.localPosition, new Vector3(99.433f, 227.17f, 0f)) < 40f) {
                h2.transform.localPosition = new Vector3(99.433f, 227.17f, 0f);
                hf2 = true;
                // pzslt.Play();
            }
            else {
                hf2 = false;
            }

            if (Vector3.Distance(h3.transform.localPosition, new Vector3(-25.5868f, 227.17f, 0f)) < 40f) {
                h3.transform.localPosition = new Vector3(-25.5868f, 227.17f, 0f);
                hf3 = true;
                // pzslt.Play();
            }
            else {
                hf3 = false;
            }

            if (Vector3.Distance(h4.transform.localPosition, new Vector3(-156.378f, 227.17f, 0f)) < 40f) {
                h4.transform.localPosition = new Vector3(-156.378f, 227.17f, 0f);
                hf4 = true;
                // pzslt.Play();
            }
            else {
                hf4 = false;
            }

            if (Vector3.Distance(h5.transform.localPosition, new Vector3(-281.6245f, 227.17f, 0f)) < 40f) {
                h5.transform.localPosition = new Vector3(-281.6245f, 227.17f, 0f);
                hf5 = true;
                // pzslt.Play();
            }
            else {
                hf5 = false;
            }

            if (Vector3.Distance(h6.transform.localPosition, new Vector3(332.0497f, 225.6941f, 0f)) < 40f) {
                h6.transform.localPosition = new Vector3(332.0497f, 225.6941f, 0f);
                hf6 = true;
                // pzslt.Play();
            }
            else {
                hf6 = false;
            }

            if (Vector3.Distance(h7.transform.localPosition, new Vector3(-387.3262f, 224f, 0f)) < 40f) {
                h7.transform.localPosition = new Vector3(-387.3262f, 224f, 0f);
                hf7 = true;
                // pzslt.Play();
            }
            else {
                hf7 = false;
            }

            if (Vector3.Distance(h8.transform.localPosition, new Vector3(-20.8887f, 390.7568f, 0f)) < 40f) {
                h8.transform.localPosition = new Vector3(-20.8887f, 390.7568f, 0f);
                hf8 = true;
                // pzslt.Play();
            }
            else {
                hf8 = false;
            }


            if (hf1 && hf2 && hf3 && hf4 && hf5 && hf6 && hf7 && hf8) {
                correct();
            }
        }
        if (step == 4) {
            if (Vector3.Distance(g1.transform.localPosition, new Vector3(-725.0867f, 96.10657f, 0f)) < 40f) {
                g1.transform.localPosition = new Vector3(-725.0867f, 96.10657f, 0f);
                gf1 = true;
                // pzslt.Play();
            }
            else {
                gf1 = false;
            }

            if (Vector3.Distance(g2.transform.localPosition, new Vector3(-697.8012f, -127.6f, 0f)) < 40f) {
                g2.transform.localPosition = new Vector3(-697.8012f, -127.6f, 0f);
                gf2 = true;
                // pzslt.Play();
            }
            else {
                gf2 = false;
            }

            if (Vector3.Distance(g3.transform.localPosition, new Vector3(-512.45f, -33.82442f, 0f)) < 40f) {
                g3.transform.localPosition = new Vector3(-512.45f, -33.82442f, 0f);
                gf3 = true;
                // pzslt.Play();
            }
            else {
                gf3 = false;
            }

            if (Vector3.Distance(g4.transform.localPosition, new Vector3(-162.6204f, 152.92f, 0f)) < 40f) {
                g4.transform.localPosition = new Vector3(-162.6204f, 152.92f, 0f);
                gf4 = true;
                // pzslt.Play();
            }
            else {
                gf4 = false;
            }

            if (Vector3.Distance(g5.transform.localPosition, new Vector3(-162.62f, 83.4585f, 0f)) < 40f) {
                g5.transform.localPosition = new Vector3(-162.62f, 83.4585f, 0f);
                gf5 = true;
                // pzslt.Play();
            }
            else {
                gf5 = false;
            }

            if (Vector3.Distance(g6.transform.localPosition, new Vector3(-162.62f, -42.83297f, 0f)) < 40f) {
                g6.transform.localPosition = new Vector3(-162.62f, -42.83297f, 0f);
                gf6 = true;
                // pzslt.Play();
            }
            else {
                gf6 = false;
            }

            if (Vector3.Distance(g7.transform.localPosition, new Vector3(-145.87f, -127.61f, 0f)) < 40f) {
                g7.transform.localPosition = new Vector3(-145.87f, -127.61f, 0f);
                gf7 = true;
                // pzslt.Play();
            }
            else {
                gf7 = false;
            }

            if (Vector3.Distance(g8.transform.localPosition, new Vector3(-328.4902f, 63.365f, 0f)) < 40f) {
                g8.transform.localPosition = new Vector3(-328.4902f, 63.365f, 0f);
                gf8 = true;
                // pzslt.Play();
            }
            else {
                gf8 = false;
            }

            if (Vector3.Distance(g9.transform.localPosition, new Vector3(-328.4901f, -30.369f, 0f)) < 40f) {
                g9.transform.localPosition = new Vector3(-328.4901f, -30.369f, 0f);
                gf9 = true;
                // pzslt.Play();
            }
            else {
                gf9 = false;
            }

            if (Vector3.Distance(g10.transform.localPosition, new Vector3(-312.5611f, -127.61f, 0f)) < 40f) {
                g10.transform.localPosition = new Vector3(-312.5611f, -127.61f, 0f);
                gf10 = true;
                // pzslt.Play();
            }
            else {
                gf10 = false;
            }

            if (Vector3.Distance(g11.transform.localPosition, new Vector3(-236.8156f, 332f, 0f)) < 40f) {
                g11.transform.localPosition = new Vector3(-236.8156f, 332f, 0f);
                gf11 = true;
                // pzslt.Play();
            }
            else {
                gf11 = false;
            }

            if (Vector3.Distance(g12.transform.localPosition, new Vector3(-126.5615f, 332f, 0f)) < 40f) {
                g12.transform.localPosition = new Vector3(-126.5615f, 332f, 0f);
                gf12 = true;
                // pzslt.Play();
            }
            else {
                gf12 = false;
            }

            if (Vector3.Distance(g13.transform.localPosition, new Vector3(15.02f, 332f, 0f)) < 40f) {
                g13.transform.localPosition = new Vector3(15.02f, 332f, 0f);
                gf13 = true;
                // pzslt.Play();
            }
            else {
                gf13 = false;
            }

            if (Vector3.Distance(g14.transform.localPosition, new Vector3(-471.6261f, 237.7807f, 0f)) < 40f) {
                g14.transform.localPosition = new Vector3(-471.6261f, 237.7807f, 0f);
                gf14 = true;
                // pzslt.Play();
            }
            else {
                gf14 = false;
            }

            if (Vector3.Distance(g15.transform.localPosition, new Vector3(-540.89f, 300.2019f, 0f)) < 40f) {
                g15.transform.localPosition = new Vector3(-540.89f, 300.2019f, 0f);
                gf15 = true;
                // pzslt.Play();
            }
            else {
                gf15 = false;
            }

            if (Vector3.Distance(g16.transform.localPosition, new Vector3(-426.68f, 328.39f, 0f)) < 40f) {
                g16.transform.localPosition = new Vector3(-426.68f, 328.39f, 0f);
                gf16 = true;
                // pzslt.Play();
            }
            else {
                gf16 = false;
            }

            if (Vector3.Distance(g17.transform.localPosition, new Vector3(-794.34f, 29.42761f, 0f)) < 40f) {
                g17.transform.localPosition = new Vector3(-794.34f, 29.42761f, 0f);
                gf17 = true;
                // pzslt.Play();
            }
            else {
                gf17 = false;
            }

            if (gf1 && gf2 && gf3 && gf4 && gf5 && gf6 && gf7 && gf8 && gf9 && gf10 && gf11 && gf12 && gf13 && gf14 && gf15 && gf16 && gf17) {
                correct();
            }
        }
        if (step == 5) {
            if (Vector3.Distance(p1.transform.localPosition, new Vector3(-462.6041f, 302.78f, 0f)) < 40f) {
                p1.transform.localPosition = new Vector3(-462.6041f, 302.78f, 0f);
                pf1 = true;
                // pzslt.Play();
            }
            else {
                pf1 = false;
            }

            if (Vector3.Distance(p2.transform.localPosition, new Vector3(-197.0049f, 268.35f, 0f)) < 40f) {
                p2.transform.localPosition = new Vector3(-197.0049f, 268.35f, 0f);
                pf2 = true;
                // pzslt.Play();
            }
            else {
                pf2 = false;
            }

            if (Vector3.Distance(p3.transform.localPosition, new Vector3(101.3f, 302.78f, 0f)) < 40f) {
                p3.transform.localPosition = new Vector3(101.3f, 302.78f, 0f);
                pf3 = true;
                // pzslt.Play();
            }
            else {
                pf3 = false;
            }

            if (Vector3.Distance(p4.transform.localPosition, new Vector3(115.2243f, -3.2721f, 0f)) < 40f) {
                p4.transform.localPosition = new Vector3(115.2243f, -3.2721f, 0f);
                pf4 = true;
                // pzslt.Play();
            }
            else {
                pf4 = false;
            }

            if (Vector3.Distance(p5.transform.localPosition, new Vector3(-187.7757f, -39.694f, 0f)) < 40f) {
                p5.transform.localPosition = new Vector3(-187.7757f, -39.694f, 0f);
                pf5 = true;
                // pzslt.Play();
            }
            else {
                pf5 = false;
            }

            if (Vector3.Distance(p6.transform.localPosition, new Vector3(-462.61f, -3.2725f, 0f)) < 40f) {
                p6.transform.localPosition = new Vector3(-462.61f, -3.2725f, 0f);
                pf6 = true;
                // pzslt.Play();
            }
            else {
                pf6 = false;
            }

            if (Vector3.Distance(p7.transform.localPosition, new Vector3(-725.9279f, -39.697f, 0f)) < 40f) {
                p7.transform.localPosition = new Vector3(-725.9279f, -39.697f, 0f);
                pf7 = true;
                // pzslt.Play();
            }
            else {
                pf7 = false;
            }

            if (Vector3.Distance(p8.transform.localPosition, new Vector3(-753.7888f, 278.5129f, 0f)) < 40f) {
                p8.transform.localPosition = new Vector3(-753.7888f, 278.5129f, 0f);
                pf8 = true;
                // pzslt.Play();
            }
            else {
                pf8 = false;
            }

            if (pf1 && pf2 && pf3 && pf4 && pf5 && pf6 && pf7 && pf8) {
                correct();
            }
        }
    }

    public void StartGame() {
        startSound.Play();
        info1.SetActive(true);
        step0();
        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.transform.position = new Vector3(907f, 0f, 565f);
        Building.SetActive(false);
    }

    public void step0() {
        step = 0;
        info1.SetActive(true);
        info2.SetActive(false);
    }

    public void step0_explain() {
        step = 1;
        info1.SetActive(false);
        info2.SetActive(true);
    }

    public void OnGame() {
        startSound.Stop();
        gameSound.Play();
        step = 3;
        info1.SetActive(false);
        s1.SetActive(true);
    }

    public void nextStep() {
        if (step == 3) {
            step++;
            s1.SetActive(false);
            s2.SetActive(true);
            corr1 = 0;
        }

        else if (step == 4) {
            step++;
            s2.SetActive(false);
            s3.SetActive(true);
            corr2 = 0;
        }

        else if (step == 5) {
            step++;
            s3.SetActive(false);
            info3.SetActive(true);
            corr3 = 0;
            Result();
        }
    }

    public void correct() {
        if (step == 3) {
            step++;
            s1.SetActive(false);
            s2.SetActive(true);
            corr1 = 1;
        }

        else if (step == 4) {
            step++;
            s2.SetActive(false);
            s3.SetActive(true);
            corr2 = 1;
        }

        else if (step == 5) {
            step++;
            s3.SetActive(false);
            info3.SetActive(true);
            corr3 = 1;
            Result();
        }

    }

    public void Result() {

        if (corr1 == 1) {
            o1.gameObject.SetActive(true);
            x1.gameObject.SetActive(false);
        }
        else {
            x1.gameObject.SetActive(true);
            o1.gameObject.SetActive(false);
        }

        if (corr2 == 1) {
            o2.gameObject.SetActive(true);
            x2.gameObject.SetActive(false);
        }
        else {
            x2.gameObject.SetActive(true);
            o2.gameObject.SetActive(false);
        }

        if (corr3 == 1) {
            o3.gameObject.SetActive(true);
            x3.gameObject.SetActive(false);
        }
        else {
            x3.gameObject.SetActive(true);
            o3.gameObject.SetActive(false);
        }

        gameSound.Stop();
        endSound.Play();

        if (corr1 == 1 && corr2 == 1 && corr3 == 1) {
            if (Profile.GetComponent<Profile>().badge_subinfo3[2] == '0') {
                Profile.GetComponent<Profile>().badge_subinfo3[2] = '1';
                Profile.GetComponent<Profile>().CheckBadge();
            }
        }
    }

    public void OutGame() {
        Building.SetActive(true);
        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.transform.position = new Vector3(911.08f, 1f, 640f);
        info3.SetActive(false);
        o1.gameObject.SetActive(false); o2.gameObject.SetActive(false); o3.gameObject.SetActive(false);
        x1.gameObject.SetActive(false); x2.gameObject.SetActive(false); x3.gameObject.SetActive(false);
        endSound.Stop();
        mainCamera.transform.position = new Vector3(911.08f, 1f + 4f, 640f - 8f);
        mainCamera.GetComponent<ThirdCamera>().enabled = true;
        gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = true;
    }
}
