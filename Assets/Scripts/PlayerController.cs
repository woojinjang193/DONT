using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.EventSystems;
public class PlayerContoller : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D rigid;
    private SpriteRenderer downerSpriteRenderer;
    private SpriteRenderer upperSpriteRenderer;
    private bool isGrounded;
    public bool isDead = false;        



    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        downerSpriteRenderer = transform.Find("DownerBody").GetComponent<SpriteRenderer>();
        upperSpriteRenderer = transform.Find("UpperBody").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isDead)
        {
            PlayerJump();

        }

        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            Debug.Log("°ø°Ý");
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            PlayerMove();
        }

    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(-moveSpeed, rigid.velocity.y);
            downerSpriteRenderer.flipX = true;
            upperSpriteRenderer.flipX = true;



        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
            downerSpriteRenderer.flipX = false;
            upperSpriteRenderer.flipX = false;

        }
        else
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }
    }

    private void PlayerJump()
    {
        rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        isGrounded = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("¹Ù´Ú");
            isGrounded = true;

        }

        if ( collision.gameObject.CompareTag("Monster"))
        {
            PlayerDie();
        }

    }


    public void PlayerDie()
    {
        Debug.Log("ÇÃ·¹ÀÌ¾î Á×À½");

        foreach (SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderer.enabled = false;
        }

        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<Collider2D>().enabled = false;

        isDead = true;
    }

}
