using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UsedCardInfoUI : MonoBehaviour
{

    [SerializeField]
    private bool isEnemy = false;

    [SerializeField]
    private TextMeshProUGUI titleText;

    [SerializeField]
    private Image logo;

    [SerializeField]
    private TextMeshProUGUI titleDescription;

    [SerializeField]
    private Sprite[] clanEmblems;    

    public void UpdateUI(AttackColorTypes clan, string description)
    {
        gameObject.SetActive(true);
        titleText.text = isEnemy ? GetName(clan) : "Wiilmp";
        logo.sprite = clanEmblems[(int)clan];
        titleDescription.text = description;
    }

    private string GetName(AttackColorTypes clan)
    {
        switch (clan)
        {
            case AttackColorTypes.orange:
                return "Q Zaza";
            case AttackColorTypes.blue:
                return "Hellcat";
            case AttackColorTypes.green:
                return "Demon Huntress";
            default:
                return ""; 
        }
    }
}
