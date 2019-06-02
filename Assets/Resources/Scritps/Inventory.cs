using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [Header("Inventory Slots")]
    public Slot[] slots;

    [SerializeField]
    List<GameObject> items;
    float posYGap = 1f; // Instantiate object with a Y gap

    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        items = new List<GameObject>();
    }
    private void Update()
    {
        
    }

    public bool AddItemToInventory(GameObject item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].isFull)
            {
                items.Add(item);
                item.GetComponent<Item>().slotId = slots[i].slotIndex;
                item.SetActive(false);
                Instantiate(item.GetComponent<Item>().sprite, slots[i].transform, false);
                slots[i].isFull = true;
                return true;
            }
        }
        return false;
    }

    public bool RemoveItemFromInventory(Vector3 dropPos,GameObject item)
    {
        if (items.Count > 0)
        {
            int index = items.IndexOf(item);
            dropPos.y += posYGap;
            items[index].transform.position = dropPos;
            items[index].transform.rotation = transform.rotation;
            items[index].SetActive(true);
            items.RemoveAt(index);
            return true;
        }
        return false;
    }
}
