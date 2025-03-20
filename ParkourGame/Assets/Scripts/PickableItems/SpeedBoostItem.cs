using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : DefaultItem
{
    PlayerMovement playerMovement;
    public override void ItemBehaviour(GameObject Player)
    {
        playerMovement = Player.GetComponent<PlayerMovement>();
        playerMovement.MoveSpeed += 10f;
        StartCoroutine(RemoveBoost());
    }

    private IEnumerator RemoveBoost()
    {
        gameObject.GetComponent<SpeedBoostItem>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        playerMovement.MoveSpeed -= 10f;
        Picked();
    }
}
