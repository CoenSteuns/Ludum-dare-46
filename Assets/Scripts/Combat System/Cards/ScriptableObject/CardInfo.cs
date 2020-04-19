using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/Info")]
public class CardInfo: ScriptableObject
{
    [SerializeField, Header("Info")]
    private Sprite cardImage;
    [SerializeField]
    private CardType typeCard;
    [SerializeField]
    private string cardTitle;
    [SerializeField, TextArea(3, 10)]
    private string cardDescription;
    [SerializeField, Header("Stats")]
    private AttackColorTypes color;
    [SerializeField]
    private int primaryValue;
    [SerializeField]
    private int secondaryValue;
    [SerializeField]
    private int thirdValue;

    public Sprite CardImage => cardImage;
    public CardType TypeCard => typeCard;
    public string CardTitle => cardTitle;
    public string CardDescription => cardDescription;
    public AttackColorTypes Color => color;
    public int PrimaryValue => primaryValue;
    public int SecondaryValue => secondaryValue;
    public int ThirdValue => thirdValue;
}
