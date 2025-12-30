using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    private string ItemName;
    private string ItemDescription;
    private int price;
    
}
