using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    Boost booster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedBoost"))
        {
            booster = GameObject.FindGameObjectWithTag("BoostManager").GetComponent<SpeedBoost>();
            booster.AddBoost();
            booster.RemoveBoost();
            booster.Picked(other.gameObject);
        }

        if (other.gameObject.CompareTag("JumpBoost"))
        {
            booster = GameObject.FindGameObjectWithTag("BoostManager").GetComponent<JumpBoost>();
            booster.AddBoost();
            booster.RemoveBoost();
            booster.Picked(other.gameObject);
        }

        if (other.gameObject.CompareTag("PowerUp"))
        {
            booster = GameObject.FindGameObjectWithTag("BoostManager").GetComponent<PowerUp>();
            booster.AddBoost();
            booster.Picked(other.gameObject);
        }
    }
}
