﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField]
    private DrawPath pathMovement;
    [SerializeField]
    private Canvas combatCanvas;

    private CombatCharacter[] characters;

    private int turnId = 0;

    public event Action<CombatCharacter[]> OnBattleStarted;
    public event Action OnBattleEnded;

    private bool battleEnded = false;

    public void StartBattle(CombatCharacter[] characters)
    {
        battleEnded = false;
        this.characters = characters;
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].StartBattle(this);
        }
        characters[turnId].StartTurn();
        OnBattleStarted?.Invoke(characters);
    }

    public void NextTurn(bool noCard = false)
    {
        if (battleEnded)
            return;
        if (!noCard)
            characters[turnId].EndTurn();

        if (turnId == characters.Length -1)
            turnId = 0;
        else
            turnId++;

        characters[turnId].StartTurn();
    }

    public void End()
    {
        battleEnded = true;
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].ClearInventory();
        }

        OnBattleEnded?.Invoke();
        pathMovement.enabled = true;
        combatCanvas.enabled = false;
    }

    public CombatCharacter GetCharacter(bool hasTurn = true)
    {
        if(hasTurn)
            return characters[turnId];

        for (int i = 0; i < characters.Length; i++)
        {
            if (i != turnId)
                return characters[i];
        }

        return null;
    }
}
