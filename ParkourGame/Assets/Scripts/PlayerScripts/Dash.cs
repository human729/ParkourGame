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
    public static int DashCount;
    public static int MaxDashCount = 2;
    public float DashDistance;
    public bool DashReturn;
    SkinnedMeshRenderer SkinnedMeshRenderer;
    ParticleSystem ParticleSystem;

    private void Awake()
    {
        DashCount = MaxDashCount;
    }
    void Start()
    {
        ParticleSystem = transform.GetChild(1).GetComponent<ParticleSystem>();
        SkinnedMeshRenderer = transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>();
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
        SkinnedMeshRenderer.enabled = false;
        float startTime = Time.time;
        while (startTime + DashTime > Time.time)
        {
            ParticleSystem.Play();
            Movement.controller.Move(Movement.moveDir * Time.deltaTime * DashDistance);
            yield return null;
        }
        --DashCount;
        SkinnedMeshRenderer.enabled = true;
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

