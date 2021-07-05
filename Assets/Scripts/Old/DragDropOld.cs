using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform)), RequireComponent(typeof(CanvasGroup))]
public class DragDropOld : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[SerializeField] private Canvas _canvas;

	private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    private void Awake() 
    {
		_rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
	}

	// Вызывается перед тем, как начнется перетаскивание.
	public void OnBeginDrag(PointerEventData eventData)
	{
		_canvasGroup.alpha = 0.5f;
		_canvasGroup.blocksRaycasts = false;
	}	

	// Тащим объект
	public void OnDrag(PointerEventData eventData)
	{
		_rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
	}

	// Отпустили объект
	public void OnEndDrag(PointerEventData eventData)
	{
		_canvasGroup.alpha = 1f;
		_canvasGroup.blocksRaycasts = true;
	}
}
