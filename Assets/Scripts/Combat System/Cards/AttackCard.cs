using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : Card
{
    public override void Use(Battle battle)
    {
        CombatCharacter currentPawn = battle.GetCharacter();
        CombatCharacter enemy = battle.GetCharacter(false);

        int damage = info.PrimaryValue;
        if (enemy is CombatEnemy)
        {
            CombatEnemy currentEnemy = (CombatEnemy)enemy;
            damage = (int)Mathf.Round(damage * CheckColor(currentEnemy.ClanType));
        }

        enemy.Health.Damage(damage);

        base.Use(battle);
    }
}
