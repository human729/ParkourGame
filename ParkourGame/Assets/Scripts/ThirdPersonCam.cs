using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform Orientation;
    public Transform Player;
    public Transform PlayerObj;
    public Rigidbody Rb;
    public Vector3 inputDir;
    public float RotationSpeed;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = Player.position - new Vector3(transform.position.x,Player.position.y,transform.position.z);
        Orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        inputDir = Orientation.forward * verticalInput+ Orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
        {
            PlayerObj.forward = Vector3.Slerp(PlayerObj.forward, inputDir.normalized, Time.deltaTime * RotationSpeed);
        }
    }
}
