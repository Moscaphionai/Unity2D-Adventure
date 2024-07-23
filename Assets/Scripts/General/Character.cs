using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour,ISaveable
{
    [Header("�¼�����")]
    public VoidEventSO NewGameEvent;
    [Header("��������")]
    public float maxHealth;
    public float currentHealth;

    [Header("�����޵�")]
    public float invulnerableDuration;
    public float invulnerableCounter;
    public bool invulnerable;

    public UnityEvent<Character> OnHealthChange;
    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent OnDie;
    private void NewGame()
    {
        currentHealth = maxHealth;
        OnHealthChange?.Invoke(this);
    }
    private void OnEnable()
    {
        NewGameEvent.OnEventRaised += NewGame;
        ISaveable saveable = this;
        saveable.RegisterSaveData();
    }
    private void OnDisable()
    {
        NewGameEvent.OnEventRaised -= NewGame;
        ISaveable saveable = this;
        saveable.UnRegisterSaveData();
    }
    private void Update()
    {
        if (invulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
            if(invulnerableCounter <= 0)
            {
                invulnerable = false;
            }
        }
    }
    public void TakeDamage(Attack attacker)
    {
        if (invulnerable) return;
        if (currentHealth - attacker.damage > 0)
        { 
            currentHealth -= attacker.damage;
            TriggerInvulnerable();
            //ִ������
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            currentHealth = 0;
            //��������
            OnDie?.Invoke();
        }
        OnHealthChange?.Invoke(this);
    }
    private void TriggerInvulnerable()
    {
        if(!invulnerable)
        {
            invulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }


    public DataDefinition GetDataID()
    {
        return GetComponent<DataDefinition>();
    }

    public void GetSaveData(Data data)
    {
        if (data.characterPosDict.ContainsKey(GetDataID().ID))
        {
            data.characterPosDict[GetDataID().ID] = transform.position;
            data.floatSveData[GetDataID().ID + "health"] = this.currentHealth;
        }
        else
        {
            data.characterPosDict.Add(GetDataID().ID, transform.position);
            data.floatSveData.Add(GetDataID().ID + "health", this.currentHealth);
        }
    }

    public void LoadData(Data data)
    {
        if (data.characterPosDict.ContainsKey(GetDataID().ID))
        {
            transform.position = data.characterPosDict[GetDataID().ID];
            this.currentHealth = data.floatSveData[GetDataID().ID + "health"];
            OnHealthChange?.Invoke(this);

        }
    }


}
