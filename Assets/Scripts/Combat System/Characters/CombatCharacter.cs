using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Health))]
public abstract class CombatCharacter : MonoBehaviour
{
    [SerializeField]
    protected CardDealer dealer;

    [SerializeField]
    protected CardInventory inventory;

    protected Health health;

    protected Battle battle;

    protected bool isStunned = false;
    protected int stunnedTime = 0;

    public Health Health => health;

    public int StunnedTime { get => stunnedTime; set => stunnedTime = value; }

    public Action<String, bool> OnStun;

    private void Awake()
    {
        health = gameObject.GetComponent<Health>();
        health.OnHealthChange += CheckHealth;
    }

    public abstract void StartBattle(Battle battle);

    public abstract void StartTurn();

    public abstract void EndTurn();

    public abstract void ClearInventory();

    protected abstract void CheckHealth(Health health);
}
