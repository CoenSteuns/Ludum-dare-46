using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    [SerializeField]
    private Health health;

    [SerializeField]
    private Image healthBar;

    private void Awake() {
        SetHealth(health);
    }

    public void SetHealth(Health health) {

        if (health != null)
            health.OnHealthChange -= UpdateHealth;

        health.OnHealthChange += UpdateHealth;
        this.health = health;
        RefreshHealth();
    }

    private void UpdateHealth(Health health)
    {
        RefreshHealth();
    }

    public void RefreshHealth() {
        healthBar.fillAmount = 1f / health.Max * health.Current;
    }

}