using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamera : MonoBehaviour
{
    public GameObject player;
    public float cameraX, cameraY;
    public float sensitivity;
    public float minY, maxY;

    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        cameraY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        cameraY = Mathf.Clamp(cameraY, -10f, 45f);
        transform.position = player.transform.position + Quaternion.Euler(cameraY, cameraX, -10f) * new Vector3(0, 0, -10f);
        
        transform.LookAt(player.transform.position);

        player.transform.rotation = Quaternion.Lerp(player.transform.rotation,new Quaternion(transform.rotation.x,0,0,0),0.1f);
    }
}
