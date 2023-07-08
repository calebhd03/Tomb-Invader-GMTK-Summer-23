using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int redMaterials = 0;
    public int purpleMaterials = 0;
    public int yellowMaterials = 0;

    public float damage = 1;
    public float attackSpeed = 1f;
    public float health = 1f;
    public float movementSpeed = 1f;

    public int maxInventory;
    public List<Item> equippedItems;
}
