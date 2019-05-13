using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("ItemSettings")]
    public string itemName = "Cube";
    public int slotId = 0;
    public GameObject sprite;
    public Material mat;
    public int magic = 0;
    public int strength = 0;
    public int agility = 0;
    public int mana = 0;

    private void Start()
    {
        gameObject.name = itemName;
        SetMaterial(mat);
    }

    public void SetMaterial(Material _mat)
    {
        gameObject.GetComponent<Renderer>().material = _mat;
    }
}
