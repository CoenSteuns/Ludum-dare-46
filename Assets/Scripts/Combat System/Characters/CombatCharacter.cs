using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class CombatCharacter : MonoBehaviour
{
    [SerializeField]
    protected CardDealer dealer;

    [SerializeField]
    protected CardInventory inventory;

    protected Health health;

    protected Battle battle;

    public abstract void StartBattle(Battle battle);

    public abstract void StartTurn();

    public abstract void EndTurn();

    protected abstract void CheckHealth();
}
