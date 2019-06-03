using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : Singleton<ItemDropHandler>, IDropHandler
{
    public Item itemToDrop = null;

    public override void Awake()
    {
        base.Awake();
    }

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform inventroyPanel = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(inventroyPanel, Input.mousePosition))
        {
            if (Inventory.Get().RemoveItemFromInventory(itemToDrop))
            {
                itemToDrop = null;
            }  
        }
    }
}
