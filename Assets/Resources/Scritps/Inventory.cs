using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Singleton<Inventory>
{
    [Header("Inventory Slots")]
    public Slot[] slots;

    [SerializeField]
    List<Item> items;

    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        items = new List<Item>();
    }

    public bool AddItemToInventory(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].isFull)
            {
                items.Add(item);
                slots[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = item.sprite;
                slots[i].isFull = true;
                return true;
            }
        }
        return false;
    }

    public bool RemoveItemFromInventory(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isFull)
            {
                if (items.Contains(item))
                {
                    items.Remove(item);
                    slots[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = null;
                    slots[i].isFull = false;
                }
                return true;
            }
        }
        return false;
    }
}
