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
        health.SetHealth(health.Max);
        dealer.DealCards(4, clanType);
    }

    public override void StartTurn()
    {
        //Make logic for choosing cards
        throw new System.NotImplementedException();
    }

    public override void EndTurn()
    {
        dealer.DealCards(1, clanType);
    }

    protected override void CheckHealth()
    {
        if (health.Current >= 0)
            return;
        battle.End();

    }
}
