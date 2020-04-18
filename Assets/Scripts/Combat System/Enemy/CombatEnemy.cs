using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemy : MonoBehaviour
{
    [SerializeField]
    private AttackTypes clanType;

    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
}
