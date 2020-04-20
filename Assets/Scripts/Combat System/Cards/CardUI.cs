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

    [SerializeField]
    private Sprite[] emblems;
    public void ChangeUI(Card card)
    {
        if (!card) return;
        cardImage.sprite = emblems[(int)card.Info.Color];
        cardTitle.text = card.Info?.CardTitle;
        cardDescription.text = card.Info?.CardDescription;
    }
}
