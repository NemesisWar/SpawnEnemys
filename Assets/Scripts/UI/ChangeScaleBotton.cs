using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class ChangeScaleBotton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform _rectTransform;

    private void OnEnable()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _rectTransform.localScale = new Vector3(1.3f, 1.3f, 1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }
}
