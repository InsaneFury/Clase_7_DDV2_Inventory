using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform inventroyPanel = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(inventroyPanel, Input.mousePosition))
        {
            Debug.Log("Item Drop");
        }
    }
}
