using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCard : Card
{
    public override void Use(Battle battle)
    {
        CombatCharacter currentPawn = battle.GetCharacter();
        currentPawn.Health.Heal(info.PrimaryValue);

        base.Use(battle);
    }
}
