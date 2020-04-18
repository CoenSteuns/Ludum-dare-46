using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Sprite cardImage;

    [SerializeField]
    private string cardTitle;
    [SerializeField]
    private AttackTypes attack;
    [SerializeField]
    private int damageAmount;

    public int DamageAmount { get => damageAmount; }
    public AttackTypes Attack { get => attack; }
    public string CardTitle { get => cardTitle; }
    public Sprite CardImage { get => cardImage; }

    private void Use(Battle battle)
    {

    }
}