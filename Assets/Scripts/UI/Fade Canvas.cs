using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
    [Header("�¼�����")]
    public FadeEventSO fadeEventSO;
    public Image fadeImage;

    private void OnEnable()
    {
        fadeEventSO.OnEventRaised += OnFadeEvent;
    }
    private void OnDisable()
    {
        fadeEventSO.OnEventRaised -= OnFadeEvent;
    }

    private void OnFadeEvent(Color target, float duration, bool fadeIn)
    {
        fadeImage.DOBlendableColor(target, duration);
    }
}
