using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, Vector3, bool> LoadRequestEvent;

    /// <summary>
    /// 场景加载请求
    /// </summary>
    /// <param name="locationToLoad">要加载的场景</param>
    /// <param name="locationToGo">Player的目的坐标</param>
    /// <param name="fadeScene">是否渐入渐出</param>
    public void RaiseLoadRequestEvent(GameSceneSO locationToLoad, Vector3 locationToGo, bool fadeScene)
    {
        LoadRequestEvent(locationToLoad, locationToGo, fadeScene);
    }
}
