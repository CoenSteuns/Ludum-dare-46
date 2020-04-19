using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public abstract class Card : MonoBehaviour
{
    protected CardInfo info;
    protected CardInventory inventory;

    
    public CardInfo Info { get => info; set => info = value; }

    public CardInventory Inventory { set => inventory = value; }

    public abstract void Use(Battle battle);
    
}