using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CombatPlayer : CombatCharacter
{

    [SerializeField]
    private GameObject level, gameOverScreen;

    public event Action OnBattleStart;

    public override void StartBattle(Battle battle)
    {
        this.battle = battle;
        dealer?.ClearHand();
        dealer?.DealCards(4);

        OnBattleStart?.Invoke();
    }

    public override void StartTurn()
    {

        if (stunnedTime > 0)
        {
            isStunned = true;
            stunnedTime -= 1;
            OnStun?.Invoke("Stunned", true);
            battle.NextTurn(true);
            return;
        }

        if (isStunned)
        {
            isStunned = false;
            OnStun?.Invoke(" ", false);
        }

        dealer.DealCards(1);
        inventory.ActivateCards(true);
    }

    public override void EndTurn()
    {
        
        inventory.ActivateCards(false);
    }

    protected override void CheckHealth(Health health)
    {
        if (health.Current > 0)
            return;

        //Go to gameover screen
        gameOverScreen.SetActive(true);
        level.SetActive(false);
        battle.End();
    }

    public override void ClearInventory()
    {
        inventory.ClearInventory();
    }
}
