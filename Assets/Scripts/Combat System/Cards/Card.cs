using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class Card : MonoBehaviour
{
    [SerializeField]
    private Sprite cardImage;

    [SerializeField]
    private CardInfo info;

    
    public Sprite CardImage => cardImage;

    private void Use(Battle battle)
    {
        
    }
}