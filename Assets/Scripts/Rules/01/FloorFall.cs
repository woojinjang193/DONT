using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * -5f, ForceMode2D.Impulse);
        }
    }

}
