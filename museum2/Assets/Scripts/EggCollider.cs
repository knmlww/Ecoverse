using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCollider : MonoBehaviour
{
    public GameObject coinManager;

    void Start()
    {
        coinManager = GameObject.Find("Main Island");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("player")) {
            int num = int.Parse(gameObject.name.Split('-')[1]);
            coinManager.GetComponent<CoinEgg>().GetCoin(num);
        }
    }
}
