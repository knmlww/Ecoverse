using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard : MonoBehaviour
{
    public GameObject map;
    public float movementSpeed = 10;
    public float jumpForce = 500;
    public float timeBeforeNextJump = 1f;
    private float canJump = 0f;
    Rigidbody rb;
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        map = GameObject.Find("MAP");
    }

    void Update()
    {
        if (map.GetComponent<MapController>().lockflag == 0) {
            ControllPlayer();
        }
    }

    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
            
        }
        else {
            // 
            anim.SetInteger("Walk", 0);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if (Input.GetButtonDown("Jump") && Time.time > canJump)
        {
                rb.AddForce(0, jumpForce, 0);
                canJump = Time.time + timeBeforeNextJump;
                // anim.SetTrigger("jump");
                anim.SetTrigger("Jump");
        }
    }
}
