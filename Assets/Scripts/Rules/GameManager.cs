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
    [SerializeField] private GameObject gameMenu;



    private GameRuleManager gameRuleManager;
    private PlayerContoller player;
    public bool isMouseOnUI;

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
        if (!player.isDead && gameRuleManager != null && gameRuleManager.ShouldDie())
        {
            KillPlayer();
        }


        if (gameRuleManager != null)
        {
            gameRuleManager.FrameCheck();

            if (player.isDead)
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

    private void OpenMenu()
    {
        bool isActive = gameMenu.activeSelf;
        gameMenu.SetActive(!isActive);
    }


}
