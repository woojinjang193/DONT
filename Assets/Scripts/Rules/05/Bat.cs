using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField] private Animator bat;

    private Animator animator;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && AudioManager.instance.sfxMasterVolume == 0)
        {
            bat.SetTrigger("Mute");
        }

        if(collision.CompareTag("Player") && AudioManager.instance.sfxMasterVolume > 0)
        {
            bat.SetTrigger("UnMute");
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Bat);
            Invoke("PlayerKillDelay", 0.2f);
        }
    }

    private void PlayerKillDelay()
    {
        GameManager.Instance.KillPlayer();
    }
}
