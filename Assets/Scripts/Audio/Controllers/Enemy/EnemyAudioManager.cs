using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioManager : MonoBehaviour
{

    [SerializeField]
    private RandomClipController alertController;
    [SerializeField]
    private FieldOfView enemyAlerter;

    private void Awake()
    {
        enemyAlerter.OnSpottted += alertController.Play;
    }

}
