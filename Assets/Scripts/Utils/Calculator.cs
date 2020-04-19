using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    public static int CalculatePercentage(int maxValue, int value)
    {
        float percentage = (maxValue / 100) * value;
        return (int) Mathf.Round(percentage);
    }
}
