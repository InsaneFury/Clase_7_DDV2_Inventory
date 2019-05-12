using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Create Unique Item",order = 0)]
public class ItemUniqueStats : ScriptableObject
{
    [Header("Unique Item Stats")]
    public new string name;
    public Material mat;
    public int magic;
    public int strength;
    public int agility;
    public int mana;

}
