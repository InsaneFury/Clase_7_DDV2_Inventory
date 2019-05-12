using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [Header("PickUpDistance")]
    public float PickUpDistance = 100f;

    Inventory inv;

    void Start()
    {
        inv = Inventory.Get();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PickItem();
        }
        if (Input.GetMouseButtonDown(1))
        {
            DropItem();
        }
    }

    public void PickItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, PickUpDistance))
        {
            if (hit.collider.CompareTag("Item"))
            {
                inv.AddItemToInventory(hit.collider.gameObject);
            }
        }
    }

    public void DropItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, PickUpDistance))
        {
            inv.RemoveItemFromInventory(hit.point);
        } 
    }
}
