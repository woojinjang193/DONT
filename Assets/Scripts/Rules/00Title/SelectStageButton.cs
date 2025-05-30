using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectStageButton : MonoBehaviour
{
    [SerializeField] Button selectStageButton;
    [SerializeField] GameObject selectStagePanel;
    [SerializeField] private GameObject player;

    private void Start()
    {
        if (StageSave.instance.stageData.stageClear >= 1 )
        {
            selectStageButton.interactable = true;
        }
        else
        {
            selectStageButton.interactable = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (selectStageButton.interactable == true && collision.collider.CompareTag("Bullet"))
        {
            selectStagePanel.SetActive(true);
            player.SetActive(false);
        }
        else
        {
            return;
        }
    }

  
}
