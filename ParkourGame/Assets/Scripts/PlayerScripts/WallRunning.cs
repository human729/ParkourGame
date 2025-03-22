using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    private PlayerMovement Movement;
    public LayerMask WallToRun;
    private CharacterController controller;
    private float turnSmoothVelocity;
    Animator PlayerAnimator;
    Vector3 JumpDirection;
    Jump Jumping;
    bool isJumping;
    bool leftWall, rightWall;
    RaycastHit HitRight, HitLeft;

    void Start()
    {
        Movement = GetComponent<PlayerMovement>();
        controller = GetComponent<CharacterController>();
        PlayerAnimator = transform.GetChild(0).GetComponent<Animator>();
        Jumping = GetComponent<Jump>();
    }


    void Update()
    {
        Vector3 WallInput = new Vector3(0, 0, Input.GetAxis("Vertical")).normalized;
        rightWall = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out HitRight, 0.75f, WallToRun);
        leftWall = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out HitLeft, 1f, WallToRun);
        
        if (rightWall && !isJumping)
        {
            Movement.GravityValue = 0;
            WallRunInput(WallInput,1);
        }
        else if (leftWall && !isJumping)
        {
            Movement.GravityValue = 0;
            WallRunInput(WallInput,0);
        }
        else
        {
            EnableGravity();
            //print("sdsd");
        }
    }

    private void WallRunInput(Vector3 WallInput, int WallPosition)
    {
        if (WallInput.magnitude >= 0.1f)
        {
            Movement.enabled = false;
            //float targetAngle = Mathf.Atan2(WallInput.x, WallInput.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
            //transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir =  Camera.main.transform.forward * WallInput.z; 

            controller.Move(moveDir.normalized * Movement.MoveSpeed * Time.deltaTime);

            if (WallInput.z > 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    EnableGravity();
                    StartCoroutine(WallJump());
                    return;
                }
                transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
                if (WallPosition == 1)
                {
                    PlayerAnimator.SetBool("WallRunRight", true);
                }
                if (WallPosition == 0)
                {
                    PlayerAnimator.SetBool("WallRunLeft", true);
                }
            }

            if (WallInput.z < 0)
            {
                EnableGravity();
            }
        }
        else
        {
            EnableGravity();
        }
    }

    IEnumerator WallJump()
    {
        Vector3 JumpDirectionSide = rightWall ? new Vector3(-transform.right.x, 0, -transform.right.z) : new Vector3(transform.right.x, 0, transform.right.z);
        Movement.PlayerVelocity = transform.up * Jumping.JumpHeight + JumpDirectionSide * 10f;
        print(Movement.PlayerVelocity);
        isJumping = true;
        controller.Move(Camera.main.transform.right);
        PlayerAnimator.SetBool("hasJumped", true);
        yield return new WaitForSeconds(0.3f);
        Movement.PlayerVelocity.x = 0;
        Movement.PlayerVelocity.z = 0;
        isJumping = false;
    }
    
    private void EnableGravity()
    {
        Movement.enabled = true;
        Movement.GravityValue = -15;
        PlayerAnimator.SetBool("WallRunLeft", false);
        PlayerAnimator.SetBool("WallRunRight", false);
    }
}
