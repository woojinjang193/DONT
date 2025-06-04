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

    private bool canContinue = false;

    private void Start()
    {
        ColorBlock buttonColor = selectStageButton.colors;

        if (StageSave.instance.stageData.stageClear >= 0 )
        {
            canContinue = true;
            buttonColor.disabledColor = Color.white;
        }
        else
        {
            canContinue = false;
            buttonColor.disabledColor = Color.gray;
        }

        selectStageButton.colors = buttonColor;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canContinue && collision.collider.CompareTag("Bullet"))
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
