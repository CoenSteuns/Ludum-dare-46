using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    [SerializeField]
    private Sprite[] enemySprites;

    [SerializeField]
    private Image enemyPortrait;

    public void UpdateUI(CombatEnemy enemyCharacter)
    {
        enemyPortrait.sprite = enemySprites[(int)enemyCharacter.ClanType];
    }
}
