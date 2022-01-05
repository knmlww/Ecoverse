using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class DriveCar : MonoBehaviour
{
    public float carspeed = 60000f;
    // Start is called before the first frame update
    public int R = 15;

    public int step = 0;

    /* Charge UI */
    public GameObject ChargeUI;

    public GameObject Hidro, Elec;
    public Image hidrofull, elecfull;
    public Text ChargeText;

    /* Ingame UI */
    public GameObject minimapUI, IngameUI;

    int animStep = 0;
    public float fillmout = 0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (step == 1) {
            Drive();
        }
    }

    public string StringDecode(string originstr) {
        byte [] bytesForEncoding = Encoding.UTF8.GetBytes (originstr);
        string encodedString = Convert.ToBase64String (bytesForEncoding );
        byte[] decodedBytes = Convert.FromBase64String (encodedString );
        return Encoding.UTF8.GetString (decodedBytes);
    }

    public void Drive() {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(0f, moveVertical, 0f);

        transform.GetComponent<Rigidbody>().AddRelativeForce(movement * carspeed);
        if (transform.GetComponent<Rigidbody>().velocity != Vector3.zero) {
            if (moveVertical >= 0f) {
                transform.Rotate(new Vector3(0f, 0f, moveHorizontal * -5f));
            }
            else {
                transform.Rotate(new Vector3(0f, 0f, moveHorizontal * 5f));
            }
        }
       
        // gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0f, 0f, moveHorizontal * -5f));
        
        Vector3 targetpos = gameObject.transform.position;
        Vector3 targetrot = gameObject.transform.rotation.eulerAngles;
        Vector3 camrot = gameObject.transform.rotation.eulerAngles;
        Camera.main.transform.eulerAngles = new Vector3(0f, camrot.y, 0f);
        Camera.main.transform.position = new Vector3(R * Mathf.Cos(DtoR(-targetrot.y - 90f)) + targetpos.x, targetpos.y + 4f, R * Mathf.Sin(DtoR(-targetrot.y - 90f)) + targetpos.z);
    }

    public void StartCharge(int type) {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ChargeUI.SetActive(true);
        minimapUI.SetActive(false);
        IngameUI.SetActive(false);
        step = 2;
        // hidro
        if (type == 0) {
            animStep = 0;
            fillmout = 0f;
            Hidro.SetActive(true);
            Elec.SetActive(false);
            hidrofull.fillAmount = 0f;

            InvokeRepeating("fillAnim", 0f, 0.1818f);
        }

        if (type == 1) {
            animStep = 0;
            fillmout = 0f;
            Hidro.SetActive(false);
            Elec.SetActive(true);
            hidrofull.fillAmount = 0f;

            InvokeRepeating("fillAnim", 0f, 0.1818f);
        }

        InvokeRepeating("nextAnim", 0f, 0.5f);
    }

    public void fillAnim() {
        hidrofull.fillAmount = fillmout;
        elecfull.fillAmount = fillmout;
        fillmout += 0.01f;

        if (fillmout > 0.98f) {
            EndCharge();
        }
    }

    public void nextAnim() {
        if (animStep == 0) {
            ChargeText.text = StringDecode(".");
        }
        else if (animStep == 1) {
            ChargeText.text = StringDecode(". .");
        }
        else if (animStep == 2) {
            ChargeText.text = StringDecode(". . .");
        }
        else if (animStep == 3) {
            ChargeText.text = StringDecode(". . . 충");
        }
        else if (animStep == 4) {
            ChargeText.text = StringDecode(". . . 충전");
        }
        else if (animStep == 5) {
            ChargeText.text = StringDecode(". . . 충전중");
        }
        else if (animStep == 6) {
            ChargeText.text = StringDecode(". . . 충전중 .");
        }
        else if (animStep == 7) {
            ChargeText.text = StringDecode(". . . 충전중 . .");
        }
        else if (animStep == 8) {
            ChargeText.text = StringDecode(". . . 충전중 . . .");
            animStep = -1;
        }

        animStep++;
    }

    public void EndCharge() {
        CancelInvoke("fillAnim");
        CancelInvoke("nextAnim");
        ChargeUI.SetActive(false);
        Hidro.SetActive(false);
        Elec.SetActive(false);
        minimapUI.SetActive(true);
        IngameUI.SetActive(true);
        step = 1;
    }

    public static float DtoR(float degree) { 
        return (Mathf.PI / 180.0f) * degree;
    }
}
