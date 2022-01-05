using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energy_minigame_puzzle : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject Building;

    public int step = 0;

    public GameObject info1, info2, info4, info5;
    // public Button finalButton;

    public Button startButton, explainButton;

    public AudioSource startSound, gameSound, endSound;

    public RawImage o1, o2, x1, x2;

    void Start()
    {

    }

    void Update()
    {
        if (step == 1) {
            if (Input.GetKey(KeyCode.Escape)) {
                step0();
            }
        }
    }

    public void StartGame() {
        startSound.Play();
        info1.SetActive(true);
        step0();
        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.transform.position = new Vector3(911.08f, 1.2f, 640f);
        mainCamera.transform.position = new Vector3(911.08f, 1.2f + 4f, 640f - 8f);
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
        info4.SetActive(true);
    }

    public void CheckAns(int slt) {
        
    }

    public void nextstep() {

    }

    public void Result() {
        info4.SetActive(false);
        info5.SetActive(true);
        gameSound.Stop();
        endSound.Play();
    }

    public void OutGame() {
        info5.SetActive(false);
        o1.gameObject.SetActive(false); o2.gameObject.SetActive(false);
        x1.gameObject.SetActive(false); x2.gameObject.SetActive(false); 
        endSound.Stop();
        gameObject.SetActive(false);
    }
}
