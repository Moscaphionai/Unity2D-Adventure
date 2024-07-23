using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, Vector3, bool> LoadRequestEvent;

    /// <summary>
    /// ������������
    /// </summary>
    /// <param name="locationToLoad">Ҫ���صĳ���</param>
    /// <param name="locationToGo">Player��Ŀ������</param>
    /// <param name="fadeScene">�Ƿ��뽥��</param>
    public void RaiseLoadRequestEvent(GameSceneSO locationToLoad, Vector3 locationToGo, bool fadeScene)
    {
        LoadRequestEvent(locationToLoad, locationToGo, fadeScene);
    }
}
