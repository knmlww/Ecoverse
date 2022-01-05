using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class trigger1a1 : MonoBehaviour
{
    public GameObject textinfo;
    public GameObject exp1;
    AudioSource audioSource;

    public Image back;
    public Text subtitle;
    
    public GameObject maincamera;

    public GameObject building;

    public int flag;

    void Start()
    {
        flag = 0;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }

    void drawtitle() {
        back.gameObject.SetActive(true);
        subtitle.text = StringDecode("F키를 눌러 체험관을 나갈 수 있습니다.");
        flag = 2;
    }

    void Update()
    {
        if (flag == 1) {
            if (Input.GetKey(KeyCode.G)) {
                audioSource.Play();
                exp1.GetComponent<soil_exp>().ChangeEnv();
                textinfo.GetComponent<TextMesh>().text = "";
                subtitle.text = StringDecode("매연 저감장치가 작동해 산성비가 그쳤습니다!");
                Invoke("drawtitle", 5f);
            }
        }

        else if (flag == 2) {
            if (Input.GetKey(KeyCode.F)) {
                exp1.GetComponent<soil_exp>().exit();
                GameObject player = GameObject.FindGameObjectWithTag("player");
                player.transform.position = new Vector3(-127.3f, 1f, 640f);
                maincamera.transform.position = new Vector3(-127f, 1f + 4f, 629f - 8f);
                back.gameObject.SetActive(false);
                subtitle.text = "";
                exp1.SetActive(false);
                building.SetActive(true);
                flag = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("player") && flag == 0) {
            textinfo.SetActive(true);
            flag = 1;
        }  
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag.Equals("player") && flag == 1) {
            textinfo.SetActive(false);
            flag = 0;
        }  
    }
}
