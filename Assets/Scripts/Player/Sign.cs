using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sign : MonoBehaviour
{
    public GameObject signSprite;
    private bool canPrese;
    public Transform playerTrans;
    private PlayerInputControl playerInput;
    private IInteractable targetItem;

    private void Awake()
    {
        playerInput = new PlayerInputControl();
        playerInput.Enable();
    }
    private void OnEnable()
    {
        InputSystem.onActionChange += OnActionChange;
        playerInput.Gameplay.Confirm.started += OnConfirm;
    }
    private void OnDisable()
    {
        canPrese = false;
    }

    private void Update()
    {
        signSprite.GetComponent<SpriteRenderer>().enabled = canPrese;
        signSprite.transform.localScale = playerTrans.localScale;
    }

    private void OnConfirm(InputAction.CallbackContext context)
    {
        if(canPrese)
        {
            targetItem.TriggeAction();
            GetComponent<AudioDefination>()?.PlayAudioClip();
        }
    }

    private void OnActionChange(object obj, InputActionChange actionChange)
    {
        if (actionChange == InputActionChange.ActionStarted)
        {
            //Debug.Log(((InputAction)obj).activeControl.device);
            var d = ((InputAction)obj).activeControl.device;
            switch (d.device)
            {
                case Keyboard:

                    break;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            canPrese = true;
            targetItem = collision.GetComponent<IInteractable>();
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canPrese = false;
    }
}
