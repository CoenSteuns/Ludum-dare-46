using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInventory : MonoBehaviour
{
    private List<Card> cards = new List<Card>();
    public Action OnCardAdded;

    [SerializeField]
    private GameObject cardHolder;

    public List<Card> Cards => cards;

    public void AddCard(Card card)
    {
        card.Inventory = this;
        cards.Add(card);
        OnCardAdded?.Invoke();
    }

    public void RemoveCard(Card card)
    {
        if (!card)
            return;
        cards.Remove(card);
        Destroy(card.gameObject);
    }

    public void RemoveCard(int cardId)
    {
        cards.RemoveAt(cardId);
    }

    public void ClearInventory()    
    {
        cards.Clear();
        for (int i = cardHolder.transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(cardHolder.transform.GetChild(i).gameObject);
        }
    }

    public void ActivateCards(bool active)
    {
        foreach (var card in Cards)
        {
            card.enabled = active;
            card.GetComponent<Button>().enabled = active;
        }
    }
}
