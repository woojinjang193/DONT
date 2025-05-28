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

    private PlayerContoller player;

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

    }

    private void Start()
    {
    }

    private void Update()
    {
      if (player.isDead)
       {
         WhatsNextScene();

       }
            

    }

    public void WhatsNextScene()
    {

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



}
