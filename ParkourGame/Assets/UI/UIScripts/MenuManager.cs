using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
   public List<GameObject> UIObjects = new List<GameObject>();
    private bool closeAllObjects;
    
    public void CloseAllObjects(bool value) => closeAllObjects = value;

    public void OpenOneObject(GameObject obj)
    {
        if (closeAllObjects)
        {
            foreach (GameObject objct in UIObjects)
            {
                objct.SetActive(false);
            }
        }
        obj.SetActive(true);
    }

    public void CloseOneObject(GameObject obj)
    {
        if (!closeAllObjects)
        {
            foreach (GameObject objct in UIObjects)
            {
                objct.SetActive(true);
            }
        }

        obj.SetActive(false);
    }
}
