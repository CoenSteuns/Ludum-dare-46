using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventory : MonoBehaviour
{
    private List<Card> cards;
    public Action OnCardAdded;

    public void AddCard(Card card)
    {
        cards.Add(card);
        OnCardAdded?.Invoke();
    }

    public void RemoveCard(Card card)
    {
        cards.Remove(card);
    }

    public void RemoveCard(int cardId)
    {
        cards.RemoveAt(cardId);
    }

    public void ClearInventory()
    {
        cards.Clear();
    }
}
