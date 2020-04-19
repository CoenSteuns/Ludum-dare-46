using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventory : MonoBehaviour
{
    private List<Card> cards = new List<Card>();
    public Action OnCardAdded;


    public List<Card> Cards => cards;

    public void AddCard(Card card)
    {
        card.Inventory = this;

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

    public void ActivateCards(bool active)
    {
        foreach (var card in Cards)
        {
            card.enabled = active;
        }
    }
}
