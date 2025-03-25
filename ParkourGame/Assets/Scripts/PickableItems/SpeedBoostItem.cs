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
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(5f);
        playerMovement.MoveSpeed -= 10f;
        Picked();
    }
}
