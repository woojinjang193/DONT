using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private Rigidbody2D rigid;
    private bool isMouseOnTheGround = false;

    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float direction = 1f; 

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isMouseOnTheGround)
        {
            rigid.velocity = new Vector2(direction * speed, rigid.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isMouseOnTheGround = true;

        }
      
        if (collision.collider.CompareTag("MonsterReturnWall") || collision.collider.CompareTag("Monster"))
        {
            direction *= -1f;
            spriteRenderer.flipX = direction < 0;
        }

        
    }
}
