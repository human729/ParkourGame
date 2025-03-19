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
        rightWall = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out HitRight, 0.55f, WallToRun);
        leftWall = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out HitLeft, 0.55f, WallToRun);
        
        if (rightWall)
        {
            Movement.GravityValue = 0;
            WallRunInput(WallInput,1);
        }
        else if (leftWall)
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
                    WallJump();
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

    private void WallJump()
    {
        Vector3 JumpDirectionSide = rightWall ? Vector3.right : Vector3.left;
        Vector3 JumpDirection = transform.up * Jumping.JumpHeight + JumpDirectionSide * 15f;
        rightWall = Physics.Raycast(transform.position, Vector3.zero, 0f);
        leftWall = Physics.Raycast(transform.position, Vector3.zero, 0f);
        print(JumpDirection);
        controller.Move(JumpDirection.normalized);
        PlayerAnimator.SetBool("hasJumped", true);
        if (JumpDirectionSide == Vector3.right)
        {
            PlayerAnimator.SetBool("WallRunRight", false);
        } else if (JumpDirectionSide == Vector3.left)
        {
            PlayerAnimator.SetBool("WallRunLeft", false);
        }
    }
    
    private void EnableGravity()
    {
        Movement.enabled = true;
        Movement.GravityValue = -15;
        PlayerAnimator.SetBool("WallRunLeft", false);
        PlayerAnimator.SetBool("WallRunRight", false);
    }
}
