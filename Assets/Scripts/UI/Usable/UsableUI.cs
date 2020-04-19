using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UsableUI : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    private Image image;

    [SerializeField]
    private TMPro.TextMeshProUGUI text;

    public event Action<Type> OnUse;

    private Type type;

    private bool isEnabled = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isEnabled)
            return;
        OnUse?.Invoke(type);
    }

    public void SetItem(Sprite icon, Type type)
    {
        image.sprite = icon;
        text.SetText(0.ToString());
        this.type = type;
    }

    public void SetCount(int amount)
    {
        text.SetText(amount.ToString());
    }

    public void Disable()
    {
        isEnabled = false;
    }

    public void Enable()
    {
        isEnabled = true;
    }


}
