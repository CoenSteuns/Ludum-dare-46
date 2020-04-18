using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Vector2 originalsize;
    private RectTransform rectTransform;

    [SerializeField]
    private float hoverSizeMultiplier = 1.2f;

    private void Awake()
    {
        rectTransform = transform as RectTransform;
        originalsize = rectTransform.sizeDelta;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.sizeDelta = originalsize * hoverSizeMultiplier;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.sizeDelta = originalsize;
    }

}
