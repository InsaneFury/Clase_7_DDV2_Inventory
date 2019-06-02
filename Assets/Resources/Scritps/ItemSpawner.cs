using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawner : Singleton<ItemSpawner>
{
    [Header("RandomItemsSettings")]
    [Tooltip("Prefab to instantiate require item script attached to")]
    public GameObject prefab;
    [Tooltip("List of Random UI sprites for each item")]
    public List<GameObject> sprites;
    [Tooltip("List of random materials to random items")]
    public Material[] materials;
    [Tooltip("Max random stats to random items")]
    public float maxStatsPoints = 80f;
    [Header("SpawnUniqueItemsRate")]
    [Tooltip("Scriptable Object of unique item type")]
    public ItemUniqueStats GoldenCube;
    [Tooltip("Probability of drop a unique item (default 25%)")]
    public float uniqueItemsDropRate = 0.25f; //25% of possibility
    [Tooltip("Type of item more armor = less weapons")]
    public float armorTypeRate = 0.10f; //10% of possibility
    Weapon weaponSettings = null;
    Armor armorSettings = null;

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

        if ((Random.Range(0f, 1f)) <= armorTypeRate)
        {
            Armor armor = createdItem.AddComponent<Armor>() as Armor;
            armorSettings = createdItem.GetComponent<Armor>();
        }
        else
        {
            Weapon weapon = createdItem.AddComponent<Weapon>() as Weapon;
            weaponSettings = createdItem.GetComponent<Weapon>();
        }

        if ((Random.Range(0f, 1f)) <= uniqueItemsDropRate)
        {
            getUniqueItem = true;
        }
        else
        {
            getUniqueItem = false;
        }
        

        if (getUniqueItem && weaponSettings) //Use Scriptable object stats
        {
            weaponSettings.sprite = GoldenCube.sprite;
            weaponSettings.mat = GoldenCube.mat;
            weaponSettings.itemName = GoldenCube.name;
            weaponSettings.itemLevel = GoldenCube.itemLevel;
            weaponSettings.itemWeight = GoldenCube.itemWeight;
            weaponSettings.itemType = GoldenCube.itemType;
            weaponSettings.itemSubType = GoldenCube.itemSubType;
            weaponSettings.damage = (int)(Random.Range(1f, maxStatsPoints));
            weaponSettings.edge = (int)(Random.Range(1f, maxStatsPoints));
            getUniqueItem = false;
        }
        if (getUniqueItem && armorSettings) //Use Scriptable object stats
        {
            armorSettings.sprite = GoldenCube.sprite;
            armorSettings.mat = GoldenCube.mat;
            armorSettings.itemName = GoldenCube.name;
            armorSettings.itemLevel = GoldenCube.itemLevel;
            armorSettings.itemWeight = GoldenCube.itemWeight;
            armorSettings.itemType = GoldenCube.itemType;
            armorSettings.itemSubType = GoldenCube.itemSubType;
            armorSettings.defense = (int)(Random.Range(1f, maxStatsPoints));
            armorSettings.fireResistance = (int)(Random.Range(1f, maxStatsPoints));
            getUniqueItem = false;
        }
        else if(!getUniqueItem && armorSettings)
        {
            int random = (int)(Random.Range(0f, materials.Length));
            randomMaterial = random;
            armorSettings.sprite = sprites[random];
            armorSettings.mat = materials[randomMaterial];
            armorSettings.itemName = sprites[random].name;
            armorSettings.itemLevel = (int)(Random.Range(1f, maxStatsPoints));
            armorSettings.itemWeight = Random.Range(1f, maxStatsPoints);
            armorSettings.itemType = "Armor";
            armorSettings.itemSubType = "Helmet";
            armorSettings.defense = (int)(Random.Range(1f, maxStatsPoints));
            armorSettings.fireResistance = (int)(Random.Range(1f, maxStatsPoints));
        }
        else if (!getUniqueItem && weaponSettings)
        {
            int random = (int)(Random.Range(0f, materials.Length));
            randomMaterial = random;
            weaponSettings.sprite = sprites[random];
            weaponSettings.mat = materials[randomMaterial];
            weaponSettings.itemName = sprites[random].name;
            weaponSettings.itemLevel = (int)(Random.Range(1f, maxStatsPoints));
            weaponSettings.itemWeight = Random.Range(1f, maxStatsPoints);
            weaponSettings.itemType = "Weapon";
            weaponSettings.itemSubType = "Sword";
            weaponSettings.damage = (int)(Random.Range(1f, maxStatsPoints));
            weaponSettings.edge = (int)(Random.Range(1f, maxStatsPoints));
        }
    }
}

