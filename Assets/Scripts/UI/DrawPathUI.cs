using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DrawPathUI : MonoBehaviour
{
    [SerializeField]
    private DrawPath path;

    [SerializeField]
    private Image bar;

    private void Awake()
    {
        path.OnPathChanged += (path) => UpdateUI();
    }

    public void UpdateUI()
    {
        bar.fillAmount = 1 - (1 / path.MaxPathLenth * path.CurrentPathLength); 
    }
}
