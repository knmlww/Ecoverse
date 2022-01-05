using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccer_goal : MonoBehaviour
{
    public ParticleSystem ps;
    public GameObject Profile;

    public AudioSource goal;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name.Equals("ball")) {
            goal.Play();
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.transform.position = new Vector3(42.66f, 7.19f, 86.23f);
            ps.Play();
            Profile.GetComponent<Profile>().badge_subinfo1 += 1;
            Profile.GetComponent<Profile>().CheckBadge();

            Profile.GetComponent<MissionManager>().MissionFlagOn(6, 1);
        }
    }
}
