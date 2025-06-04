using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPath : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            spriteRenderer.color = new Color(1, 1, 1, 1f);
        }
    }
}
