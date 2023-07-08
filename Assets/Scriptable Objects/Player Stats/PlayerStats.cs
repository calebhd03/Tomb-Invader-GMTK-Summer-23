using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int redMaterials;
    public int purpleMaterials;
    public int yellowMaterials;

    public float damage;
    public float attackSpeed;
    public float health;
    public float movementSpeed;

    public int maxInventory;
    public List<Item> equippedItems;
}
