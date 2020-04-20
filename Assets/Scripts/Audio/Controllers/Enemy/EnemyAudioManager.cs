using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioManager : MonoBehaviour
{
    [SerializeField]
    private RandomClipController alertController;
    [SerializeField]
    private FieldOfView enemyAlerter;

    [SerializeField]
    private RandomClipController damageAudio;
    [SerializeField]
    private Health health;

    private void Awake()
    {
        enemyAlerter.OnSpottted += alertController.Play;
        health.OnHealthChange += (health) =>
        {
            if (health.LastChange > 0)
                return;

            damageAudio.Play();
        };
    }

}
