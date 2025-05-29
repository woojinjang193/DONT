using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunningIntoYellow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;


    private void OnTriggerEnter2D(Collider2D trigger)
    {

        if(trigger.CompareTag("Player"))
        {
            spriteRenderer.color = Color.yellow;
        }

    }
}

