using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IgenericItem
{
    string itemName{get;}
    string itemType{get;}
    string itemSubType{get;}
    int itemLevel{get;}
    int itemDurability{get;}
    float itemWeight{get;}

    GameObject sprite{get;}
    Material mat{get;}
}

public class IitemEventArgs : EventArgs
{
    public IgenericItem Item;
    public IitemEventArgs(IgenericItem item)
    {
        Item = item;
    }
}
