﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemy : CombatCharacter
{
    [SerializeField]
    private AttackColorTypes clanType;

    [SerializeField]
    private static int lowHealthPercentage = 30;
    [SerializeField]
    private static int highHealthPercentage = 70;

    private int opponentStunnedRounds = 0;

    public override void StartBattle(Battle battle)
    {
        this.battle = battle;
        Health.SetHealth(Health.Max);
        dealer.DealCards(4, clanType);
    }

    public override void StartTurn()
    {
        Card currentCard = null;
        if (Calculator.CalculatePercentage(health.Max, health.Current) <= lowHealthPercentage)
            currentCard = FindCard(CardType.Healing);
        else if (Calculator.CalculatePercentage(health.Max, health.Current) >= highHealthPercentage)
            currentCard = opponentStunnedRounds > 0 ? FindCard(CardType.Attack) : FindCard(CardType.Healing, false);
        
        if(currentCard == null)
            currentCard = inventory.Cards[0];

        if (currentCard.Info.TypeCard == CardType.Stun)
            opponentStunnedRounds = currentCard.Info.PrimaryValue;

        currentCard.Use(battle);
    }

    public override void EndTurn()
    {
        dealer.DealCards(1, clanType);
    }

    protected override void CheckHealth(Health health)
    {
        if (health.Current > 0)
            return;
        battle.End();
        Destroy(gameObject);
    }

    private Card FindCard(CardType type, bool include = true)
    {
        for (int i = 0; i < inventory.Cards.Count; i++)
        {
            if ((inventory.Cards[i].Info.TypeCard == type) == include)
                return inventory.Cards[i];
        }
        return null;
    }
}
