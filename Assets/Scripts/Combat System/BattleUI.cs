using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    [SerializeField]
    private Sprite[] enemySprites;

    [SerializeField]
    private Color[] enemyColors;

    [SerializeField]
    private Image enemyPortrait;

    [SerializeField]
    private Image enemyHealthBar;

    public void UpdateUI(CombatEnemy enemyCharacter)
    {
        enemyPortrait.sprite = enemySprites[(int)enemyCharacter.ClanType];
        enemyHealthBar.color = enemyColors[(int)enemyCharacter.ClanType];
    }
}
