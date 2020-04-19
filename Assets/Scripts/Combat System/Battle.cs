using System;
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

    [SerializeField]
    private CombatCharacter[] charactersDebug;

    public event Action<CombatCharacter[]> OnBattleStarted; 

    private void Start()
    {
        //StartBattle(charactersDebug);
    }

    public void StartBattle(CombatCharacter[] characters)
    {
        this.characters = characters;
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].StartBattle(this);
        }
        characters[turnId].StartTurn();
        OnBattleStarted?.Invoke(characters);
    }

    public void NextTurn()
    {
        characters[turnId].EndTurn();

        if (turnId == characters.Length -1)
            turnId = 0;
        else
            turnId++;

        characters[turnId].StartTurn();
    }

    public void End()
    {
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
