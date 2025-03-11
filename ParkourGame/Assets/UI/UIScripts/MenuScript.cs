using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Texture2D PointerNormal;
    private void Start()
    {
        Cursor.SetCursor(PointerNormal, Vector2.zero, CursorMode.Auto);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
