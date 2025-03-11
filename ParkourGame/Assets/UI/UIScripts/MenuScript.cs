using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public Texture2D PointerNormal;
    private void Start()
    {
        Cursor.SetCursor(PointerNormal, Vector2.zero, CursorMode.Auto);
    }
}
