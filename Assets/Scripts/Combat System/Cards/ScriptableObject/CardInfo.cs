using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/Info")]
public class CardInfo: ScriptableObject
{
    [SerializeField]
    private string cardTitle;
    [SerializeField]
    private AttackColorTypes color;

    public AttackColorTypes Attack => color;
    public string CardTitle => cardTitle;

}
