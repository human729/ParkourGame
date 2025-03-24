using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCamera : MonoBehaviour
{
    public CinemachineFreeLook FreelookCamera;
    void Start()
    {
        FreelookCamera = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        
    }
}
