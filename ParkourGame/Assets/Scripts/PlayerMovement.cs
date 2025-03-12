using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed;

    float horizontalInput;
    float verticalInput;
    float turnSmoothVelocity;
    Vector3 PlayerVelocity;
    CharacterController controller;
    public float GravityValue;
    public float JumpHeight;
    Vector3 moveDir;
    public float DashTime;
    public float DashDistance;
    private bool isMoving;
    Animator PlayerAnimator;
    float AnimFloat;
    float FallingY;


    void Start()
    {
        AnimFloat = 0;
        controller = GetComponent<CharacterController>();
        PlayerAnimator = transform.GetChild(0).GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        bool GroundetPlayer = controller.isGrounded;

        Vector3 InputVector = new Vector3 (horizontalInput,0,verticalInput).normalized;
        if (MathF.Round(AnimFloat, 4) != 0.0001f)
        {
            AnimFloat = Mathf.Lerp(AnimFloat, 0, 0.015f);
        }
        PlayerAnimator.SetFloat("move", AnimFloat);
        
        if (InputVector.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(InputVector.x, InputVector.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            moveDir = Quaternion.Euler(0, angle, 0) * new Vector3(0, 0, 1);

            controller.Move(moveDir.normalized * MoveSpeed * Time.deltaTime);
            AnimFloat = Mathf.Lerp(AnimFloat, 0.2880295f, 1.1f);
            PlayerAnimator.SetFloat("move", AnimFloat);
            print(Mathf.Lerp(AnimFloat, 0.2880295f, 0.001f));
            

            
        }



        print(GroundetPlayer);
        if (Input.GetKeyDown(KeyCode.Space) && GroundetPlayer)
        {
            PlayerVelocity.y = Mathf.Sqrt(JumpHeight * -2 * GravityValue);
            PlayerAnimator.SetBool("hasJumped", true);
            FallingY = PlayerVelocity.y;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            StartCoroutine(Dash());
            
        }
        if (!GroundetPlayer)
        {
            PlayerAnimator.SetBool("isFalling", true);
            PlayerAnimator.SetBool("hasJumped", false);
        }
        if (GroundetPlayer)
        {
            PlayerAnimator.SetBool("isFalling", false);
        }
        PlayerVelocity.y += GravityValue * Time.deltaTime;
        controller.Move(PlayerVelocity * Time.deltaTime);
        


    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        while (startTime + DashTime > Time.time)
        {
            controller.Move(moveDir * Time.deltaTime * DashDistance);
            yield return null;
        }
    }
}
