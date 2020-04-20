using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{

    [SerializeField]
    private LoopingRandomController walkingaudio;
    [SerializeField]
    private PathMover playerMovement;

    private void Awake()
    {
        playerMovement.OnStartedWalking += walkingaudio.StartLoop;
        playerMovement.OnStoppedWalking += walkingaudio.StopLoop;
    }

}
