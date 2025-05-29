using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private GameObject audioUIPanel;

    void Start()
    {
        float savedBgm = PlayerPrefs.GetFloat("BGMVOLUME", 0.2f); 
        float savedSfx = PlayerPrefs.GetFloat("SFXVOLUME", 1f); 

        bgmSlider.value = savedBgm;
        sfxSlider.value = savedSfx;

        bgmSlider.onValueChanged.AddListener(BGMSlider);  //�����̴� �����̸� ��ȣ���� �Լ� ȣ��
        sfxSlider.onValueChanged.AddListener(fxSlider);
    }

    private void BGMSlider(float value)
    {
        AudioManager.instance.SetBgmVolume(value);
    }

    private void fxSlider(float value)
    {
        AudioManager.instance.SetSfxVolume(value);
    }

    public void UIshowup()
    {
        bool isActive = audioUIPanel.activeSelf;
        audioUIPanel.SetActive(!isActive);
    }
}
