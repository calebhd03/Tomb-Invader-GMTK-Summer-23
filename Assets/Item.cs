using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite sprite;
    public bool isAvailableToCraft = true;
    public string tipToShow;


}