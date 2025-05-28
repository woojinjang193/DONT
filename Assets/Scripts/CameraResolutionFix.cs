using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        float targetAspect = 16f / 9f;
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;
        Camera camera = Camera.main;

        if (scaleHeight < 1.0f)
        {
            Rect rect = new Rect(0, (1 - scaleHeight) / 2f, 1, scaleHeight);
            camera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = new Rect((1 - scaleWidth) / 2f, 0, scaleWidth, 1);
            camera.rect = rect;
        }
    }
}
