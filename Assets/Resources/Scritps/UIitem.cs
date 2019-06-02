using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIitem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerDownHandler,IPointerUpHandler
{
    public Vector2 OnClickSize;
    Vector2 originalSize;
    RectTransform currentItem;

    private void Start()
    {
        currentItem = GetComponent<RectTransform>();
        originalSize = currentItem.sizeDelta;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("isBeginDraw");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        currentItem.sizeDelta = OnClickSize;
        currentItem.parent.SetAsLastSibling();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        currentItem.sizeDelta = originalSize;
    }
}
