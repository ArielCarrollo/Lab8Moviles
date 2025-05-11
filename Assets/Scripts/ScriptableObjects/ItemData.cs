using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Game/Items/BaseItem")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int maxStack = 1;
    public GameObject prefab;

    [TextArea] public string description;
}