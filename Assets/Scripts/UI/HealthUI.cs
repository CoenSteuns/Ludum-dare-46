using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    [SerializeField]
    private Battle battle;

    [SerializeField]
    private Health health;

    [SerializeField]
    private bool isEnemy = false;

    [SerializeField]
    private Image healthBar;

    private void Awake() {
        if (isEnemy)
            battle.OnBattleStarted += SetEnemyHealth;
    }

    private void SetEnemyHealth(CombatCharacter[] characters)
    {
        if (!isEnemy)
            return;
        for (int i = 0; i < characters.Length; i++)
        {
            if(characters[i] is CombatEnemy)
                SetHealth(characters[i].Health);
        }
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