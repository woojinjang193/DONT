using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] private GameObject retryPanel;
    [SerializeField] private GameObject retryInfo;
    [SerializeField] public GameObject gameMenu;



    private GameRuleManager gameRuleManager;
    private PlayerContoller player;
    public bool isMouseOnUI;
    public bool isMenuOpen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (player == null)
        {
            player = FindObjectOfType<PlayerContoller>();
        }

        retryInfo.SetActive(false);
        retryPanel.SetActive(false);
    }

    private void Start()
    {
        gameRuleManager = GameRuleManager.Instance;
        AudioManager.instance.PlayBgm();

    }

    private void Update()
    {
        if (player != null && !player.isDead && gameRuleManager != null && gameRuleManager.ShouldDie())
        {
            KillPlayer();
        }


        if (gameRuleManager != null)
        {
            gameRuleManager.FrameCheck();

            if (player != null && player.isDead)
            {
                RetryOrLeave();

            }
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }

    }
    public void KillPlayer()
    {
        if (!player.isDead)
        {
            player.PlayerDie();
        }
    }

    public void RetryOrLeave()
    {
        //Debug.Log("�÷��̾� ����, RŰ ������ �� ���ε�");
        retryInfo.SetActive(true);
        retryPanel.SetActive(true);


        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("�� ���ε�");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Ÿ��Ʋ��");
            SceneManager.LoadScene("Scene_00");

        }
    }

    public void OpenMenu()
    {
        isMenuOpen = gameMenu.activeSelf;
        gameMenu.SetActive(!isMenuOpen);
    }

 

    public void ClearStage()
    {
        string curStageName = SceneManager.GetActiveScene().name;  //�� �̸��� ����

        int currentStageNumber = ConvertSceneNameToNumber(curStageName);  
        // ������ �� �̸��� ConvertSecenNameToNumber �Լ��� �Ű������� �ְ� currentStageIndex�� ����

        if (StageSave.instance.stageData.stageClear >= currentStageNumber)
        {

            Debug.Log("�̹� Ŭ������");
            return;
        }

        StageSave.instance.stageData.stageClear = currentStageNumber;
        StageSave.instance.SaveData();

        Debug.Log($"Ŭ����: {curStageName}");
    }

    private int ConvertSceneNameToNumber(string stageName)// ���̸����� ���ڷ� �ٲ��ִ� �Լ�
    {
        string stageNumber = stageName.Replace("Scene_", ""); // �� �̸����� "Scene_" �� ""�� �ٲ�
        return int.Parse(stageNumber); // �տ� 0�� ������ ������ 01 >> 1
    }
}


