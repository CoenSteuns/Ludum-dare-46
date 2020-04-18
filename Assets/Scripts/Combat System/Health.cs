using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int current;

    public int Max => maxHealth;
    public int Current => current;

    public event Action<Health> OnHealthChange;

    public void SetMaxHealth(int maxHealth) {
        this.maxHealth = maxHealth;
    }

    public void Heal(int amount) {
        SetHealth(current + amount);
    }

    public void Damage(int amount) {
        SetHealth(current - amount);
    }

    public void SetHealth(int newHealth) {

        newHealth = Math.Max(0, Math.Min(maxHealth, newHealth));

        if (newHealth == current)
            return;

        current = newHealth;
        OnHealthChange?.Invoke(this);
    }

}