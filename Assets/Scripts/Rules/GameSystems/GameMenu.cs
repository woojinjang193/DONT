using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public void CountinueButton()
    {
        menu.SetActive(false);
    }
    public void TitleButton()
    {
        SceneManager.LoadScene("Scene_00");
        menu.SetActive(false);
    }
    public void ExitButton()
    {
        Debug.Log("게임종료");
        Application.Quit();
    }
}
