using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int coin = 100;
    public int cropQuantity = 0;

    //display coin on UI
    public Transform coinUI;

    // inventory list
    public List<InventorySlot> inventory = new List<InventorySlot>();
    private void Start()
    {
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        coinUI.GetComponent<TextMeshProUGUI>().text = "Coins: " + coin.ToString();
    }

    // Method to deduct coins when planting a crop
    public void DeductCoins()
    {
        FarmingManager farmingManager = CropSelectionUI.Instance.activeFarmingManager;

        if (farmingManager == null)
        {
            Debug.Log("No active FarmingManager");
        }

        CropType currentCropType = farmingManager.currentCropType;
        if (currentCropType == null)
        {
            Debug.LogError("CurrentCropType is not set. Cannot deduct coins.");
            return;
        }

        coin -= currentCropType.cost;
        UpdateCoinUI();
        Debug.Log($"Deducted {farmingManager.currentCropType.cost} coins. Remaining coins: {coin}");
    } 

    public InventorySlot GetInventorySlot(CropType cropType)
    {
        if (cropType == null)
        {
            Debug.Log("GetInventorySlot called with NULL cropType!");
            return null;
        }
        return inventory.Find(s => s.cropType == cropType);
    }

    // add item
    public void AddCrop()
    {
        FarmingManager farmingManager = CropSelectionUI.Instance.activeFarmingManager;

        if (farmingManager == null)
        {
            Debug.Log("No active FarmingManager");
        }

        //InventorySlot slot = inventory.Find(s => s.cropType == farmingManager.currentCropType);
        InventorySlot slot = GetInventorySlot(farmingManager.currentCropType);
        if (farmingManager.currentCropType == null)
        {
            Debug.LogError("AddCrop called with NULL cropType!");
            return;
        }

        if (slot != null)
        {
            slot.totalQuantity += farmingManager.currentCropType.amountGainedPerHarvested;
            Debug.Log($"To an existing cropType in inventory, added {farmingManager.currentCropType.amountGainedPerHarvested} of {farmingManager.currentCropType.name}.");
            // now inventory has xx items
            Debug.Log($"Inventory has " + slot.totalQuantity + " " + farmingManager.currentCropType.cropName);
        }
        else
        {
            inventory.Add(new InventorySlot(farmingManager.currentCropType, farmingManager.currentCropType.amountGainedPerHarvested));
            Debug.Log($"Created new cropType in inventory and added {farmingManager.currentCropType.amountGainedPerHarvested} of {farmingManager.currentCropType.name}.");
            // now inventory has xx items
            Debug.Log($"Inventory has " + farmingManager.currentCropType.amountGainedPerHarvested + " " + farmingManager.currentCropType.cropName);
        }
    }

    // TODO: remove item

}
