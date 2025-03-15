using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
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
    public CharacterController controller;
    public float GravityValue;
    private bool GroundedPlayer;
    public float JumpHeight;
    public Vector3 moveDir;
    public Quaternion rotation;
    //public float DashTime;
    //public float DashDistance;
    private bool isMoving;
    Animator PlayerAnimator;
    float AnimFloat;
    float FallingY;
    private bool isWalkableWall;
    float StartSpeed;
    bool isSpeedIncreased;
    private float MaxSpeed = 24f;
    [Header("Jumps")]
    public int maxJumps;
    private int doneJumps = 0;
    private bool isJumped;

    //public CharacterMovement characterMovement = new CharacterMovement(new Staying());

    //public class CharacterMovement
    //{
    //    public MovingState MovingState { get; set; }

    //    public CharacterMovement(MovingState movingState)
    //    {
    //        MovingState = movingState;
    //    }

    //    public void Move()
    //    {
    //        MovingState.Move(this, PlayerAnimator);
    //    }

    //    public void Slow()
    //    {
    //        MovingState.Slow(this, PlayerAnimator);
    //    }
    //}

    //public interface MovingState
    //{
    //    public void Move(CharacterMovement movement, Animator animator);

    //    public void Slow(CharacterMovement movement, Animator animator);
    //}

    //public class Staying : MovingState
    //{
    //    public void Move(CharacterMovement movement, Animator animator)
    //    {
    //        animator.SetFloat("move", 0.28f);
    //    }

    //    public void Slow(CharacterMovement movement, Animator animator)
    //    {
    //        animator.SetFloat("move", 0);
    //    }
    //}

    //public class Moving : MovingState
    //{
    //    public void Move(CharacterMovement movement, Animator animator)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Slow(CharacterMovement movement, Animator animator)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class Running : MovingState
    //{
    //    public void Move(CharacterMovement movement, Animator animator)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Slow(CharacterMovement movement, Animator animator)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class Sprinting : MovingState
    //{
    //    public void Move(CharacterMovement movement, Animator animator)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Slow(CharacterMovement movement, Animator animator)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    void Start()
    {
        AnimFloat = 0;
        controller = GetComponent<CharacterController>();
        PlayerAnimator = transform.GetChild(0).GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        StartSpeed = MoveSpeed;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        GroundedPlayer = controller.isGrounded;

        Vector3 InputVector = new Vector3 (horizontalInput,0,verticalInput).normalized;

        if (InputVector.magnitude >= 0.1f)
        {
            if (!isSpeedIncreased && MoveSpeed == StartSpeed)
            {
                isSpeedIncreased = true;
                AnimFloat = 1;
                PlayerAnimator.SetFloat("move", AnimFloat);
                StartCoroutine(Sprint(InputVector));
            }

            float targetAngle = Mathf.Atan2(InputVector.x, InputVector.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            moveDir = Quaternion.Euler(0, angle, 0) * new Vector3(0, 0, 1);

            controller.Move(moveDir.normalized * MoveSpeed * Time.deltaTime);

            //if (MoveSpeed > 8f && MoveSpeed < 20f)
            //{
            //    AnimFloat = 0.67f;
            //    PlayerAnimator.SetFloat("move", AnimFloat);
            //}
            //if (MoveSpeed <= 8f)
            //{
            //AnimFloat = Mathf.Lerp(AnimFloat, 1, 0.2f);
            //PlayerAnimator.SetFloat("move", AnimFloat);
            //}
            //if (MoveSpeed <= MaxSpeed && MoveSpeed >= 20f)
            //{
            //    AnimFloat = Mathf.Lerp(AnimFloat, 1, 1.1f);
            //    PlayerAnimator.SetFloat("move", AnimFloat);
            //}
        }

        if (InputVector.magnitude < 0.1f)
        {
            StopAllCoroutines();
            MoveSpeed = StartSpeed;
            isSpeedIncreased = false;
                AnimFloat = 0;
                PlayerAnimator.SetFloat("move", AnimFloat);
            
        }
        


        

       
        if (!GroundedPlayer)
        {
            PlayerAnimator.SetBool("isFalling", true);
            PlayerAnimator.SetBool("hasJumped", false);
            if (!PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("DoubleJump"))
            {
                PlayerAnimator.SetBool("DoubleJump", false);
            }
        }
        if (GroundedPlayer && PlayerVelocity.y <= 0f)
        {
            doneJumps = 0;
            PlayerAnimator.SetBool("isFalling", false);
            PlayerAnimator.SetBool("DoubleJump", false);
            print("ground");
        }
        PlayerVelocity.y += GravityValue * Time.deltaTime;
        controller.Move(PlayerVelocity * Time.deltaTime);

        DoubleJump(ref doneJumps);
        //print(AnimFloat);
    }

    private void DoubleJump(ref int numberOfJumps)
    {
        if (Input.GetKeyDown(KeyCode.Space) && numberOfJumps < maxJumps - 1)
        {   
            print("Jumping");
            PlayerVelocity.y = Mathf.Sqrt(JumpHeight * -2 * GravityValue);
            if (numberOfJumps > 0)
            {
                PlayerAnimator.SetBool("DoubleJump", true);
                //FallingY = PlayerVelocity.y;
                print(numberOfJumps);
                ++numberOfJumps;
                //PlayerAnimator.SetBool("DoneJumping", true);
                
            } else if (numberOfJumps <= 0 )
            {
                PlayerAnimator.SetBool("hasJumped", true);
                FallingY = PlayerVelocity.y;
                print(numberOfJumps);
                ++numberOfJumps;
            }
            
        }
    }

   

    IEnumerator Sprint(Vector3 InputVector)
    {
        for (int i = 0; i < 2; i++)
        {
            if (MoveSpeed == MaxSpeed || InputVector.magnitude < 0.1f) 
            {
                yield break;
            } 
            yield return new WaitForSeconds(2f);
            MoveSpeed += 4;
            AnimFloat = i+2;
            PlayerAnimator.SetFloat("move", AnimFloat);
            print("AddingSpeed");
        }
    }


}
