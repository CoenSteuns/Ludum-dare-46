using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : Card
{
    public override void Use(Battle battle)
    {
        CombatCharacter currentPawn = battle.GetCharacter();
        CombatCharacter enemy = battle.GetCharacter(false);
        enemy.Health.Damage(Info.PrimaryValue);

        inventory.RemoveCard(this);
        battle.NextTurn();
        Destroy(gameObject);
    }
}
