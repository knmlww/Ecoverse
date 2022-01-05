using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class beddington : MonoBehaviour
{
    public GameObject mainCamera;

    public GameObject scene;
    public GameObject exp, Building;

    public GameObject b1, b2, b3, b4, b5, b6, b7, cpos;
    public GameObject outButton;
    public GameObject t1, t2, t3, t4, t5, t6, t7;

    public GameObject popup;
    public Image subback;
    public Text subtitle, subtext;

    public Image infoback;
    public Text infotext;

    public AudioSource backsound;

    public int step = 0;

    void Start()
    {
        step = 0;
    }
    
    void Turn(bool b) {
        t1.SetActive(b);
        t2.SetActive(b);
        t3.SetActive(b);
        t4.SetActive(b);
        t5.SetActive(b);
        t6.SetActive(b);
        t7.SetActive(b);
        infoback.gameObject.SetActive(b);
        outButton.SetActive(b);
    }

    void Update()
    {   
        if (step == 0) {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);

                if (hit.collider != null) {
                    Debug.Log(hit.transform.name);
                }
            }
        }
        
        if (step == 0 && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
            {   
                Debug.Log(hit.collider.name);
                if(hit.collider.name.Equals("s1")) {
                    step = 1;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("�¾籤 ������");
                    subtext.text = StringDecode("������ ������ �¾籤 �� �¾翭�� ���� �������� ������ �������� ��ġ�Ͽ����� Ư��, �޺��� �� ��� �ǹ� ���ʰ� ��ο� ����â�� ��ġ�ߴٰ� �Ѵ�. �¾��� �Ի簢�� ����ؼ� ������ �����ߴٴ� ������ �ٸ� ���๰�鿡 ���� �¾��� Ȱ���Ͽ� �������� ������ �� �ִ�.");
                    // mainCamera.transform.position = b1.transform.position;
                    // mainCamera.transform.rotation = b1.transform.rotation;
                    Turn(false);
                }
                else if (hit.collider.name.Equals("s2")) {
                    step = 2;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("����ȯ�� �ý���");
                    subtext.text = StringDecode("�� ���ô����� ȯ��ý����� �����ѵ�, �� ����� ���� ���⸦ �ٶ��� ���⿡ ���� �����̰� �ϴ� �ü����̶�� �Ѵ�. ���Ϸ��� ��ǳ���� ������ ���ÿ� �Ѵ�. ������ ���๰ ���� �� ���Ⱑ �ǳ��� ���� ����� ���̸鼭 ������������ ����Ǿ��µ�, �ǳ��� 17���� �����Ǵ� ȿ���� ��Ÿ���ٰ� �Ѵ�.");
                    // mainCamera.transform.position = b2.transform.position;
                    // mainCamera.transform.rotation = b2.transform.rotation;
                    Turn(false);
                }
                else if (hit.collider.name.Equals("s3")) {
                    step = 3;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("���� �����");
                    subtext.text = StringDecode("�ٸ� ģȯ�� ���ÿ����� �� �� �ִ� ����Ҵ� ȭ��ǰ� ���۹��� �Ĺ� ��迡 ȿ�������� Ȱ���ǰ� �ִٰ� �Ѵ�. ������ ���忡 �����ϱ� ���� ������ ����� ��ġ������ �����߰� �ǹ����� �� �� �� ���� ���� ����ó�� ��� ������ �����ϱ⿡ ����ȭ�� ������ ���� �ִ�. ");
                    // mainCamera.transform.position = b3.transform.position;
                    // mainCamera.transform.rotation = b3.transform.rotation;
                    Turn(false);
                }
                else if (hit.collider.name.Equals("s4")) {
                    step = 4;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("â���� ������ �¾籤");
                    subtext.text = StringDecode("â���� ��� ���·� ���۵Ǿ� �־�, â������ �¾���� ������ ������ �а� ���ֱ� ���ؼ� ���۵Ǿ��ٰ� �Ѵ�. ������ ���� �ܿ� �¾籤 �������� ������ �� �ִ� ���̵��� ���ٴ� �򰡰� ���ٰ� �Ѵ�.");
                    // mainCamera.transform.position = b4.transform.position;
                    // mainCamera.transform.rotation = b4.transform.rotation;
                    Turn(false);
                }
                else if (hit.collider.name.Equals("s5")) {
                    step = 5;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("����� ���۹�");
                    subtext.text = StringDecode("����Ǫ��� ����� ���۹��� ���� ����ϴ� ������� ��ź�� ������ ��õ�ϰ� �ִ�. ��ۼ������� �߻��ϴ� ź���� ����� ���� ���� �������� ����� ���۹��� ����ؼ� ���� �� �ֹε��� ���� ����ϴ� ��쵵 ���ٰ� �Ѵ�. �ǹ� ���ο� ���۹��� �⸣�⵵ �ϰ� Ŀ�´�Ƽ �������� ����Ѵٰ� �Ѵ�. ��������� �̻�ȭź���� 3����1�� ���̴� ȿ���� ���� �ִ�.");
                    // mainCamera.transform.position = b5.transform.position;
                    // mainCamera.transform.rotation = b5.transform.rotation;
                    Turn(false);
                }
                else if (hit.collider.name.Equals("s6")) {
                    step = 6;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("�����ڵ��� ������");
                    subtext.text = StringDecode("�� ���� ������ �⺻������ �ڵ��� ������ ������ �����ϰ� �ִµ�, ������������ ���� ������ ������ �ڵ��� ������� ����� ȯ������� ���̰� �ִ�. ���� �����ڵ����� ����Ѵٴ� ���� �־ ȯ�� ������ ���̴µ� ȿ���� �ְ� �ִ�. �ֹε� ���� �� ������������ ��û�ؼ� ���������� ȿ���� ���� �ִٰ� �Ѵ�.");
                    // mainCamera.transform.position = b6.transform.position;
                    // mainCamera.transform.rotation = b6.transform.rotation;
                    Turn(false);
                }
                else if (hit.collider.name.Equals("s7")) {
                    step = 7;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("ȭ��� �� �ϼ���");
                    subtext.text = StringDecode("ȭ����� �º��� ���뿡�� ū ��ư�� ���� ��ư�� �ִٰ� �Ѵ�. �Ϲ� ������ ���� ȭ��� �� �Һ� 3���� 1�̶�� �Ѵ�. �� �������� �� �� ����� ���� �����ϱ� ���� ��ü ��ȭ�ü��� ���� ����Ҹ� Ȱ���ϰ� �ִٰ� �Ѵ�. ��ȭ�� ���� ���� ����ҿ� ����Ǿ� �ִٰ� �ٽ� ���� ���� ���ȴٰ� �Ѵ�.");
                    // mainCamera.transform.position = b7.transform.position;
                    // mainCamera.transform.rotation = b7.transform.rotation;
                    Turn(false);
                }
            }
        }

        if (step == 1) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, b1.transform.position, Time.deltaTime * 2f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, b1.transform.rotation, Time.deltaTime * 2f);
        }
        else if (step == 2) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, b2.transform.position, Time.deltaTime * 2f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, b2.transform.rotation, Time.deltaTime * 2f);
        }
        else if (step == 3) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, b3.transform.position, Time.deltaTime * 2f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, b3.transform.rotation, Time.deltaTime * 2f);
        }
        else if (step == 4) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, b4.transform.position, Time.deltaTime * 2f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, b4.transform.rotation, Time.deltaTime * 2f);
        }
        else if (step == 5) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, b5.transform.position, Time.deltaTime * 2f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, b5.transform.rotation, Time.deltaTime * 2f);
        }
        else if (step == 6) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, b6.transform.position, Time.deltaTime * 2f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, b6.transform.rotation, Time.deltaTime * 2f);
        }
        else if (step == 7) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, b7.transform.position, Time.deltaTime * 2f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, b7.transform.rotation, Time.deltaTime * 2f);
        }

        if (step == 0) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cpos.transform.position, Time.deltaTime * 2f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, cpos.transform.rotation, Time.deltaTime * 2f);
        }
    }

    public void StartGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.transform.position = new Vector3(1495f, 1f, 1005f);
        mainCamera.GetComponent<ThirdCamera>().enabled = false;
        mainCamera.transform.position = cpos.transform.position;
        mainCamera.transform.rotation = cpos.transform.rotation;
        scene.SetActive(true);
        backsound.Play();
        infoback.gameObject.SetActive(true);
        infotext.text = StringDecode("ȭ���� ���� �����ϼ���!");
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }

    public void step0() {
        step = 0;
        popup.SetActive(false);
        Turn(true);
        // mainCamera.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        // mainCamera.transform.position = new Vector3(1399.5f, 45.01491f, 1030.458f);
    }

    public void GameOut()
    {
        backsound.Stop();
        exp.SetActive(false);
        scene.SetActive(false);
        Building.SetActive(true);
        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.transform.position = new Vector3(1008.13f, 1f, 640f);
        GameObject.FindGameObjectWithTag("player").GetComponent<keyboard>().enabled = true;
        mainCamera.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        mainCamera.transform.position = new Vector3(1008.13f, 1f + 4f, 640f - 8f);
        mainCamera.GetComponent<ThirdCamera>().enabled = true;
        infoback.gameObject.SetActive(false);
        infotext.text = "";
    }
}
