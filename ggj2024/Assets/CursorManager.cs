using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D mouseTexture;

    private Vector2 cursorHotSpot;

    private void Start()
    {
        cursorHotSpot = new Vector2(mouseTexture.height / 2, mouseTexture.width / 2);
        Cursor.SetCursor(mouseTexture, cursorHotSpot, CursorMode.Auto);
    }
}
