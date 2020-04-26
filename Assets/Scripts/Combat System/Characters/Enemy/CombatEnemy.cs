using System;
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

    [SerializeField]
    private int extraStunWait = 2;

    private int opponentStunnedRounds = 0;

    public AttackColorTypes ClanType => clanType;

    public override void StartBattle(Battle battle)
    {
        this.battle = battle;
        Health.SetHealth(Health.Max);
        dealer.DealCards(4, clanType);
    }

    public override void StartTurn()
    {
        if(stunnedTime > 0)
        {
            stunnedTime -= 1;
            battle.NextTurn(true);
            return;
        }
        dealer.DealCards(1, clanType);
        StartCoroutine(PlayCard());
    }

    private IEnumerator PlayCard()
    {
        yield return new WaitForSeconds(1f);

        Card currentCard = null;
        if (Calculator.CalculatePercentage(health.Max, health.Current) <= lowHealthPercentage)
            currentCard = FindCard(CardType.Healing);
        else if (Calculator.CalculatePercentage(health.Max, health.Current) >= highHealthPercentage)
            currentCard = opponentStunnedRounds > 0 ? FindCard(CardType.Attack) : FindCard(CardType.Healing, false);

        if (currentCard == null && inventory.Cards.Count > 0)
            currentCard = inventory.Cards[0];

        if (currentCard.Info.TypeCard == CardType.Stun)
        {
            opponentStunnedRounds = currentCard.Info.PrimaryValue + extraStunWait;
        }

        currentCard?.Use(battle);
    }

    public override void EndTurn()
    {
        
    }

    protected override void CheckHealth(Health health)
    {
        if (health.Current > 0)
            return;
        battle.End();
        DestroyImmediate(gameObject);
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

    public override void ClearInventory()
    {
        inventory.ClearInventory();
    }
}
