using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject Shop1Manager, Shop2Manager;
    public GameObject ShopSellUI;

    public GameObject minimapCamera;

    public GameObject TradeSellUI;
    public GameObject chatUI1, chatUI2;

    public GameObject MAP;

    void Start()
    {
        MAP.GetComponent<MapController>().shopinflag = false;
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("player")) {
            if (gameObject.name.Equals("shop1_in_trigger")) {
                other.gameObject.transform.position = new Vector3(-720.5f, 0.8f, -92.04f);
                Shop1Manager.GetComponent<ShopManager>().step = 1;
                minimapCamera.GetComponent<MinimapCamera>().flag = false;
                chatUI1.SetActive(false);
                chatUI2.SetActive(false);
                MAP.GetComponent<MapController>().shopinflag = true;
            }

            else if (gameObject.name.Equals("shop1_out_trigger")) {
                other.gameObject.transform.position = new Vector3(-59.1f, 4.2f, -49f);
                Shop1Manager.GetComponent<ShopManager>().step = 0;
                minimapCamera.GetComponent<MinimapCamera>().flag = true;
                chatUI1.SetActive(true);
                chatUI2.SetActive(true);
                MAP.GetComponent<MapController>().shopinflag = false;
            }

            else if (gameObject.name.Equals("shop2_in_trigger")) {
                other.gameObject.transform.position = new Vector3(-755.2f, 0.8f, -92.04f);
                Shop2Manager.GetComponent<TradeShop>().UpdateItem();
                Shop2Manager.GetComponent<TradeShop>().step = 1;
                minimapCamera.GetComponent<MinimapCamera>().flag = false;
                chatUI1.SetActive(false);
                chatUI2.SetActive(false);
                MAP.GetComponent<MapController>().shopinflag = true;
            }   

            else if (gameObject.name.Equals("shop2_out_trigger")) {
                other.gameObject.transform.position = new Vector3(62.7f, 4.2f, -48.6f);
                Shop2Manager.GetComponent<TradeShop>().step = 0;
                minimapCamera.GetComponent<MinimapCamera>().flag = true;
                chatUI1.SetActive(true);
                chatUI2.SetActive(true);
                MAP.GetComponent<MapController>().shopinflag = false;
            }

            else if (gameObject.name.Equals("sell_trigger")) {
                ShopSellUI.SetActive(true);
            }

            else if (gameObject.name.Equals("trade_trigger")) {
                TradeSellUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("player")) {
            if (gameObject.name.Equals("sell_trigger")) {
                ShopSellUI.SetActive(false);
            }
            else if (gameObject.name.Equals("trade_trigger")) {
                TradeSellUI.SetActive(false);
            }
        }
    }
}
