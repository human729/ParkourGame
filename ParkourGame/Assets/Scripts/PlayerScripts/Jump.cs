using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jumps")]
    public int maxJumps;
    public int doneJumps = 0;
    public float JumpHeight;
    PlayerMovement Movement;
    Animation DoubleJumpAnim;
    Animator PlayerAnimator;
    ParticleSystem ParticleSystem;
    void Start()
    {
        Movement = GetComponent<PlayerMovement>();
        PlayerAnimator = transform.GetChild(0).GetComponent<Animator>();
        ParticleSystem = transform.GetChild(2).GetComponent<ParticleSystem>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAnimator.SetBool("DoubleJump", false);
            DoubleJump(ref doneJumps);
        }

        //print(Movement.PlayerVelocity.y);

        if (Movement.GroundedPlayer && Movement.PlayerVelocity.y < 0)
        {
            //print(Movement.GroundedPlayer);
            doneJumps = 0;
            PlayerAnimator.SetBool("DoubleJump", false);
            PlayerAnimator.SetBool("hasJumped", false);
        }

        if (!Movement.GroundedPlayer && Movement.PlayerVelocity.y <= 0)
        {
            PlayerAnimator.SetBool("DoubleJump", false);
            PlayerAnimator.SetBool("hasJumped", false);
        }
    }

    private void DoubleJump(ref int numberOfJumps)
    {
        if (numberOfJumps < maxJumps - 1)
        {
            Movement.PlayerVelocity.y = Mathf.Sqrt(JumpHeight * -2 * Movement.GravityValue);
            if (numberOfJumps == 0)
            {
                PlayerAnimator.SetBool("hasJumped", true);
                ++numberOfJumps;
                print("r");
            }
            else if (numberOfJumps > 0)
            {
                ParticleSystem.Play();
                PlayerAnimator.SetBool("DoubleJump", true);
                if (PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("DoubleJump"))
                {
                    print("playing");
                    PlayerAnimator.Play("DoubleJump",0,0.2f);
                }
                ++numberOfJumps;
            } 
        }
    }
}
