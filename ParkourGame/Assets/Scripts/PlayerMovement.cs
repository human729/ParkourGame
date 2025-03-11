using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed;

    //public Transform Orientation;

    float horizontalInput;
    float verticalInput;
    float turnSmoothVelocity;
    Vector3 moveDirection;
    [SerializeField] CharacterController controller;

    Rigidbody rb;

    //public ThirdPersonCam Cam;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 InputVector = new Vector3 (horizontalInput,0,verticalInput).normalized;

        if (InputVector.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(InputVector.x,InputVector.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
            transform.rotation = Quaternion.Euler(0,angle,0);

            Vector3 moveDir = Quaternion.Euler(0, angle, 0) * new Vector3(0,0,1);

            //controller.Move(moveDir.normalized* MoveSpeed* Time.deltaTime);

            rb.velocity = moveDir.normalized * MoveSpeed * Time.deltaTime;

            //moveDirection.y += -9.81f * Time.deltaTime;
            //controller.Move(moveDirection * Time.deltaTime);
        }
        
        //Vector3 moveDirection = new Vector3 (transform.forward.x, rb.velocity.y, transform.forward.z);
        
        
    }

    private void FixedUpdate()
    {
        
    }
}
