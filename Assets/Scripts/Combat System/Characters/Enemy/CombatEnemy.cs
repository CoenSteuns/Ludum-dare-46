using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemy : CombatCharacter
{
    [SerializeField]
    private AttackColorTypes clanType;

    public override void StartBattle(Battle battle)
    {
        this.battle = battle;
        Health.SetHealth(Health.Max);
        dealer.DealCards(4, clanType);
    }

    public override void StartTurn()
    {
        //LOGICS :)
        print(inventory.Cards.Count);
        int cardNumber = UnityEngine.Random.Range(0, inventory.Cards.Count);
        inventory.Cards[cardNumber].Use(battle);
        inventory.RemoveCard(cardNumber);
    }

    public override void EndTurn()
    {
        dealer.DealCards(1, clanType);
    }

    protected override void CheckHealth()
    {
        if (Health.Current >= 0)
            return;
        battle.End();

    }
}
