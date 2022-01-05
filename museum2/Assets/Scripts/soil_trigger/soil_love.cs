using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class soil_love : MonoBehaviour
{
    public GameObject building;

    public int step;

    public GameObject sc1;
    public Button nextButton;

    public GameObject step1, step2, step3, step4, step5, step6;
    // 600, 850, 1100
    public Vector3 step1pos = new Vector3(300f, 10f, 630f), step2pos = new Vector3(300f, 10f, 880f), step3pos = new Vector3(300f, 10f, 1130f);
    // 1350, 1600, 1850
    public Vector3 step4pos = new Vector3(300f, 10f, 1380f), step5pos = new Vector3(300f, 10f, 1630f), step6pos = new Vector3(300f, 10f, 1880f);

    public Vector3 cstep1pos = new Vector3(300f, 10f + 4f, 630f - 8f), cstep2pos = new Vector3(300f, 10f + 4f, 880f - 8f), cstep3pos = new Vector3(300f, 10f + 4f, 1130f - 8f);
    public Vector3 cstep4pos = new Vector3(300f, 10f + 4f, 1380f - 8f), cstep5pos = new Vector3(300f, 10f + 4f, 1630f - 8f), cstep6pos = new Vector3(300f, 10f + 4f, 1880f - 8f);

    public GameObject s1t1, s1t2, s1t3, s1t4, s1t5, s1t6, s1t7, s1t8, s1t9;

    public Image subback;
    public Text subtitle, buttonText;

    public string subt1;
    public string subt2;
    public string subt3;
    public string subt4;
    public string subt5;

    public AudioSource windsound, trashsound, constsound, watersound;

    public GameObject player, maincamera;

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }

    void Start()
    {
        subt1 = StringDecode("�ش� ������ ����Ŀ�� ����� �ִϸ��̼�ȭ �߽��ϴ�." + "\n" + "��� �ΰ�������� ��������� �������� ������ ���� �����̾����ϴ�.");
        subt2 = StringDecode("���Ŀ� ��������� ���� ��Ȳ�� ���� �޲ٰ�" + "\n" + "������� ����� �������� �Ǿ����ϴ�.");
        subt3 = StringDecode("�ð��� �귯 �ÿ����� �Ÿ��� ���� �б��� �����Ͽ����ϴ�." + "\n" + "������ �б� ���� �������� ���� ���� �ö���� �����߽��ϴ�.");
        subt4 = StringDecode("���ϼ��� ��⹰���� �������� ������ �Ǿ�" + "\n" + "�ֹε鿡�� ū �ǿ����� ��ġ�� �־����ϴ�.");
        subt5 = StringDecode("�б��� ���ǰ� �α� �ֹε��� ������ ������ �Ǿ����ϴ�.");
    }

    void Update()
    {
        
    }

    public void StartStep() {
        step = 0;
        player = GameObject.FindGameObjectWithTag("player");
        sc1.SetActive(true);
        subback.gameObject.SetActive(true);
        subtitle.text = StringDecode("�ش� ������ ������ ����� �ִϸ��̼�ȭ �߽��ϴ�." + "\n" + "��� �ΰ�������� ��������� �������� ������ ���� �����̾����ϴ�.");
        buttonText.text = StringDecode("����");
        windsound.Play();
        trashsound.Play();

        // trash
        s1t1.GetComponent<generate_trash>().GenerateTrash(); s1t2.GetComponent<generate_trash>().GenerateTrash(); s1t3.GetComponent<generate_trash>().GenerateTrash();
        s1t4.GetComponent<generate_trash>().GenerateTrash(); s1t5.GetComponent<generate_trash>().GenerateTrash(); s1t6.GetComponent<generate_trash>().GenerateTrash();
        s1t7.GetComponent<generate_trash>().GenerateTrash(); s1t8.GetComponent<generate_trash>().GenerateTrash(); s1t9.GetComponent<generate_trash>().GenerateTrash();
    }

    public void NextStep() {
        step++;

        if (step == 1) {
            trashsound.Stop();
            step1.SetActive(false);
            player.transform.position = step2pos;
            maincamera.transform.position = cstep2pos;
            step2.SetActive(true);
            s1t1.GetComponent<generate_trash>().deleteTrash(); s1t2.GetComponent<generate_trash>().deleteTrash(); s1t3.GetComponent<generate_trash>().deleteTrash();
            s1t4.GetComponent<generate_trash>().deleteTrash(); s1t5.GetComponent<generate_trash>().deleteTrash(); s1t6.GetComponent<generate_trash>().deleteTrash();
            s1t7.GetComponent<generate_trash>().deleteTrash(); s1t8.GetComponent<generate_trash>().deleteTrash(); s1t9.GetComponent<generate_trash>().deleteTrash();
        }

        else if (step == 2) {
            step2.SetActive(false);
            player.transform.position = step3pos;
            maincamera.transform.position = cstep3pos;
            subtitle.text = StringDecode("���Ŀ� ��������� ���� ��Ȳ�� ���� �޲ٰ�" + "\n" + "������� ����� �������� �Ǿ����ϴ�.");
            step3.SetActive(true);
        }

        else if (step == 3) {
            step3.SetActive(false);
            player.transform.position = step4pos;
            maincamera.transform.position = cstep4pos;
            subtitle.text = StringDecode("�ð��� �귯 �ÿ����� �Ÿ��� ���� �б��� �����Ͽ����ϴ�." + "\n" + "������ �б� ���� �������� ���� ���� �ö���� �����߽��ϴ�.");
            step4.SetActive(true);
        }

        else if (step == 4) {   
            watersound.Play();
            step4.SetActive(false);
            player.transform.position = step5pos;
            maincamera.transform.position = cstep5pos;
            subtitle.text = StringDecode("���ϼ��� ��⹰���� �������� ������ �Ǿ�" + "\n" + "�ֹε鿡�� ū �ǿ����� ��ġ�� �־����ϴ�.");
            step5.SetActive(true);
        }

        else if (step == 5) {
            watersound.Stop();
            step5.SetActive(false);
            player.transform.position = step6pos;
            maincamera.transform.position = cstep6pos;
            subtitle.text = StringDecode("�б��� ���ǰ� �α� �ֹε��� ������ ������ �Ǿ����ϴ�.");
            step6.SetActive(true);
            buttonText.text = StringDecode("ü�� ����");
        }

        else if (step == 6) {
            windsound.Stop();
            building.SetActive(true);
            player.transform.position = new Vector3(29.5f, 1f, 640f);
            maincamera.transform.position = new Vector3(29.5f, 1f + 4f, 640f - 8f);
            step6.SetActive(false);
            subtitle.text = "";
            subback.gameObject.SetActive(false);
            sc1.SetActive(false);
            gameObject.SetActive(false);
        }
    }


}
