using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    PlayerMovement Movement;
    public float DashTime;
    public float DashDistance;
    void Start()
    {
        Movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            StartCoroutine(Dashing());

        }
    }

    IEnumerator Dashing()
    {
        float startTime = Time.time;
        while (startTime + DashTime > Time.time)
        {
            Movement.controller.Move(Movement.moveDir * Time.deltaTime * DashDistance);
            yield return null;
        }
    }
}
