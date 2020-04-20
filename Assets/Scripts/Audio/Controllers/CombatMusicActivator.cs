using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMusicActivator : MonoBehaviour
{

    [SerializeField]
    private AudioManager audioManager;

    [SerializeField]
    private Battle battle;

    private void Awake()
    {

        battle.OnBattleStarted += (c) => audioManager.SetCombat(true);
        battle.OnBattleEnded += () => audioManager.SetCombat(false);
    }


}
