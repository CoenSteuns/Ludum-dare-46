using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHealthUIBinder : MonoBehaviour
{

    [SerializeField]
    private Battle battle;

    [SerializeField]
    private bool enemy;

    [SerializeField]
    private HealthUI healthUi;

    private void Awake()
    {
        battle.OnBattleStarted += (characters) =>
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (enemy && characters[i] is CombatEnemy)
                {
                    
                    healthUi.SetHealth(characters[i].Health);
                    return;
                }else if(!enemy && characters[i] is CombatPlayer)
                {
                    healthUi.SetHealth(characters[i].Health);
                    return;
                }
            }
        };
    }

}
