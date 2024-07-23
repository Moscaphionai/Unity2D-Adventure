using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SavePoint : MonoBehaviour, IInteractable
{
    [Header("广播")]
    public VoidEventSO saveDataEvent;

    [Header("变量参数")]
    public Sprite Unuse;
    public Sprite Used;
    public SpriteRenderer curRenderer;
    public GameObject lightObj;
    bool isDone = false;

    private void OnEnable()
    {
        curRenderer.sprite = isDone ? Used : Unuse;
        lightObj.SetActive(isDone);
    }
    public void TriggeAction()
    {
        if (isDone) return;
        Interaction();
        saveDataEvent.RaiseEvent();
        lightObj.SetActive(true);
    }


    private void Interaction()
    {
        isDone = true;
        curRenderer.sprite = Used;
        this.gameObject.tag = "Untagged";
    }

}
