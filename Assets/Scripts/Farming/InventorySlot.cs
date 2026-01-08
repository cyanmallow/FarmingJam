using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    // below are accessed by inventory manager
    public CropType cropType;
    public int totalQuantity;

    //below are accessed by farming manager
    public int currentLevel;
    public float expNeeded;

    public InventorySlot(CropType cropType, int quantity)
    {
        this.cropType = cropType;
        this.totalQuantity = quantity;
    }
    public void Add(int amount)
    {
        totalQuantity += amount;

    }
}
