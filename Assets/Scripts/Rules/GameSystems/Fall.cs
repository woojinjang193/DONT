using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    [SerializeField] PlayerContoller player;
    private void OnTriggerEnter2D(Collider2D trigger)
    {

        if(trigger.CompareTag("Player"))
        {
            player.PlayerDie();
            GameManager.Instance.RetryOrLeave();
        }

    }
}

