using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public abstract class Card : MonoBehaviour
{
    protected CardInfo info;
    protected CardInventory inventory;

    private AudioSource audioSource;
    
    public CardInfo Info { get => info; set => info = value; }

    public CardInventory Inventory { set => inventory = value; }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void Use(Battle battle)
    {

        PlaySfx();
        inventory.RemoveCard(this);
        battle.NextTurn();
        Destroy(gameObject);
    }

    protected virtual void PlaySfx()
    {
        if (audioSource == null || Camera.main == null || info.SFX == null)
            return;

        AudioSource.PlayClipAtPoint(info.SFX, Camera.main.transform.position);
    }
    
}