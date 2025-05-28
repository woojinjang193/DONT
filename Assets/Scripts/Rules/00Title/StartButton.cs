using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public bool isStartbuttonPressed = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Debug.Log("Start버튼 눌림");
            isStartbuttonPressed = true;

            if (GameRuleManager.Instance.ShouldDie())
            {
                GameManager.Instance.KillPlayer();
            }
            else
            {
                SceneManager.LoadScene("Scene_01");
            }
        }
    }
}
