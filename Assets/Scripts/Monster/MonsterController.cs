using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private GameObject monsterDieEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            if (monsterDieEffect != null)
            {
                Instantiate(monsterDieEffect, transform.position, Quaternion.identity);
            }

            gameObject.SetActive(false);
        }
    }
}
