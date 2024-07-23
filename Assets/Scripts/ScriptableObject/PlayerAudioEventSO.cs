using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/PlayAudioEventSO")] 
public class PlayerAudioEventSO : ScriptableObject
{
    public UnityAction<AudioClip> OnEventRaise;

    public void RaiseEvent(AudioClip audioClip)
    {
        OnEventRaise?.Invoke(audioClip);
    }
}
