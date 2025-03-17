using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Dash : MonoBehaviour
{
    PlayerMovement Movement;
    public float DashTime;
    public int DashCount;
    public float DashDistance;
    public bool DashReturn;
    void Start()
    {
        Movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && DashCount <= 2 && DashCount > 0)
        {
            DashReturn = false;
            StartCoroutine(Dashing());
            StopCoroutine(GetDash());
            --DashCount;
        }

        if (DashCount < 2 && !DashReturn)
        {
            StartCoroutine(GetDash());
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

    private IEnumerator GetDash()
    {
        DashReturn = true;
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
        }
        ++DashCount;
    }
}
