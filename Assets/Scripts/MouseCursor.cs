using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public bool isMouseOnUI = false;
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("UI"))
        {
            isMouseOnUI = true;
            //Debug.Log("UI 위에있음");
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("UI"))
        {
            isMouseOnUI = false;
            //Debug.Log("UI 나옴");

        }
    }
}
