using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = currentScene + 1;
            GameManager.Instance.ClearStage();

            SceneManager.LoadScene(nextScene);
            AudioManager.instance.PlaySfx(AudioManager.Sfx.NextScene);
        }
    }

}
