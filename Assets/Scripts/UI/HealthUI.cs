using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour {

    [SerializeField]
    private Battle battle;

    [SerializeField]
    private Health health;

    [SerializeField]
    private TextMeshProUGUI status;

    [SerializeField]
    private bool isEnemy = false;

    [SerializeField]
    private Image healthBar;

    private void Awake() {
        if (isEnemy)
            battle.OnBattleStarted += SetEnemyHealth;
        else
            health.gameObject.GetComponent<CombatCharacter>().OnStun += UpdateStatus;
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
        health.gameObject.GetComponent<CombatCharacter>().OnStun += UpdateStatus;
    }

    public void SetHealth(Health health) {

        if (health != null)
            health.OnHealthChange -= UpdateHealth;

        health.OnHealthChange += UpdateHealth;
        this.health = health;
        RefreshHealth();
    }

    private void UpdateStatus(string statusText, bool isActive)
    {
        status?.gameObject?.SetActive(isActive);
        status.text = statusText;
    }

    private void UpdateHealth(Health health)
    {
        RefreshHealth();
    }

    public void RefreshHealth() {
        healthBar.fillAmount = 1f / health.Max * health.Current;
    }
}