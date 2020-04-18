using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventory : MonoBehaviour
{
    private List<Card> cards;
    public Action OnCardAdded;

    public List<Card> Cards => cards;
    public void AddCard(Card card)
    {
        Cards.Add(card);
        OnCardAdded?.Invoke();
    }

    public void RemoveCard(Card card)
    {
        Cards.Remove(card);
    }

    public void RemoveCard(int cardId)
    {
        Cards.RemoveAt(cardId);
    }

    public void ClearInventory()
    {
        Cards.Clear();
    }

    public void ActivateCards(bool active)
    {
        foreach (var card in Cards)
        {
            card.enabled = active;
        }
    }
}
