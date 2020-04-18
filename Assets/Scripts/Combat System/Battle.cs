using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    private CombatCharacter[] characters;

    private void Start()
    {
        StartBattle();
    }

    public void StartBattle()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].StartBattle(this);
        }
    }

    public void End()
    {

    }
}
