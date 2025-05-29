using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuleManager : MonoBehaviour
{
    private static GameRuleManager instance;
    public static GameRuleManager Instance => instance;

    [SerializeField] private MonoBehaviour ruleScript;

    private IGameRule currentRule;
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

        currentRule = ruleScript as IGameRule; // IGameRule 인터페이스로 캐스팅


    }

    public void FrameCheck()
    {
        if (currentRule != null)
        {
            currentRule.FrameCheck();
        }
    }


    public bool ShouldDie()
    {
        return currentRule != null && currentRule.ShouldPlayerDie();
    }
}
