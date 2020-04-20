using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : Card
{
    private int finalDamage = 0;
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
        finalDamage = damage;
        base.Use(battle);
    }

    protected override void UpdateUsedCard()
    {
        battle.UpdateUsedCard(info.Color, "Attacked the opponent for " + finalDamage + " damage");
    }
}
