using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFilter<T>
{
    bool check(T item);
}
