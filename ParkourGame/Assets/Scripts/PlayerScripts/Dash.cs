using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Dash : MonoBehaviour
{
    PlayerMovement Movement;
    public float DashTime;
    public int DashCount;
    public int MaxDashCount;
    public float DashDistance;
    public bool DashReturn;

    private void Awake()
    {
        DashCount = MaxDashCount;
    }
    void Start()
    {
        Movement = GetComponent<PlayerMovement>();
        StartCoroutine(GetDash());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && DashCount <= MaxDashCount && DashCount > 0)
        {
            //DashReturn = false;
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
        --DashCount;
    }

    private IEnumerator GetDash()
    {

        //for (int i = DashCount; i < MaxDashCount; ++i)
        //{
        while (true)
        {
            if (DashCount < MaxDashCount)
            {
                yield return new WaitForSeconds(5f);
                ++DashCount;
            } else
            {
                yield return null;
            }
        }
    }

    //}
}

