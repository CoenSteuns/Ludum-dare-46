using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : CombatCharacter
{

    public override void StartBattle(Battle battle)
    {
        this.battle = battle;
        dealer.ClearHand();
        dealer.DealCards(4);
    }

    public override void StartTurn()
    {
        inventory.ActivateCards(true);
    }

    public override void EndTurn()
    {
        dealer.DealCards(1);
        inventory.ActivateCards(false);
    }

    protected override void CheckHealth()
    {
        if (Health.Current >= 0)
            return;
        battle.End();
    }
}
