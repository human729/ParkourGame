using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoostItem : DefaultItem
{
    public override void ItemBehaviour(GameObject Player)
    {
        Dash.MaxDashCount++;
        Dash.DashCount = Dash.MaxDashCount- 1;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
    }
}
