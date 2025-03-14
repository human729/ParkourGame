using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour, Boost
{
    PlayerMovement playerMovement;
    private float boostSpeed = 6f;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void AddBoost()
    {
        playerMovement.MoveSpeed += boostSpeed;
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
        playerMovement.MoveSpeed -= boostSpeed;
    }
}
