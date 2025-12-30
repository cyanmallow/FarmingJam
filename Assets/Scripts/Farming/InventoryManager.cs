using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int coin = 100;
    public int cropQuantity = 0;

    private CropType currentCropType;

    // Method to deduct coins when planting a crop
    public void DeductCoins()
    {
        coin -= currentCropType.cost;
        Debug.Log($"Deducted {currentCropType.cost} coins. Remaining coins: {coin}");
    } 
    public void AddCrop(CropType currentCropType)
    {
        cropQuantity += 1;
        Debug.Log($"Added 1 crop. Total crops: {cropQuantity}");
    }
}
