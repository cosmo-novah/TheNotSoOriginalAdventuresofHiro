using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Loot : ScriptableObject
{
    // public Sprite lootSprite;
    public string lootName;
    public int dropChance;
    public GameObject itemPrefab;

    public Loot(string lootName, int dropChance, GameObject itemPrefab)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
        this.itemPrefab = itemPrefab;
    }
}
