using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddJumpBoostitem : DefaultItem
{
    Jump jump;
    public override void ItemBehaviour(GameObject Player)
    {
        jump = Player.GetComponent<Jump>();
        jump.JumpHeight += 4.7f;
        StartCoroutine(RemoveBoost());
    }

    private IEnumerator RemoveBoost()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(5f);
        jump.JumpHeight -= 4.7f;
        Picked();
    }
}
