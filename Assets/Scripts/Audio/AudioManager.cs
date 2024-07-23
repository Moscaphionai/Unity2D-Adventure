using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("事件监听")]
    public PlayerAudioEventSO BGMEvent;
    public PlayerAudioEventSO FXEvent;
    public FloatEventSO volumeEvent;
    public VoidEventSO pauseEvent;

    [Header("广播")]
    public FloatEventSO syncVolumeEvent;


    [Header("组件")]
    public AudioSource BGMSource;
    public AudioSource FXSource;
    public AudioMixer audioMixer;

    private void OnEnable()
    {
        FXEvent.OnEventRaise += OnFXEvent;
        BGMEvent.OnEventRaise += OnBGMEvent;
        volumeEvent.OnEventRaised += OnVolumeChange;
        pauseEvent.OnEventRaised += OnPuseEvent;
    }
    private void OnDisable()
    {
        FXEvent.OnEventRaise -= OnFXEvent;
        BGMEvent.OnEventRaise -= OnBGMEvent;
        volumeEvent.OnEventRaised -= OnVolumeChange;
        pauseEvent.OnEventRaised -= OnPuseEvent;
    }
    private void OnPuseEvent()
    {
        float amout;
        audioMixer.GetFloat("MasterVolume",out amout);
        syncVolumeEvent.RaiseEvent(amout);
    }

    private void OnVolumeChange(float amount)
    {
        audioMixer.SetFloat("MasterVolume", amount * 100 - 80);
    }

    private void OnFXEvent(AudioClip audioClip)
    {
        FXSource.clip = audioClip;
        FXSource.Play();
    }    
    private void OnBGMEvent(AudioClip audioClip)
    {
        FXSource.clip = audioClip;
        FXSource.Play();
    }
}
