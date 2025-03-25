using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerMovement MovementScript;
    public Jump jump;
    public Text PlayerSpeedText;
    public Text PlayerDashCount;
    public Text PlayerJumpCount;

    private void FixedUpdate()
    {
        PlayerSpeedText.text = $"{MovementScript.MoveSpeed * 4.5f} km/h";
        PlayerDashCount.text = $"{Dash.DashCount}";
        PlayerJumpCount.text = $"{jump.maxJumps - jump.doneJumps - 1}";
    }
}
