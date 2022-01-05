using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstView : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 10f;

    [SerializeField]
    private float lookSensitivity = 2f; 

    [SerializeField]
    private float cameraRotationLimit = 30f;  
    private float currentCameraRotationX;  

    [SerializeField]
    private Camera theCamera; 
    private Rigidbody myRigid;

    public GameObject map;

    Animator anim;

    private float canJump = 0f;
    public float jumpForce = 500;
    public float timeBeforeNextJump = 1f;

    void Start() 
    {
        myRigid = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
        theCamera = Camera.main;

        map = GameObject.Find("MAP");
    }

    void Update()
    {
        // CameraRotation();
        if (map.GetComponent<MapController>().lockflag == 0) {
            Move();
            CharacterRotation();
        }
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");  
        float _moveDirZ = Input.GetAxisRaw("Vertical");  
        Vector3 _moveHorizontal = transform.right * _moveDirX; 
        Vector3 _moveVertical = transform.forward * _moveDirZ; 

        Vector3 movement = new Vector3(_moveDirX, 0.0f, _moveDirZ);

        if (movement != Vector3.zero)
        {
            anim.SetInteger("Walk", 1);
        }
        else {
            anim.SetInteger("Walk", 0);
        }

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed; 

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && Time.time > canJump)
        {
                myRigid.AddForce(0, jumpForce, 0);
                canJump = Time.time + timeBeforeNextJump;
                anim.SetTrigger("Jump");
        }
    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y"); 
        float _cameraRotationX = _xRotation * lookSensitivity;
        
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }
}
