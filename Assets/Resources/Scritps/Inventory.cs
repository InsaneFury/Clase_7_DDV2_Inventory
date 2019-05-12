using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
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

    public void AddItemToInventory(GameObject go)
    {
        items.Add(go);
        go.SetActive(false);
    }

    public void RemoveItemFromInventory(Vector3 dropPos)
    {
        if (items.Count > 0)
        {
            dropPos.y += posYGap;
            items[0].transform.position = dropPos;
            items[0].transform.rotation = transform.rotation;
            items[0].SetActive(true);
            items.RemoveAt(0);
        }
    }
}
