using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    [SerializeField]
    private CardInventory inventory;

    [SerializeField]
    private List<Card> availableCards;

    private void DealCards(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            AttackColorTypes type = GetRandomType();
            DealCard(type);
        }
    }

    private void DealCards(int amount, AttackColorTypes type)
    {
        for (int i = 0; i < amount; i++)
        {
            DealCard(type);
        }
    }

    private void DealCard(AttackColorTypes type)
    {
        inventory.AddCard(GetRandomCard(type));
    }

    private Card GetRandomCard(AttackColorTypes type)
    {
        int cardId = UnityEngine.Random.Range(0, availableCards.Count);
        return availableCards[cardId];
    }

    private AttackColorTypes GetRandomType()
    {
        int amountTypes = Enum.GetNames(typeof(AttackColorTypes)).Length;
        int colorTypeId = UnityEngine.Random.Range(0, amountTypes);
        return (AttackColorTypes)colorTypeId;
    }
}
