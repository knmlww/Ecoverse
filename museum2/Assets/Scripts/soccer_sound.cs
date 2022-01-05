using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccer_sound : MonoBehaviour
{
    public AudioSource kick;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (kick.enabled) kick.Play();
        if (other.gameObject.CompareTag("player")) {
            Vector3 thispos = gameObject.transform.position;
            Vector3 ppos = other.transform.position;
            Vector3 mpos = (thispos - ppos);
            mpos.y = 1f;
            gameObject.GetComponent<Rigidbody>().AddForce(mpos * 12f);
        }
    }
}
