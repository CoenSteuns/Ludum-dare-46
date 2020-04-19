using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour, IInventoryItem
{
    [Header("Item info"), SerializeField]
    private Sprite image;

    [SerializeField]
    private string title;

    public Sprite Image => image;
    public string Title => title;
}
