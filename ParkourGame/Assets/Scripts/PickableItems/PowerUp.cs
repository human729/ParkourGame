using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour, Boost
{
    Dash dashScript;

    private void Start()
    {
        dashScript = GameObject.FindWithTag("Player").GetComponent<Dash>();
    }

    public void AddBoost()
    {
        dashScript.MaxDashCount++;
    }

    public void Picked(GameObject item)
    {
        Destroy(item);
    }

    public void RemoveBoost()
    {
        dashScript.MaxDashCount--;
    }
}
