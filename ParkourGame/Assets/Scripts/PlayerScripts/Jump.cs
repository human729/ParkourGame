using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jumps")]
    public int maxJumps;
    private int doneJumps;
    public float JumpHeight;
    PlayerMovement Movement;
    Animator PlayerAnimator;
    void Start()
    {
        Movement = GetComponent<PlayerMovement>();
        PlayerAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        DoubleJump(ref doneJumps);

        if (Movement.GroundedPlayer)
        {
            doneJumps = 0;
        }
    }

    private void DoubleJump(ref int numberOfJumps)
    {
        if (Input.GetKeyDown(KeyCode.Space) && numberOfJumps < maxJumps - 1)
        {
            Movement.PlayerVelocity.y = Mathf.Sqrt(JumpHeight * -2 * Movement.GravityValue);
            PlayerAnimator.SetBool("hasJumped", true);
            ++numberOfJumps;
        }
    }
}
