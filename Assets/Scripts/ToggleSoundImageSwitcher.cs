﻿using UnityEngine;
using UnityEngine.UI;
using System;
public class ToggleSoundImageSwitcher : MonoBehaviour
{
    private Image toggleImgSound;
    public Sprite switcherOn;
    public Sprite switcherOff;
    Toggle toggle;

    void Start()
    {
        toggleImgSound = GetComponent<Image>();
        toggle = GetComponent<Toggle>();
        toggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("Sound"));
        toggleImgSound.sprite = toggle.isOn ? switcherOn : switcherOff;
        SoundManager.Instance.soundManager.volume = toggle.isOn ? 1f : 0f;
    }

    public void SoundSwitch(bool isOn)
    {
        toggleImgSound.sprite = isOn ? switcherOn : switcherOff;
        SoundManager.Instance.soundManager.volume = isOn ? 1f : 0f;
        PlayerPrefs.SetInt("Sound", (isOn ? 1 : 0));
        PlayerPrefs.Save();
    }
}
