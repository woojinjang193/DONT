using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrigger : MonoBehaviour
{
    [SerializeField] private GameObject mouse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (mouse != null && collision.CompareTag("Player"))
        {
            Debug.Log("플레이어 감지");
            mouse.SetActive(true);
        }
    }
}
