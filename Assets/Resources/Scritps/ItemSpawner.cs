using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawner : Singleton<ItemSpawner>
{
    
    
    [Header("RandomItemsSettings")]
    [Tooltip("Prefab to instantiate require item script attached to")]
    public GameObject prefab;
    [Tooltip("List of random materials to random items")]
    public Material[] materials;
    [Tooltip("Max random stats to random items")]
    public float maxStatsPoints = 80f;
    [Header("SpawnUniqueItemsRate")]
    [Tooltip("Scriptable Object of unique item type")]
    public ItemUniqueStats GoldenCube;
    [Tooltip("Probability of drop a unique item (default 25%)")]
    public float uniqueItemsDropRate = 0.25f; //25% of possibility

    int randomMaterial = 0;
    bool getUniqueItem = false;

    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateRandomItem();
        }
    }

    void CreateRandomItem()
    {
        GameObject createdItem;
        createdItem = Instantiate(prefab, transform.position, Quaternion.identity);
        Item itemSettings = createdItem.GetComponent<Item>();

        if ((Random.Range(0f, 1f)) <= uniqueItemsDropRate)
        {
            getUniqueItem = true;
        }
        else
        {
            getUniqueItem = false;
        }

        if (getUniqueItem)
        {
            itemSettings.mat = GoldenCube.mat;
            itemSettings.itemName = GoldenCube.name;
            itemSettings.magic = GoldenCube.magic;
            itemSettings.mana = GoldenCube.mana;
            itemSettings.strength = GoldenCube.strength;
            itemSettings.agility = GoldenCube.agility;
            getUniqueItem = false;
        }
        else
        {
            randomMaterial = (int)(Random.Range(0f, materials.Length));
            itemSettings.mat = materials[randomMaterial];
            itemSettings.itemName = "RandomCube";
            itemSettings.magic = (int)(Random.Range(0f, maxStatsPoints));
            itemSettings.mana = (int)(Random.Range(0f, maxStatsPoints));
            itemSettings.strength = (int)(Random.Range(0f, maxStatsPoints));
            itemSettings.agility = (int)(Random.Range(0f, maxStatsPoints));
        }   
    }
}

