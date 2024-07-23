using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour, IInteractable
{
    public SceneLoadEventSO loadEventSO;
    public GameSceneSO sceneToGo;
    public Vector3 postionToGo;
    public void TriggeAction()
    {
        loadEventSO.RaiseLoadRequestEvent(sceneToGo, postionToGo, true);
    }
}
