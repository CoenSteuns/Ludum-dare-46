using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CardDealer : MonoBehaviour
{
    [SerializeField]
    private CardInventory inventory;

    [SerializeField]
    private CardCreator creator;

    public void DealCards(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            AttackColorTypes type = GetRandomType();
            DealCard(type);
        }
    }

    public void DealCards(int amount, AttackColorTypes type)
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
        return creator.CreateCard(type);
    }

    private AttackColorTypes GetRandomType()
    {
        int amountTypes = Enum.GetNames(typeof(AttackColorTypes)).Length;
        int colorTypeId = UnityEngine.Random.Range(0, amountTypes);
        return (AttackColorTypes)colorTypeId;
    }

    public void ClearHand()
    {
        inventory?.ClearInventory();
    }
}
