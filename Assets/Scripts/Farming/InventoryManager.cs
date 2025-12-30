using System;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int coin = 100;
    public int cropQuantity = 0;

    //display coin on UI
    public Transform coinUI;
    private FarmingManager farmingManager;

    private void Start()
    {
        UpdateCoinUI();
        farmingManager = FindObjectOfType<FarmingManager>();
    }

    private void UpdateCoinUI()
    {
        coinUI.GetComponent<TextMeshProUGUI>().text = "Coins: " + coin.ToString();
    }

    // Method to deduct coins when planting a crop
    public void DeductCoins()
    {
        // fix: currentCropType is null reference
        if (farmingManager.currentCropType == null)
        {
            Debug.LogError("CurrentCropType is not set. Cannot deduct coins.");
            return;
        }

        coin -= farmingManager.currentCropType.cost;
        UpdateCoinUI();
        Debug.Log($"Deducted {farmingManager.currentCropType.cost} coins. Remaining coins: {coin}");
    } 
    public void AddCrop(CropType currentCropType)
    {
        cropQuantity += 1;
        Debug.Log($"Added 1 crop. Total crops: {cropQuantity}");
    }
}
