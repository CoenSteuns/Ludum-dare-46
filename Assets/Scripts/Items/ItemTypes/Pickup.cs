using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Item
{
    public void PickupItem(Inventory inventory)
    {
        inventory.AddItem(this);
        transform.SetParent(inventory.transform);
        gameObject.SetActive(false);
    }
}
