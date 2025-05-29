using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRule : MonoBehaviour, IGameRule
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private StartButton startButton;

    public void FrameCheck()
    {

    }

    public bool ShouldPlayerDie()
    {

            return background.color != Color.black && startButton.isStartbuttonPressed;

    }
  
}
