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
                    subtitle.text = StringDecode("태양광 전지판");
                    subtext.text = StringDecode("주택의 지붕은 태양광 및 태양열을 통한 에너지를 만들어내는 집열판을 설치하였으며 특히, 햇볕이 잘 드는 건물 남쪽과 상부에 유리창을 설치했다고 한다. 태양의 입사각을 고려해서 지붕을 설계했다는 점으로 다른 건축물들에 비해 태양을 활용하여 에너지를 공급할 수 있다.");
                    // mainCamera.transform.position = b1.transform.position;
                    // mainCamera.transform.rotation = b1.transform.rotation;
                    Turn(false);
                }
                else if (hit.collider.name.Equals("s2")) {
                    step = 2;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("수동환기 시스템");
                    subtext.text = StringDecode("이 주택단지는 환기시스템이 유명한데, 찬 공기와 더운 공기를 바람의 방향에 따라 움직이게 하는 시설물이라고 한다. 보일러와 통풍기의 역할을 동시에 한다. 실제로 건축물 밖의 찬 공기가 실내의 더운 공기와 섞이면서 따뜻해지도록 설계되었는데, 실내가 17도로 유지되는 효과가 나타난다고 한다.");
                    // mainCamera.transform.position = b2.transform.position;
                    // mainCamera.transform.rotation = b2.transform.rotation;
                    Turn(false);
                }
                else if (hit.collider.name.Equals("s3")) {
                    step = 3;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("빗물 저장소");
                    subtext.text = StringDecode("다른 친환경 주택에서도 볼 수 있는 저장소는 화장실과 농작물과 식물 재배에 효율적으로 활동되고 있다고 한다. 빗물의 저장에 용이하기 위해 옥상의 모양을 아치형으로 설계했고 건물마다 한 층 더 낮은 층도 옥상처럼 지어서 빗물을 저장하기에 최적화된 구조를 갖고 있다. ");
                    // mainCamera.transform.position = b3.transform.position;
                    // mainCamera.transform.rotation = b3.transform.rotation;
                    Turn(false);
                }
                else if (hit.collider.name.Equals("s4")) {
                    step = 4;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("창문에 부착된 태양광");
                    subtext.text = StringDecode("창문은 어닝 형태로 제작되어 있어, 창문으로 태양빛이 내리는 면적을 넓게 해주기 위해서 제작되었다고 한다. 실제로 옥상 외에 태양광 전지판을 부착할 수 있는 아이디어로 좋다는 평가가 많다고 한다.");
                    // mainCamera.transform.position = b4.transform.position;
                    // mainCamera.transform.rotation = b4.transform.rotation;
                    Turn(false);
                }
                else if (hit.collider.name.Equals("s5")) {
                    step = 5;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("유기농 농작물");
                    subtext.text = StringDecode("로컬푸드와 유기농 농작물을 직접 재배하는 방식으로 저탄소 유지를 실천하고 있다. 운송수단으로 발생하는 탄소의 감축과 삶의 여건 내에서도 유기농 농작물을 재배해서 단지 내 주민들이 서로 재배하는 경우도 많다고 한다. 건물 내부에 농작물을 기르기도 하고 커뮤니티 정원에서 재배한다고도 한다. 결과적으로 이산화탄소의 3분의1을 줄이는 효과를 보고 있다.");
                    // mainCamera.transform.position = b5.transform.position;
                    // mainCamera.transform.rotation = b5.transform.rotation;
                    Turn(false);
                }
                else if (hit.collider.name.Equals("s6")) {
                    step = 6;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("전기자동차 보관소");
                    subtext.text = StringDecode("이 주택 단지는 기본적으로 자동차 소유와 운행을 제한하고 있는데, 공동차량제를 통해 주차장 면적과 자동차 사용으로 생기는 환경오염을 줄이고 있다. 또한 전기자동차를 사용한다는 점에 있어서 환경 오염을 줄이는데 효과를 주고 있다. 주민들 또한 이 공동차량제를 신청해서 경제적으로 효과를 보고 있다고 한다.");
                    // mainCamera.transform.position = b6.transform.position;
                    // mainCamera.transform.rotation = b6.transform.rotation;
                    Turn(false);
                }
                else if (hit.collider.name.Equals("s7")) {
                    step = 7;
                    popup.SetActive(true);
                    subtitle.text = StringDecode("화장실 및 하수도");
                    subtext.text = StringDecode("화장실의 좌변기 물통에는 큰 버튼과 작은 버튼이 있다고 한다. 일반 가정에 비해 화장실 물 소비가 3분의 1이라고 한다. 각 가정에는 한 번 사용한 물을 재사용하기 위해 자체 정화시설과 빗물 저장소를 활용하고 있다고 한다. 정화된 물은 빗물 저장소에 저장되어 있다가 다시 변기 물로 사용된다고 한다.");
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
        infotext.text = StringDecode("화면을 눌러 관람하세요!");
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
