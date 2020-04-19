using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardCreator : MonoBehaviour
{
    [SerializeField]
    private Transform cardHolder;
    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private bool useCardUI = true;
    [SerializeField]
    private List<CardInfo> availableCardsinfo;

    public Card CreateCard(AttackColorTypes type)
    {
        CardInfo info = GetRandomCardInfo(type);
        Card currentCard = GetCard(info);

        GameObject cardObject = Instantiate(cardPrefab, cardHolder);
        currentCard = (Card)cardObject.AddComponent(currentCard.GetType());
        currentCard.Info = info;

        if (useCardUI)
        {
            CardUI ui = cardObject.GetComponent<CardUI>();
            ui.ChangeUI(currentCard);
        }

        return currentCard;
    }

    private CardInfo GetRandomCardInfo(AttackColorTypes type)
    {
        List<CardInfo> filteredCardsInfo = new List<CardInfo>();

        for (int i = 0; i < availableCardsinfo.Count; i++)
        {
            if(availableCardsinfo[i].Color == type)
                filteredCardsInfo.Add(availableCardsinfo[i]);
        }

        //filteredCardsInfo = availableCardsinfo.Where(info => info.Color == type) as List<CardInfo>;
        int infoId = Random.Range(0, filteredCardsInfo.Count);
        
        return filteredCardsInfo[infoId];
    }

    private Card GetCard(CardInfo info)
    {
        Card card;
        switch (info.TypeCard)
        {
            case CardType.Attack:
                card = new AttackCard();
                break;
            case CardType.Healing:
                card = new AttackCard();
                break;
            case CardType.Stun:
                card = new AttackCard();
                break;
            default:
                card = new AttackCard();
                break;
        }


        return card;
    }
}
