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
    }

    protected virtual float CheckColor(AttackColorTypes color)
    {
        float multiplier = 1;
        float highMultiplier = 2;
        float lowMultiplier = 0.5f;

        if (color == info.Color)
            return multiplier;

        switch (color)
        {
            case AttackColorTypes.orange:
                multiplier = info.Color == AttackColorTypes.blue ? highMultiplier : lowMultiplier;
                break;
            case AttackColorTypes.blue:
                multiplier = info.Color == AttackColorTypes.green ? highMultiplier : lowMultiplier;
                break;
            case AttackColorTypes.green:
                multiplier = info.Color == AttackColorTypes.orange ? highMultiplier : lowMultiplier;
                break;
            default:
                break;
        }


        return multiplier;
    }

    protected virtual void PlaySfx(Battle battle)
    {
        if (info.SFX == null)
            return;

        battle.PlaySound(info.SFX);
    }
    
}