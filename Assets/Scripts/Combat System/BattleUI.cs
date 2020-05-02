using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    [SerializeField]
    private Battle battle;

    [SerializeField]
    private CanvasGroup battleUIGroup;

    [SerializeField, Range(0, 3)]
    private float transitionTime;

    [SerializeField, Header("Enemy Info")]
    private Sprite[] enemySprites;

    [SerializeField]
    private Color[] enemyColors;

    [SerializeField]
    private Image enemyPortrait;

    [SerializeField]
    private Image enemyHealthBar;

    private void Awake()
    {
        battle.OnBattleStarted += UpdateUI;
        battle.OnBattleEnded += LeaveUI;
    }

    private void UpdateUI(CombatCharacter[] characters)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] is CombatEnemy)
                UpdateEnemyUI((CombatEnemy)characters[i]);
        }
        StartCoroutine(ScreenFade(true));
    } 

    private void LeaveUI()
    {
        ScreenFade(false); //turn ui off after fade finish
    }

    private IEnumerator ScreenFade(bool fadeIn)
    {
        float startValue = !fadeIn ? 1 : 0; 
        float goal = fadeIn ? 1 : 0;
        float time = transitionTime;

        battleUIGroup.alpha = startValue;

        while ((goal - battleUIGroup.alpha) >= 0.05f )
        {
            float progress = (transitionTime - time) / transitionTime;
            battleUIGroup.alpha = Mathf.InverseLerp(startValue, goal, progress);
            time -= Time.deltaTime;

            yield return null;
        }
        battleUIGroup.alpha = goal;
    }

    private void UpdateEnemyUI(CombatEnemy enemyCharacter)
    {
        enemyPortrait.sprite = enemySprites[(int)enemyCharacter.ClanType];
        enemyHealthBar.color = enemyColors[(int)enemyCharacter.ClanType];
    }
}
