using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorUpDown : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigid;

    [Header("Going_Down")]
    [SerializeField] private float fallingSpeed = 3;
    [SerializeField] private float fallingDelayTime = 0.2f;
    [SerializeField] private float downBlockLifeTime = 2;

    [Header("Going_UP")]
    [SerializeField] private float upSpeed = 40;
    [SerializeField] private float upDelayTime = 0.2f;
    [SerializeField] private float upBlockLifeTime = 0.5f;

    private SpriteRenderer spriteRenderer;
    private Color originColor;

    private bool isUp;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originColor = spriteRenderer.color;

        rigid.isKinematic = true;

        if(originColor == Color.white)
        {
            isUp = false;
        }
        
        if(originColor == Color.gray)
        {
            isUp = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Color curColor = spriteRenderer.color;

            if (curColor == Color.white)
            {
                spriteRenderer.color = Color.gray;
                isUp = true;
            }
            else if (curColor == Color.gray)
            {
                spriteRenderer.color = Color.white;
                isUp = false;
            }
        }

        if (collision.collider.CompareTag("Player"))
        {
            if (!isUp)
            {
                Invoke("FallingDelay", fallingDelayTime);
                Invoke("FloorFalse", downBlockLifeTime);
            }

            else
            {
                Invoke("UpDelay", upDelayTime);
                Invoke("FloorFalse", upBlockLifeTime);
            }
        }

    }

    private void FallingDelay()
    {
        rigid.isKinematic = false;
        rigid.AddForce(Vector2.up * -fallingSpeed, ForceMode2D.Impulse);
    }

    private void UpDelay()
    {
        rigid.isKinematic = false;
        rigid.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
    }

    private void FloorFalse()
    {
        gameObject.SetActive(false);
    }
}
