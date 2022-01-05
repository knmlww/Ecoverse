using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class soil_exp1_door : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject exp1, building;

    public GameObject trigger;

    public GameObject Profile;

    public Image subback;
    public Text subtext;

    void Start() 
    {
        
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("player")) {
            Profile.GetComponent<MissionManager>().MissionFlagOn(3, 2);

            exp1.SetActive(true);
            other.transform.position = new Vector3(-305f, 1f, 789f);
            mainCamera.transform.position = new Vector3(-305f, 1f + 4f, 789f - 8f);
            building.SetActive(false);

            subback.gameObject.SetActive(true);
            subtext.text = StringDecode("공장의 매연으로 생긴 산성비로 인해" + "\n" + "주변 나무들과 논들이 피해를 입고 있습니다.");
            Invoke("nextsub", 3f);

            trigger.GetComponent<trigger1a1>().flag = 0;
            trigger.GetComponent<trigger1a1>().textinfo.GetComponent<TextMesh>().text = StringDecode("G키를 눌러 버튼을 누르세요.");
        }
    }

    public void nextsub() {
        subtext.text = StringDecode("이 피해를 줄이기 위해 앞에 보이는 버튼을 눌러주세요.");
        Invoke("nextsub2", 3f);
    }
}
