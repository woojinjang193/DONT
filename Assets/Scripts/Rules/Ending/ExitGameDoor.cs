using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("게임종료");
            Application.Quit();
            AudioManager.instance.PlaySfx(AudioManager.Sfx.NextScene);
        }
    }
}
