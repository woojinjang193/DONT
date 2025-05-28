using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Sprite buttonUP;
    [SerializeField] private Sprite buttonDOWN;

    [SerializeField] private UnityEvent buttonPressed;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = buttonUP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Debug.Log("플레이어 버튼충돌");
            spriteRenderer.sprite = buttonDOWN;
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
            buttonPressed.Invoke();

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Debug.Log("플레이어 버튼 내려감");
            spriteRenderer.sprite = buttonUP;
        }
    }
}
