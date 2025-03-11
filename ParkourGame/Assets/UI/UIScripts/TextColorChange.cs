using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color(0, 217, 255, 32);
        transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(0, 217, 255, 32);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = Color.white;
        transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.white;
    }
}
