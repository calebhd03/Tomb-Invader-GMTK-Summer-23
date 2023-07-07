using UnityEngine;

[CreateAssetMenu(fileName = "Player Settings")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite sprite;
    public bool isAvailableToCraft = true;
}