using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/Info")]
public class CardInfo: ScriptableObject
{
    [SerializeField]
    private Sprite cardImage;
    [SerializeField]
    private string cardTitle;
    [SerializeField]
    private string cardDescription;
    [SerializeField]
    private AttackColorTypes color;

    public Sprite CardImage => cardImage;
    public AttackColorTypes Color => color;
    public string CardTitle => cardTitle;
    public string CardDescription => cardDescription;

}
