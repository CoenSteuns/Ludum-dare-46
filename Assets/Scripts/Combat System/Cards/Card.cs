using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public abstract class Card : MonoBehaviour
{
    [SerializeField]
    private CardInfo info;

    public CardInfo Info => info;

    public abstract void Use(Battle battle);
}