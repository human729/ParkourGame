using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultItem : MonoBehaviour
{
    public abstract void ItemBehaviour(GameObject Player);    
    public void Picked()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ItemBehaviour(other.gameObject);
        }
    }
}
