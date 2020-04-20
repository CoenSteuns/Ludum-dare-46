using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{

    [SerializeField]
    private LoopingRandomController walkingaudio;
    [SerializeField]
    private PathMover playerMovement;

    [SerializeField]
    private RandomClipController damageAudio;
    [SerializeField]
    private Health health;

    private void Awake()
    {
        playerMovement.OnStartedWalking += walkingaudio.StartLoop;
        playerMovement.OnStoppedWalking += walkingaudio.StopLoop;

        health.OnHealthChange += (health) =>
        {
            if (health.LastChange > 0)
                return;

            damageAudio.Play();
        };
    }

}
