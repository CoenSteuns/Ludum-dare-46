using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawPathUI : MonoBehaviour
{
    [SerializeField]
    private DrawPath path;

    [SerializeField]
    private TextMeshProUGUI text;

    private void Awake()
    {
        path.OnPathChanged += (path) => UpdateUI();
    }

    public void UpdateUI()
    {
        text.SetText($"{(int)path.CurrentPathLength}/{(int)path.MaxPathLenth}");
    }
}
