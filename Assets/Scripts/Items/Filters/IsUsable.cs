using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsUsable : IFilter<IInventoryItem>
{
    public bool check(IInventoryItem item)
    {
        return item is IUsable;
    }
}
