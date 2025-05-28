using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DontMove : MonoBehaviour, IGameRule
{
    private bool moved = false;


    public void FrameCheck()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("a");
            moved = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("d");
            moved = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("  ");
            moved = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            else
            {
                Debug.Log("mouse");
                moved = true;
            }
        }
    }

    public bool ShouldPlayerDie()
    {
        return moved;
    }
  
}
