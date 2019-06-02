using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UIInventoryManager : Singleton<UIInventoryManager>
{

    public GameObject inventory;
    public RigidbodyFirstPersonController pController;
    bool inventoryIsActive = false;

    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryIsActive = !inventoryIsActive;
            inventory.GetComponentInChildren<Animator>().SetBool("isOpen", inventoryIsActive);
            Cursor.visible = inventoryIsActive;
            pController.enabled = !inventoryIsActive;
            if (inventoryIsActive)
            {
                Cursor.lockState = CursorLockMode.None;  
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }   
        }
    }

    public void SetSprite(Sprite sprite)
    {
  
    }

    public void RemoveSprite(Sprite sprite)
    {
    }
}
