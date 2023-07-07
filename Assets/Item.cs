using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite sprite;
    public bool isAvailableToCraft = true;
    public string tipToShow;

    public float damageModifier;
    public float healthModifier;
    public float attackSpeedModifier;
    public float movementSpeedModifier;
}