using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface Boost
{
    public void AddBoost();

    public void RemoveBoost();

    public void Picked(GameObject item);
}
