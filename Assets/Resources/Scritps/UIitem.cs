using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIitem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerDownHandler,IPointerUpHandler
{
    public Vector2 OnClickSize;
    public Image icon;
    Vector2 originalSize;
    RectTransform currentItem;
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
            icon.raycastTarget = false;
        }  
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (hasSprite)
        {
            transform.position = Input.mousePosition;
            
            Debug.Log(eventData.pointerCurrentRaycast.gameObject.tag);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        icon.raycastTarget = true;
        GameObject _icon;
        _icon = null;
        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Icon"))
        {
            _icon = eventData.pointerCurrentRaycast.gameObject;
            Debug.Log("OnIcon");
            if (!_icon.transform.parent.parent.GetComponent<Slot>().isFull)
            {
                transform.localPosition = _icon.transform.localPosition;
            }
            else
            {
                Vector3 temp;
                temp = _icon.transform.localPosition;
                _icon.transform.localPosition = transform.localPosition;
                transform.localPosition = temp;
            }
        }   
        else
        {
            transform.localPosition = Vector3.zero;
        }
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
