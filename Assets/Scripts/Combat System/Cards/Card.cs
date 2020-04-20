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

    public virtual void Use(Battle battle)
    {

        PlaySfx(battle);
        inventory.RemoveCard(this);
        battle.NextTurn();
        Destroy(gameObject);
    }

    protected virtual void PlaySfx(Battle battle)
    {
        if (info.SFX == null)
            return;

        battle.PlaySound(info.SFX);
    }
    
}