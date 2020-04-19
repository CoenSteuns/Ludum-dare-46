using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : CombatCharacter
{

    [SerializeField]
    private GameObject level, gameOverScreen;

    public override void StartBattle(Battle battle)
    {
        this.battle = battle;
        dealer.ClearHand();
        dealer.DealCards(4);
    }

    public override void StartTurn()
    {

        if (stunnedTime > 0)
        {
            stunnedTime -= 1;
            battle.NextTurn(true);
            return;
        }

        inventory.ActivateCards(true);
    }

    public override void EndTurn()
    {
        dealer.DealCards(1);
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
}
