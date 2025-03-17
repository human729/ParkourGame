using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    private PlayerMovement Movement;
    public LayerMask WallToRun;
    private CharacterController controller;
    private float turnSmoothVelocity;
    Animator PlayerAnimator;

    void Start()
    {
        Movement = GetComponent<PlayerMovement>();
        controller = GetComponent<CharacterController>();
        PlayerAnimator = transform.GetChild(0).GetComponent<Animator>();
    }


    void Update()
    {
        Vector3 WallInput = new Vector3(0, 0, Input.GetAxis("Vertical")).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 0.6f, WallToRun))
        {
            Movement.GravityValue = 0;           
            WallRunInput(WallInput,1);
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 0.6f, WallToRun))
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
        print(WallInput);
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

    private void EnableGravity()
    {
        Movement.enabled = true;
        Movement.GravityValue = -15;
        PlayerAnimator.SetBool("WallRunLeft", false);
        PlayerAnimator.SetBool("WallRunRight", false);
    }
}
