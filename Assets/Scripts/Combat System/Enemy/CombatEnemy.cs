using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class CombatEnemy : MonoBehaviour
{
    [SerializeField]
    private AttackColorTypes clanType;

    private Health health;

    private void Start()
    {
        health.SetHealth(health.Max);
    }
}
