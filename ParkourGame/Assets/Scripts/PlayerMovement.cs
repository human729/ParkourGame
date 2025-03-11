using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed;

    public Transform Orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public ThirdPersonCam Cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Vector3 InputVector = new Vector3 (horizontalInput,0,verticalInput);
        
        //Vector3 moveDirection = new Vector3 (transform.forward.x, rb.velocity.y, transform.forward.z);
        rb.velocity = Cam.inputDir.normalized * MoveSpeed;
        
    }

    private void FixedUpdate()
    {
        
    }
}
