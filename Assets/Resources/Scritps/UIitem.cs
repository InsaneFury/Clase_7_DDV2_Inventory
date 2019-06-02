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
    Image icon;
    bool hasSprite = false;

    private void Start()
    {
        icon = GetComponent<Image>();
        currentItem = GetComponent<RectTransform>();
        originalSize = currentItem.sizeDelta;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (hasSprite)
        {
            Debug.Log("isBeginDraw");
        }  
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (hasSprite)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
         transform.localPosition = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (icon.sprite != null)
        {
            hasSprite = true;
            currentItem.sizeDelta = OnClickSize;
            currentItem.parent.parent.SetAsLastSibling();
        }
        else
        {
            hasSprite = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        currentItem.sizeDelta = originalSize;
    }
}
