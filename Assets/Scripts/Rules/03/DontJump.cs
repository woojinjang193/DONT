using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DontJump : MonoBehaviour, IGameRule
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject secretFloor;
  

    [SerializeField] private GameObject hint1;
    [SerializeField] private GameObject hint2;
    private bool jumped = false;
    private float timer = 0;
    private bool isHint1Showed = false;
    private bool isHint2Showed = false;


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

        // �ð������� ��Ʈ��
        timer += Time.deltaTime;

        if(timer>60f && !isHint1Showed)
        {
            hint1.SetActive(true);
            Debug.Log("hint1 ���");
            isHint1Showed = true;
        }


        if (timer > 120f && !isHint2Showed)
        {
            hint2.SetActive(true);
            Debug.Log("hint2 ���");
            isHint2Showed = true;
        }
    }


}
