using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject blueScreen;
    [SerializeField] private GameObject five;
    [SerializeField] private GameObject four;
    [SerializeField] private GameObject three;
    [SerializeField] private GameObject two;
    [SerializeField] private GameObject one;
    [SerializeField] private Transform movingWallTransform;
    [SerializeField] private GameObject movingWall;
    [SerializeField] private Transform exit;
    [SerializeField] private GameObject congrats;
    [SerializeField] private PlayerContoller player;
    [SerializeField] private Transform targetPosition;

    private float timer = 0f;

    private bool didShowArrow = false;
    private bool didHideArrow = false;
    private bool didHideWall = false;
    private bool didHideBlue = false;
    private bool didShow5 = false;
    private bool didShow4 = false;
    private bool didShow3 = false;
    private bool didShow2 = false;
    private bool didShow1 = false;
    private bool didCountDown = false;
    private bool didExitArrive = false;
    

    void Update()
    {
        timer += Time.deltaTime;

        if (!player.isDead)
        {

            if (timer >= 7f && !didShowArrow)
            {
                arrow.SetActive(true);
                didShowArrow = true;
            }


            if (timer >= 13f && !didHideArrow)
            {
                arrow.SetActive(false);
                didHideArrow = true;
            }

            if (timer >= 13f && timer <= 20f)
            {
                movingWallTransform.Translate(Vector3.right * 1.5f * Time.deltaTime);
            }


            if (timer >= 19f && !didHideWall)
            {
                movingWall.SetActive(false);
                blueScreen.SetActive(true);
                didHideWall = true;
            }

            if (timer >= 24f && !didHideBlue)
            {
                blueScreen.SetActive(false);
                didHideBlue = true;
            }


            if (timer >= 26f && !didShow5)
            {
                five.SetActive(true);
                didShow5 = true;
            }
            if (timer >= 27f && !didShow4)
            {
                five.SetActive(false);
                four.SetActive(true);
                didShow4 = true;
            }
            if (timer >= 28f && !didShow3)
            {
                four.SetActive(false);
                three.SetActive(true);
                didShow3 = true;
            }
            if (timer >= 29f && !didShow2)
            {
                three.SetActive(false);
                two.SetActive(true);
                didShow2 = true;
            }
            if (timer >= 30f && !didShow1)
            {
                two.SetActive(false);
                one.SetActive(true);
                didShow1 = true;
            }

            if (timer >= 31f && !didCountDown)
            {
                one.SetActive(false);
                congrats.SetActive(true);
                didCountDown = true;
            }

            if (didCountDown && !didExitArrive)
            {
                if (Vector3.Distance(exit.position, targetPosition.position) > 0.01f)
                {
                    exit.Translate(Vector3.up * 2f * Time.deltaTime);
                    AudioManager.instance.PlaySfx(AudioManager.Sfx.Door);
                }
                else
                {
                    didExitArrive = true;
                }

            }

            if (timer >= 40f)
            {
                exit.Translate(Vector3.left * 1.5f * Time.deltaTime);

            }
        }

        if (player.isDead)
        {
            arrow.SetActive(false);
            movingWall.SetActive(false);
            blueScreen.SetActive(false);
            five.SetActive(false);
            four.SetActive(false);
            three.SetActive(false);
            two.SetActive(false);
            one.SetActive(false);
        }
    }
}