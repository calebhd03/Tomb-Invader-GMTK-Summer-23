using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite sprite;
    public bool isAvailableToCraft = true;
    public string description;

    public int redCost = 0;
    public int purpleCost = 0;
    public int yellowCost = 0;

    public float damageModifier;
    public float healthModifier;
    public float attackSpeedModifier;
    public float movementSpeedModifier;
}