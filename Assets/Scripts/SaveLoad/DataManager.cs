using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    [Header("ÊÂ¼þ¼àÌý")]
    public VoidEventSO saveDataEvent;
    public VoidEventSO loadDataEvent;
    private List<ISaveable> saveableList = new List<ISaveable>();
    private Data saveData;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        saveData = new Data();
    }
    private void OnEnable()
    {
        saveDataEvent.OnEventRaised += Save;
        loadDataEvent.OnEventRaised += Load;
    }
    private void OnDisable()
    {
        saveDataEvent.OnEventRaised -= Save;
        loadDataEvent.OnEventRaised -= Load;
    }

    public void RegisterSaveData(ISaveable saveable)
    {
        if (!saveableList.Contains(saveable))
        {
            saveableList.Add(saveable);
        }
    }
    public void UnRegisterSaveData(ISaveable saveable)
    {
        saveableList.Remove(saveable);
    }
    private void Save()
    {
        foreach(var saveable in saveableList)
        {
            saveable.GetSaveData(saveData);
        }
        //foreach(var saveable in saveData.characterPosDict)
        //{
        //  Debug.Log(saveable.Key + "  " + saveable.Value);
        //}
    }
    private void Load()
    {
        foreach(var saveable in saveableList)
        {
            saveable.LoadData(saveData);
        }
    }
}
