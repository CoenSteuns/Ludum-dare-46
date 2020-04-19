using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip mainClip, combatClip;

    [SerializeField]
    private AudioSource source;

    private void Awake()
    {
        SetCombat(false);
    }

    public void SetCombat(bool combat)
    {
        source.clip = combat ? combatClip : mainClip;
        source.Play();
    }

}
