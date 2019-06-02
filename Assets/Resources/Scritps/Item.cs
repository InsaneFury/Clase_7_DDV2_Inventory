using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("ItemSettings")]
    public string itemName = "none";
    public string itemType = "none";
    public string itemSubType = "none";
    public int itemLevel = 1;
    public int itemDurability = 100;
    public float itemWeight = 1f;
    
    public GameObject sprite;
    public Material mat;

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
