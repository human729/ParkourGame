using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerMovement MovementScript;
    public Dash dash;
    public Text PlayerSpeedText;
    public Text PlayerDashCount;
    public Text PlayerJumpCount;
    // Start is called before the first frame update
    void Start()
    {
        PlayerDashCount.text = $"{dash.DashCount}";
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerSpeedText.text = $"{Mathf.Round(MovementScript.MoveSpeed * 2.5f)} km/h";
    }

    private void FixedUpdate()
    {
        PlayerSpeedText.text = $"{MovementScript.MoveSpeed * 4.5f} km/h";
        PlayerDashCount.text = $"{dash.DashCount}";
    }
}
