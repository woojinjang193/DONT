using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.EventSystems;
using static UnityEngine.UI.Image;
public class PlayerContoller : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Shooter shooter;

    [SerializeField] private PlayerAnimationController animController;
    [SerializeField] private GameObject playerDieEffect;

    private Rigidbody2D rigid;
    private SpriteRenderer downerSpriteRenderer;
    private SpriteRenderer upperSpriteRenderer;

    //private float groundCheckDistance = 0.1f;
    private LayerMask groundLayer; //�ʿ��Ѱ͸� �˻��ϱ�����

    [SerializeField] private Vector2 boxSize = new Vector2(0.5f, 0.1f);
    [SerializeField] private float boxDisdanceFromPlayer;



    private bool isGrounded;
    public bool isDead = false;
    private bool canAttack = true;
    private bool isInTheAir = false;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
        downerSpriteRenderer = transform.Find("DownerBody").GetComponent<SpriteRenderer>();
        upperSpriteRenderer = transform.Find("UpperBody").GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        CheckGroundWithRay();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isDead && !isInTheAir)
        {
            PlayerJump();
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Jump);
        }

        if (Input.GetMouseButtonDown(0) && canAttack && !isDead && !EventSystem.current.IsPointerOverGameObject())
        {
            PlayerAttack();
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Shoot);
        }


    }

    private void CheckGroundWithRay()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize ,0f, Vector2.down, boxDisdanceFromPlayer, groundLayer);

        if (hit.collider == null)

        {
            isInTheAir = true;
        }
        else
        {
            isInTheAir = false;
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

            animController.PlayerWalk(true);


        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
            downerSpriteRenderer.flipX = false;
            upperSpriteRenderer.flipX = false;

            animController.PlayerWalk(true);
        }
        else
        {
           // ���߿��� �ȸ��߰��ϸ� ���̵��� �ʹ� ������
          // if (isGrounded)
          // {
          //     rigid.velocity = new Vector2(0, rigid.velocity.y);
          // }
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            animController.PlayerWalk(false);
        }
    }

    private void PlayerJump()
    {
        rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        isGrounded = false;



        animController.SetJumping(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("�ٴ�");
            isGrounded = true;
            isInTheAir = false;
            animController.SetJumping(false);
        }

        if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Killable"))
        {
            PlayerDie();

        }
    }

    private void PlayerAttack()
    {
        canAttack = false;
        animController.PlayerAttack();
        shooter.Fire();

        Invoke(nameof(ResetAttack), attackCooldown);
    }

    private void ResetAttack()
    {
        canAttack = true;
    }

    public void PlayerDie()
    {
        Debug.Log("�÷��̾� ����");
        if (playerDieEffect != null)
        {
            Instantiate(playerDieEffect, transform.position, Quaternion.identity);
        }

        foreach (SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderer.enabled = false;
        }

        AudioManager.instance.PlaySfx(AudioManager.Sfx.PlayerDie);
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<Collider2D>().enabled = false;

        isDead = true;
        GameManager.Instance.RetryOrLeave();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Vector2 origin = (Vector2)transform.position + new Vector2(0f, -0.5f);


        Gizmos.DrawWireCube(origin + Vector2.down * boxDisdanceFromPlayer, boxSize);
    }


}