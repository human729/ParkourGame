using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed = 5.7f;
    public float jumpPower = 4f;
    private bool isGrounded;
    public int MaxJumps;
    private int numberOfJumps;
    public LayerMask GroundMask;
    private Rigidbody playerRb;
    private Vector3 Direction;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        numberOfJumps = 0;
    }

    
    void Update()
    {
        transform.position += Quaternion.Euler(0,Camera.main.transform.eulerAngles.y,0) * new Vector3(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && numberOfJumps < MaxJumps)
        {
            numberOfJumps++;
            print("Pressed space");
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerRb.AddForce(Camera.main.transform.forward * 15f, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            isGrounded = true;
            numberOfJumps = 0;
        }
    }
}
