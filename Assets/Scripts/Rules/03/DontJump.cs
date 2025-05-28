using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DontJump : MonoBehaviour, IGameRule
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject secretFloor;
    [SerializeField] private Transform monster;
    private bool jumped = false;


    private void Start()
    {
        
    }

    public void FrameCheck()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("  ");
            jumped = true;
        }
    }

    public bool ShouldPlayerDie()
    {
        return jumped;
    }

    private void Update()
    {
        if(menu.activeSelf)
        {
            secretFloor.SetActive(true);
        }

        else
        {
            secretFloor.SetActive(false);
        }
    }


}
