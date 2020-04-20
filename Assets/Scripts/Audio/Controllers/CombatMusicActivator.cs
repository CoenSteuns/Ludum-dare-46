using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMusicActivator : MonoBehaviour
{

    [SerializeField]
    private AudioManager audioManager;

    private void OnEnable()
    {
        audioManager.SetCombat(true);
    }

    private void OnDisable()
    {
        audioManager.SetCombat(false);
    }

}
