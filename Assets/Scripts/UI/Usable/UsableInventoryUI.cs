using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel.Design;
using System;

public class UsableInventoryUI : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private UsableUI prefab;

    [SerializeField]
    private RectTransform parent;

    private Dictionary<Type, (UsableUI ui, Stack<IUsable> items)> usablesTypes = new Dictionary<Type, (UsableUI ui, Stack<IUsable> items)>();

    private void Awake()
    {
        inventory.ItemAdded += AddItem;
    }

    private void RefreshItems()
    {
        usablesTypes.Clear();
        var usables = inventory.Filter(new IsUsable());

        for (int i = 0; i < usables.Count; i++) {
            AddItem(usables[i]);
        }
    }

    private void AddItem(IInventoryItem item)
    {
        if (!(item is IUsable))
            return;

        Type type = item.GetType();
        if (!usablesTypes.ContainsKey(type))
            AddNewType(item);

        usablesTypes[type].items.Push(item as IUsable);
        usablesTypes[type].ui.SetCount(usablesTypes[type].items.Count);
        usablesTypes[type].ui.Enable();
    }

    private void UseItem(Type type)
    {
        var items = usablesTypes[type].items;
        if (items.Count == 0)
            return;

        var item = items.Pop();
        
        if (!item.CanUse())
        {
            items.Push(item);
            return;
        }

        item.Use();

        if (items.Count == 0)
            usablesTypes[type].ui.Disable();

        usablesTypes[type].ui.SetCount(usablesTypes[type].items.Count);
        item.Destroy();
    }

    private void AddNewType(IInventoryItem item)
    {
        UsableUI ui = Instantiate(prefab);
        ui.transform.SetParent(parent, false);
        ui.SetItem(item.Image, item.GetType());
        usablesTypes.Add(item.GetType(), (ui: ui, items: new Stack<IUsable>()));

        ui.OnUse += UseItem;
    }

}
