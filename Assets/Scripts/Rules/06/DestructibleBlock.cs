using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBlock : MonoBehaviour
{
    private int damage;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite damage1;
    [SerializeField] private Sprite damage2;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            DamageIncrese();
        }
            
    }

    private void DamageIncrese()
    {
        damage++;

        switch (damage)
        {
            case 1:
                spriteRenderer.sprite = damage1;
                break;

            case 2:
                spriteRenderer.sprite = damage2;
                break;

            case 3:
                gameObject.SetActive(false);
                break;

            default:
                break;
        }
    }

}
