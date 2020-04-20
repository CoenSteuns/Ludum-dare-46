using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UsableUI : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    private Image image;

    [SerializeField]
    private TMPro.TextMeshProUGUI text;

    public event Action<Type> OnUse;

    private Type type;

    private bool isEnabled = true;

    public UnityEvent OnClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isEnabled)
            return;
        OnUse?.Invoke(type);
        OnClick?.Invoke();
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
