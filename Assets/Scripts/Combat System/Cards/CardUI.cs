using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    [SerializeField]
    private Image cardImage;
    [SerializeField]
    private TextMeshProUGUI cardTitle;
    [SerializeField]
    private TextMeshProUGUI cardDescription;

    public void ChangeUI(Card card)
    {
        if (!card) return;
        //cardImage.sprite = card.Info?.CardImage;
        cardTitle.text = card.Info?.CardTitle;
        cardDescription.text = card.Info?.CardDescription;
    }
}
