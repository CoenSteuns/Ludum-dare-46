using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudioStart : MonoBehaviour
{
    [SerializeField]
    private AudioManager controller;

    private void OnEnable()
    {
        controller.SetGameOver();
    }

}
