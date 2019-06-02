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
    }

    public void PickItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, PickUpDistance))
        {
            if (hit.collider.CompareTag("Item"))
            {
                if (inv.AddItemToInventory(hit.collider.gameObject.GetComponent<Item>()))
                {
                    Debug.Log(hit.collider.name + " Added to inventory");
                }
                else
                {
                    Debug.Log("Inventory is Full");
                }
            }
        }
    }

    public void DropItem(GameObject item)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, PickUpDistance))
        {
            if (inv.RemoveItemFromInventory(hit.point, hit.collider.gameObject.GetComponent<Item>()))
            {
                Debug.Log("Item removed from inventory successfully");
            }
            else
            {
                Debug.Log("Your inventory is empty");
            }
        } 
    }
}
