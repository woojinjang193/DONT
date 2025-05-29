using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFall : MonoBehaviour
{
    [SerializeField] private float fallingSpeed = 3;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private float fallingDelayTime = 1;
    [SerializeField] private float blockLifeTime = 2;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.isKinematic = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            Invoke("FallingDelay", fallingDelayTime);
            Invoke("FloorFalse", blockLifeTime);
            
        }


    }

  //private void OnTriggerEnter2D(Collider2D collision)
  //{
  //    if (collision.CompareTag("FallingDeadLine"))
  //    {
  //        gameObject.SetActive(false);
  //    }
  //}

    private void FallingDelay()
    {
        rigid.isKinematic = false;
        rigid.AddForce(Vector2.up * -fallingSpeed, ForceMode2D.Impulse);
    }

    private void FloorFalse()
    {
        gameObject.SetActive(false);
    }

}