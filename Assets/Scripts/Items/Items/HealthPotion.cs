using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HealthPotion : Pickup, IUsable
{
    [Header("Usable"), SerializeField]
    private Health health;

    [SerializeField]
    private int healAmount;


    private void Reset()
    {
        PlayerReference();
    }

    public void Use()
    {
        health.Heal(healAmount);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public bool CanUse()
    {
        return !health.AtMax;
    }

#if UNITY_EDITOR
    [ContextMenu("Health References")]
    public void HandleReferendes()
    {
        HealthPotion[] potions = FindObjectsOfType<HealthPotion>();
        for (int i = 0; i < potions.Length; i++)
        {
            potions[i].PlayerReference();
            EditorUtility.SetDirty(potions[i]);
        }
    }

    public void PlayerReference()
    {
        health = GameObject.Find("Player").GetComponent<Health>();
    }
#endif
}
