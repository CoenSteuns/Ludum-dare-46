using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public abstract class Card : MonoBehaviour
{
    protected CardInfo info;
    protected CardInventory inventory;
    protected Battle battle;
    
    public CardInfo Info { get => info; set => info = value; }

    public CardInventory Inventory { set => inventory = value; }

    public virtual void Use(Battle battle)
    {
        this.battle = battle;
        UpdateUsedCard();
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
                multiplier = info.Color == AttackColorTypes.blue ? lowMultiplier : highMultiplier;
                break;
            case AttackColorTypes.blue:
                multiplier = info.Color == AttackColorTypes.green ? lowMultiplier : highMultiplier;
                break;
            case AttackColorTypes.green:
                multiplier = info.Color == AttackColorTypes.orange ? lowMultiplier : highMultiplier;
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

    protected abstract void UpdateUsedCard();
    
}