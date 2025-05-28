using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChange : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;

    private int colorIndex = 0;
    private Color[] colors = new Color[]
    {
        Color.yellow,
        Color.blue,
        Color.black
    };

    public void BackgroundColor()
    {
        background.color = colors[colorIndex];
        colorIndex = (colorIndex + 1) % colors.Length;
    }


}
