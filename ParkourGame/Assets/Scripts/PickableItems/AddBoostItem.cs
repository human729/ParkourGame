using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoostItem : DefaultItem
{
    public override void ItemBehaviour(GameObject Player)
    {
        Dash.MaxDashCount++;
        Dash.DashCount++;
        Destroy(gameObject);
    }
}
