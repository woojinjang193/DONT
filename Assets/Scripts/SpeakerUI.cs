using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpeakerUI : MonoBehaviour
{
    [SerializeField] private Sprite Unmute;
    [SerializeField] private Sprite Mute;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = Unmute;
    }

    private void Update()
    {
        if(AudioManager.instance.bgmVolume == 0 && AudioManager.instance.sfxMasterVolume == 0)
        {
            image.sprite = Mute;
        }

        else
        {
            image.sprite = Unmute;
        }
    }

}
