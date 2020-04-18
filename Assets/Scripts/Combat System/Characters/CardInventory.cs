using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventory : MonoBehaviour
{
    private List<Card> cards;
    public Action OnCardAdded;

    private void AddCard(Card card)
    {
        cards.Add(card);
        OnCardAdded?.Invoke();
    }

    private void RemoveCard(Card card)
    {
        cards.Remove(card);
    }

    private void RemoveCard(int cardId)
    {
        cards.RemoveAt(cardId);
    }
}
