using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour, Boost
{
    Jump playerJump;
    private float boostJump = 6f;

    private void Start()
    {
        playerJump = GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>();
    }

    public void AddBoost()
    {
        playerJump.JumpHeight += boostJump;
    }

    public void Picked(GameObject pickableItem)
    {
        Destroy(pickableItem);
    }

    public void RemoveBoost()
    {
        StartCoroutine(WaitTime());
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5);
        playerJump.JumpHeight -= boostJump;
    }
}
