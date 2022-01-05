using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public GameObject pausemenu;
    public int isPause;
    void Start()
    {
        isPause = 1;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            if (isPause == 1) {
                isPause = 0;
                Invoke("flip1", 0.2f);
            }
            else if (isPause == -1) {
                isPause = 0;
                Invoke("flip2", 0.2f);
            }
        }
    }

    void flip1() {
        isPause = -1;
    }

    void flip2() {
        isPause = 1;
    }

    public void BadgeButtonPressed() {

    }

    public void CharacterButtonPressed() {

    }

    public void LogoutButtonPressed() {

    }

    public void ExitButtonPressed() {

    }
}
