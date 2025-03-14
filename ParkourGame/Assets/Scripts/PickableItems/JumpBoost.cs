using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour, Boost
{
    PlayerMovement playerMovement;
    private float boostJump = 6f;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void AddBoost()
    {
        playerMovement.JumpHeight += boostJump;
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
        playerMovement.JumpHeight -= boostJump;
    }
}
