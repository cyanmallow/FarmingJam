using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    // below are accessed by inventory manager
    public CropType cropType;
    public int totalQuantity;

    //below are accessed by farming manager
    public int currentLevel = 1;

    public InventorySlot(CropType cropType, int quantity)
    {
        this.cropType = cropType;
        this.totalQuantity = quantity;
        this.currentLevel = 1;
    }
    public void Add(int amount)
    {
        totalQuantity += amount;

    }
}
