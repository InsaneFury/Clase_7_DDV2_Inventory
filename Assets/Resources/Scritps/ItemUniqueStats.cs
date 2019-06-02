using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Create Unique Item",order = 0)]
public class ItemUniqueStats : ScriptableObject
{
    [Header("Unique Item Stats")]
    public new string name;
    public string itemType;
    public string itemSubType;
    public int itemLevel;
    public int itemDurability;
    public float itemWeight;

    public GameObject sprite;
    public Material mat;

}
