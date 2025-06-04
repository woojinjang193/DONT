using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStages : MonoBehaviour
{
    [SerializeField] private GameObject selectStageGoBackButton;
    [SerializeField] private GameObject[] stageButtons;
    [SerializeField] private GameObject player;
    
    private void Start()
    {
        int cleared = StageSave.instance.stageData.stageClear;

        for (int i = 0; i < stageButtons.Length; i++)
        {
            stageButtons[i].SetActive(i <= cleared);
        }
    }

    public void Stage01()
    {
        SceneManager.LoadScene("Scene_01");
    }

    public void Stage02()
    {
        SceneManager.LoadScene("Scene_02");
    }

    public void Stage03()
    {
        SceneManager.LoadScene("Scene_03");
    }

    public void Stage04()
    {
        SceneManager.LoadScene("Scene_04");
    }


    public void Stage05()
    {
        SceneManager.LoadScene("Scene_05");
    }

    public void Stage06()
    {
        SceneManager.LoadScene("Scene_06");
    }

    public void Stage07()
    {
        SceneManager.LoadScene("Scene_07");
    }


    public void Stage08()
    {
        SceneManager.LoadScene("Scene_08");
    }

    public void Stage09()
    {
        SceneManager.LoadScene("Scene_09");
    }

    public void Stage10()
    {
        SceneManager.LoadScene("Scene_10");
    }

    public void Stage11()
    {

    }

    public void Stage12()
    {

    }

    public void Stage13()
    {

    }

    public void GoBackToTitle()
    {
        if (GameManager.Instance.gameMenu.activeSelf) // 메뉴가 열려있으면 닫아줌
        {
            GameManager.Instance.OpenMenu();
        }

        selectStageGoBackButton.SetActive(false);
        player.SetActive(true);

    }
}
