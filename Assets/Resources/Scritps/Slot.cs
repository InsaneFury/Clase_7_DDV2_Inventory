using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int slotIndex = 0;
    public bool isFull = false;

    PickUpController pickUp;
    Inventory inv;

    void Start()
    {
        pickUp = GameObject.FindGameObjectWithTag("Player").GetComponent<PickUpController>();
        inv = Inventory.Get();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            isFull = false;
        }
    }
    public void RemoveItem()
    {   
            foreach (Transform child in transform)
            {
            pickUp.DropItem(child.gameObject);
            Destroy(child.gameObject);
            }
    }
}
