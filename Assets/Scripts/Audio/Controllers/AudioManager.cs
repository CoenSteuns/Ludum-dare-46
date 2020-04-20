using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip mainClip, combatClip, GameoverClip;

    [SerializeField]
    private AudioSource source;

    private bool inBattle = false;
    private bool gameOver = false;

    private void Awake()
    {
        SetCombat(inBattle);
    }

    public void SetCombat(bool combat)
    {
        if (gameOver)
            return;

        inBattle = combat;
        source.clip = combat ? combatClip : mainClip;
        source.Play();
    }

    public void SetGameOver()
    {
        source.loop = false;
        gameOver = true;
        source.clip = GameoverClip;
        source.Play();
    }

}
