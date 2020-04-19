using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<IInventoryItem> items = new List<IInventoryItem>();

    public event Action<IInventoryItem> ItemAdded;

    public void AddItem(IInventoryItem item)
    {
        if (item == null || items.Contains(item))
            return;

        items.Add(item);
        ItemAdded?.Invoke(item);
    }

    public List<IInventoryItem> Filter(IFilter<IInventoryItem> filter)
    {
        return Filter(filter.check);
    }

    public List<IInventoryItem> Filter(Func<IInventoryItem, bool> filter) {

        if (filter == null)
            return new List<IInventoryItem>();

        List<IInventoryItem> filteredItems = new List<IInventoryItem>();
        for (int i = 0; i < items.Count; i++)
        {
            if (!filter(items[i]))
                continue;

            filteredItems.Add(items[i]);
        }
        return filteredItems;
    }
    
}
