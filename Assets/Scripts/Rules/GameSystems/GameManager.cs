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
        //Debug.Log("플레이어 죽음, R키 누르면 씬 리로드");
        retryInfo.SetActive(true);
        retryPanel.SetActive(true);


        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("씬 리로드");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("타이틀로");
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
        string curStageName = SceneManager.GetActiveScene().name;  //씬 이름을 저장

        int currentStageNumber = ConvertSceneNameToNumber(curStageName);  
        // 저장한 씬 이름을 ConvertSecenNameToNumber 함수의 매개변수로 넣고 currentStageIndex에 저장

        if (StageSave.instance.stageData.stageClear >= currentStageNumber)
        {

            Debug.Log("이미 클리어함");
            return;
        }

        StageSave.instance.stageData.stageClear = currentStageNumber;
        StageSave.instance.SaveData();

        Debug.Log($"클리어: {curStageName}");
    }

    private int ConvertSceneNameToNumber(string stageName)// 씬이름에서 숫자로 바꿔주는 함수
    {
        string stageNumber = stageName.Replace("Scene_", ""); // 씬 이름에서 "Scene_" 를 ""로 바꿈
        return int.Parse(stageNumber); // 앞에 0이 있으면 지워줌 01 >> 1
    }
}


